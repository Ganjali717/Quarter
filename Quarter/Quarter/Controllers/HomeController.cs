using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quarter.Models;
using Quarter.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.HouseStatus = _context.HouseStatuses.ToList();
            ViewBag.HouseType = _context.HouseTypes.ToList();
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderBy(x => x.Order).ToList(),
                Services = _context.Services.ToList(),
                Houses = _context.House.Include(x => x.HouseAmenitis).Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x=>x.City).ToList(),
                Amenitis = _context.Amenitis.Take(8).ToList()
            };
            return View(homeVM);
        }

    }
}
