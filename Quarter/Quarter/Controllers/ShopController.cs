using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HouseViewModel houseVM = new HouseViewModel
            {
                Houses = _context.House.Include(x => x.HouseImages).Include(x => x.City).Include(z => z.HouseStatus).Include(y => y.HouseType).ToList(),
                HouseTypes = _context.HouseTypes.Include(x => x.Houses).ToList(), 
                HouseStatuses = _context.HouseStatuses.Include(x=>x.Houses).ToList(),
                Amenitis = _context.Amenitis.Include(x=> x.HouseAmenitis).ToList()
            };
            return View(houseVM);
        }
    }
}
