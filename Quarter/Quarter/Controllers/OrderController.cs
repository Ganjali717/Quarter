using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quarter.Models;
using Quarter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.House).ThenInclude(x => x.HouseImages).Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
            return View(orders);
        }


        public IActionResult Checkout()
        {
            CheckoutViewModel checkoutVM = new CheckoutViewModel();

            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var houseStr = HttpContext.Request.Cookies["Houses"];
                if (!string.IsNullOrWhiteSpace(houseStr))
                {
                    checkoutVM.WishlistItemViewModels = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(houseStr);

                    foreach (var item in checkoutVM.WishlistItemViewModels)
                    {
                        House house = _context.House.Include(x => x.HouseImages).FirstOrDefault(x => x.Id == item.HouseId);
                        if (house != null)
                        {
                            item.Name = house.Location;
                            item.Price = house.SalePrice;
                            item.Image = house.HouseImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                        }
                    }
                }
            }
            else
            {
                checkoutVM.Email = member.Email;
                checkoutVM.FullName = member.FullName;
                checkoutVM.Phone = member.PhoneNumber;

                checkoutVM.WishlistItemViewModels = _context.WishlistItems.Include(x => x.House).Where(x => x.AppUserId == member.Id)
                                                   .Select(x => new WishlistItemViewModel
                                                   {
                                                       HouseId = x.HouseId,
                                                       Name = x.House.Location,
                                                       Count = x.Count,
                                                       Price = x.House.SalePrice
                                                   }).ToList();

            }

            return View(checkoutVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutVM)
        {
            checkoutVM.WishlistItemViewModels = _getBasketItems();
            if (!ModelState.IsValid) return View(checkoutVM);

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            Order order = new Order
            {
                FullName = checkoutVM.FullName,
                Email = checkoutVM.Email,
                Address = checkoutVM.Address,
                City = checkoutVM.City,
                Note = checkoutVM.Note,
                Phone = checkoutVM.Phone,
                Status = Models.Enums.OrderStatus.Pending,
                ZipCode = checkoutVM.ZipCode,
                CreatedAt = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            List<WishlistItemViewModel> wishlistItemVMs = new List<WishlistItemViewModel>();

            if (member == null)
            {
                var houseStr = HttpContext.Request.Cookies["Houses"];
                if (houseStr != null)
                {
                    wishlistItemVMs = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(houseStr);
                }
            }
            else
            {
                order.AppUserId = member.Id;
                wishlistItemVMs = _context.WishlistItems.Where(x => x.AppUserId == member.Id).Select(x => new WishlistItemViewModel { HouseId = x.HouseId, Count = x.Count }).ToList();
            }

            foreach (var item in wishlistItemVMs)
            {
                House house = _context.House.FirstOrDefault(x => x.Id == item.HouseId);

                if (house == null)
                {
                    ModelState.AddModelError("", "Selected book not found");
                    return View(checkoutVM);
                }

                _addOrderItem(ref order, house, item.Count);
            }

            if (order.OrderItems.Count == 0)
            {
                ModelState.AddModelError("", "there is not any selected book!");
                return View(checkoutVM);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            if (member == null)
            {
                Response.Cookies.Delete("Houses");
            }
            else
            {
                _context.WishlistItems.RemoveRange(_context.WishlistItems.Where(x => x.AppUserId == member.Id));
                _context.SaveChanges();
            }

            return RedirectToAction("index", "home");
        }

        private void _addOrderItem(ref Order order, House house, int count)
        {
            OrderItem orderItem = new OrderItem
            {
                HouseId = house.Id,
                HouseLocation = house.Location,
                SalePrice = house.SalePrice
            };

            order.OrderItems.Add(orderItem);
            order.TotalAmount += orderItem.SalePrice;
        }
        private List<WishlistItemViewModel> _getBasketItems()
        {
            List<WishlistItemViewModel> wishlistItems = new List<WishlistItemViewModel>();
            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var houseStr = HttpContext.Request.Cookies["Books"];
                if (!string.IsNullOrWhiteSpace(houseStr))
                {
                    wishlistItems = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(houseStr);

                    foreach (var item in wishlistItems)
                    {
                        House house = _context.House.Include(x => x.HouseImages).FirstOrDefault(x => x.Id == item.HouseId);
                        if (house != null)
                        {
                            item.Name = house.Location;
                            item.Price = house.SalePrice;
                            item.Image = house.HouseImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                        }
                    }
                }
            }
            else
            {

                wishlistItems = _context.WishlistItems.Include(x => x.House).Where(x => x.AppUserId == member.Id)
                                                    .Select(x => new WishlistItemViewModel
                                                    {
                                                        HouseId = x.HouseId,
                                                        Name = x.House.Location,
                                                        Count = x.Count,
                                                        Price = x.House.SalePrice
                                                    }).ToList();

            }
            return wishlistItems;
        }

    }
}
