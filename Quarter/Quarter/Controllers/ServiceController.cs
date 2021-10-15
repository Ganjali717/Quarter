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
                Services = _context.Services.Include(x => x.serviceDetail).ToList(), 
                Settings = _context.Settings.ToList()
            };
            return View(serviceVM);
        }

        public IActionResult Detail(int id)
        {
            if (id <= 0 || id > _context.Services.OrderByDescending(x => x.Id).FirstOrDefault().Id)
            {
               return RedirectToAction("index", "error");
            }

            ServiceViewModel serviceVM = new ServiceViewModel
            {
                Servisler = _context.Services.Include(x => x.serviceDetail).FirstOrDefault(x => x.Id == id),
                Services = _context.Services.Include(x => x.serviceDetail).ToList()
            };
            

            return View(serviceVM);
        }
    }
}
