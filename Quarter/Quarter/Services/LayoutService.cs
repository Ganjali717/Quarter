using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quarter.Models;
using Quarter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }

        public List<WishlistItemViewModel> GetWishItems()
        {

            List<WishlistItemViewModel> items = new List<WishlistItemViewModel>();

            AppUser member = null;
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }


            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Books"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(itemsStr);

                    foreach (var item in items)
                    {
                        House house = _context.House.Include(c => c.HouseImages).FirstOrDefault(x => x.Id == item.HouseId);
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
                List<WishlistItem> wishlistItem = _context.WishlistItems.Include(x => x.House).ThenInclude(x => x.HouseImages).Where(x => x.AppUserId == member.Id).ToList();
                items = wishlistItem.Select(x => new WishlistItemViewModel
                {
                    HouseId = x.HouseId,
                    Image = x.House.HouseImages.FirstOrDefault(bi => bi.PosterStatus == true)?.Image,
                    Name = x.House.Location,
                    Price = x.House.SalePrice
                }).ToList();
            }

            return items;
        }

    }
}
