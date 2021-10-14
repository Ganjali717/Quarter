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

        public IActionResult Index(int page = 1, int? houseTypeId = null, int? amenitiesId = null, int? houseStatusId = null , int? cityId = null)
        {
            AppUser member = User.Identity.IsAuthenticated ? _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin) : null;

            var query = _context.House.AsQueryable();
            ViewBag.HouseTypeId = houseTypeId;
            ViewBag.AmenitiesId = amenitiesId;
            ViewBag.HouseStatusesId = houseStatusId;
            ViewBag.CityId = cityId;

            if (houseTypeId != null)
                query = query.Where(x => x.HouseTypeId == houseTypeId);
            if(amenitiesId != null)
                query = query.Where(x => x.HouseAmenitis.Any(a => a.AmenitiId == amenitiesId));
            if (houseStatusId != null)
                query = query.Where(x => x.HouseStatusId == houseStatusId);
            if (cityId != null)
                query = query.Where(x => x.CityId == cityId);

            HouseViewModel houseVM = new HouseViewModel
            {
                Houses = query.Include(x => x.HouseImages).Include(x => x.WishlistItems).Include(x => x.City).Include(z => z.HouseStatus).Include(y => y.HouseType).Skip((page - 1) * 4).Take(4).ToList(),
                HouseTypes = _context.HouseTypes.Include(x => x.Houses).ToList(), 
                HouseStatuses = _context.HouseStatuses.Include(x=>x.Houses).ToList(),
                Amenitis = _context.Amenitis.Include(x=> x.HouseAmenitis).ToList(),
                Teams = _context.Teams.ToList()   
            };

            foreach (var item in houseVM.Houses)
            {
                item.IsWished = item.WishlistItems.Any(x => x.AppUserId == member.Id);
            }

            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
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
                        Count = 1,
                        
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
                Houses = _context.House.Include(x => x.HouseImages).Include(x => x.Comments).Include(x => x.HouseStatus).Include(x => x.City).Include(x => x.HouseAmenitis).Include(x => x.Team).ThenInclude(x=> x.teamDetail).FirstOrDefault(x => x.Id == id),
                Amenitis = _context.Amenitis.ToList(),
                HouseTypes = _context.HouseTypes.Include(x=>x.Houses).ToList(),
                HouseImages = _context.HouseImages.ToList(), 
                Evler = _context.House.Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.City).Include(x => x.HouseAmenitis).Include(x => x.Team).ThenInclude(x => x.teamDetail).ToList(),
                komentariya = _context.Comments.ToList(),
                HouseAmenitis = _context.HouseAmenitis.ToList()
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


                    houses.Remove(wishlistItem);
               
                    wishlistItem.Count--;
                
                houseStr = JsonConvert.SerializeObject(houses);
                HttpContext.Response.Cookies.Append("Houses", houseStr);
            }
            else
            {
                WishlistItem memberWishlistItem = _context.WishlistItems.Include(x => x.House).FirstOrDefault(x => x.AppUserId == member.Id && x.HouseId == id);

               
                    _context.WishlistItems.Remove(memberWishlistItem);
                
                
                    memberWishlistItem.Count--;
                

                _context.SaveChanges();

                houses = _context.WishlistItems.Include(x => x.House).ThenInclude(bi => bi.HouseImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new WishlistItemViewModel { HouseId = x.HouseId, Count = x.Count, Name = x.House.Location, Price = x.House.SalePrice, Image = x.House.HouseImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

            }
            return PartialView("_WishlistPartial", houses);
        }

        public IActionResult GetHouse(int id)
        {
            House house = _context.House.Include(x => x.HouseImages).Include(x => x.City).Include(z => z.HouseStatus).Include(y => y.HouseType).FirstOrDefault(x => x.Id == id);

            return PartialView("_HouseModalPartial", house);
        }

        public IActionResult SearchFilter(string search)
        {
            var query = _context.House.AsQueryable();

            HouseViewModel houseVM = new HouseViewModel
            {
                Houses = new List<House>()
            };

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Location.Contains(search));
                houseVM.Houses = query.ToList();
            }

        

            return PartialView("_SearchPartial", houseVM);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(int id, Comment comment)
        {
            var house = _context.House.FirstOrDefault(x => x.Id == id);

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            Comment comment1 = new Comment
            {
                AppUserId = User.Identity.IsAuthenticated?member.Id:null, 
                Date = DateTime.UtcNow, 
                Text = comment.Text, 
                Username = comment.Username, 
                Rate = comment.Rate, 
                Email = comment.Email, 
                HouseId = id
            };

            _context.Comments.Add(comment1);
            _context.SaveChanges();


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());

        }
    }
}
