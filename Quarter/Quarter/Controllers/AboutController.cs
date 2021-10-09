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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                Settings = _context.Settings.ToList(),
                Abouts = _context.Abouts.ToList(), 
                Teams = _context.Teams.Include(x => x.teamDetail).Skip(3).Take(3).ToList(),
                Services = _context.Services.Take(3).ToList()
            };
            return View(aboutVM);
        }
    }
}
