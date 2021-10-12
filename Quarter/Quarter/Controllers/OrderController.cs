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
            List<Order> orders = _context.Orders.Where(x => x.AppUser.UserName == User.Identity.Name).ToList();
            return View(orders);
        }


        public async Task<IActionResult> Checkout(int id)
        {
            House house = _context.House.Include(x => x.HouseImages).FirstOrDefault(x => x.Id == id);
            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            Order order = new Order
            {
                FullName = member.FullName, 
                Email = member.Email, 
                SalePrice = house.SalePrice, 
                HouseLocation = house.Location,
                AppUserId = member.Id, 
                HouseImage = house.HouseImages.FirstOrDefault(x => x.PosterStatus ==true).Image,
                HouseId = house.Id,
                CreatedAt = DateTime.UtcNow, 
                Status = Models.Enums.OrderStatus.Pending
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        

       

    }
}
