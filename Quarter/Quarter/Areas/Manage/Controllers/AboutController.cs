using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quarter.Models;
using Quarter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
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
                Abouts = _context.Abouts.ToList()
            };
            return View(aboutVM);
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return NotFound();

            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(About about)
        {
            About existAbout = _context.Abouts.FirstOrDefault(x => x.Id == about.Id);

            if (existAbout == null) return NotFound();

            existAbout.Title = about.Title;
            existAbout.Icon = about.Icon;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult EditImage(int id)
        {
            if (!ModelState.IsValid) return NotFound();

            var setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditImage(Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);

            existSetting.AboutUsTitle = setting.AboutUsTitle;
            existSetting.AboutUsDesc = setting.AboutUsDesc;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
