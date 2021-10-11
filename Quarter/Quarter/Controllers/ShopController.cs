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
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShopController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            HouseViewModel houseVM = new HouseViewModel
            {
                Houses = _context.House.Include(x => x.HouseImages).Include(x => x.City).Include(z => z.HouseStatus).Include(y => y.HouseType).ToList(),
                HouseTypes = _context.HouseTypes.Include(x => x.Houses).ToList(), 
                HouseStatuses = _context.HouseStatuses.Include(x=>x.Houses).ToList(),
                Amenitis = _context.Amenitis.Include(x=> x.HouseAmenitis).ToList(),
                Teams = _context.Teams.ToList()   
            };
            return View(houseVM);
        }

        public IActionResult AddWishlist(int id)
        {
            House house = _context.House.Include(x => x.HouseImages).FirstOrDefault(x => x.Id == id);
            WishlistItemViewModel wishlistItem = null;
            List<WishlistItemViewModel> houses = new List<WishlistItemViewModel>();

            if (house == null) return NotFound();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                string houseStr;

                if (HttpContext.Request.Cookies["Houses"] != null)
                {
                    houseStr = HttpContext.Request.Cookies["Houses"];
                    houses = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(houseStr);

                    wishlistItem = houses.FirstOrDefault(x => x.HouseId == id);
                }

                if (wishlistItem == null)
                {
                    wishlistItem = new WishlistItemViewModel
                    {
                        HouseId = house.Id,
                        Name = house.Location,
                        Image = house.HouseImages.FirstOrDefault(x => x.PosterStatus == true).Image,
                        Price = house.SalePrice
                    };
                    houses.Add(wishlistItem);
                }
                houseStr = JsonConvert.SerializeObject(houses);
                HttpContext.Response.Cookies.Append("Houses", houseStr);
            }
            else
            {
                WishlistItem memberWishlistItem = _context.WishlistItems.FirstOrDefault(x => x.AppUserId == member.Id && x.HouseId == id);
                if (memberWishlistItem == null)
                {
                    memberWishlistItem = new WishlistItem
                    {
                        AppUserId = member.Id,
                        HouseId = id,
                        Count = 1
                    };
                    _context.WishlistItems.Add(memberWishlistItem);
                }
                else
                {
                    memberWishlistItem.Count++;
                }

                _context.SaveChanges();
                houses = _context.WishlistItems.Include(x => x.House).ThenInclude(bi => bi.HouseImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new WishlistItemViewModel { HouseId = x.HouseId,  Name = x.House.Location, Price = x.House.SalePrice, Image = x.House.HouseImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();
            }

            return PartialView("_WishlistPartial", houses);
        }

        public IActionResult Detail(int id)
        {
            DetailViewModel detailVM = new DetailViewModel
            {
                Houses = _context.House.Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.City).Include(x => x.HouseAmenitis).Include(x => x.Team).ThenInclude(x=> x.teamDetail).FirstOrDefault(x => x.Id == id),
                Amenitis = _context.Amenitis.ToList(),
                HouseTypes = _context.HouseTypes.Include(x=>x.Houses).ToList(),
                HouseImages = _context.HouseImages.ToList()
            };
            
            return View(detailVM);
        }

        public IActionResult DeleteHouse(int id)
        {

            House house = _context.House.Include(x => x.HouseImages).FirstOrDefault(x => x.Id == id);
            WishlistItemViewModel wishlistItem = null;
            if (house == null) return NotFound();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<WishlistItemViewModel> houses = new List<WishlistItemViewModel>();

            if (member == null)
            {

                string houseStr = HttpContext.Request.Cookies["Houses"];
                houses = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(houseStr);

                wishlistItem = houses.FirstOrDefault(x => x.HouseId == id);


                if (wishlistItem.Count == 1)
                {

                    houses.Remove(wishlistItem);
                }
                else
                {
                    wishlistItem.Count--;
                }
                houseStr = JsonConvert.SerializeObject(houses);
                HttpContext.Response.Cookies.Append("Houses", houseStr);
            }

            else
            {
                WishlistItem memberWishlistItem = _context.WishlistItems.Include(x => x.House).FirstOrDefault(x => x.AppUserId == member.Id && x.HouseId == id);

                if (memberWishlistItem.Count == 1)
                {

                    _context.WishlistItems.Remove(memberWishlistItem);
                }
                else
                {
                    memberWishlistItem.Count--;
                }

                _context.SaveChanges();

                houses = _context.WishlistItems.Include(x => x.House).ThenInclude(bi => bi.HouseImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new WishlistItemViewModel { HouseId = x.HouseId, Count = x.Count, Name = x.House.Location, Price = x.House.SalePrice, Image = x.House.HouseImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

            }
            return PartialView("_WishlistPartial", houses);
        }
    }
}
