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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ServiceViewModel serviceVM = new ServiceViewModel
            {
                Services = _context.Services.Include(x => x.serviceDetail)  .ToList(), 
                Settings = _context.Settings.ToList()
            };
            return View(serviceVM);
        }

        public IActionResult Detail(int id)
        {
            var detail = _context.Services.Include(x=>x.serviceDetail).FirstOrDefault(x => x.Id == id);

            return View(detail);
        }
    }
}
