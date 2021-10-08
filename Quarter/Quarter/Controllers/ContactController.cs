using Microsoft.AspNetCore.Mvc;
using Quarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Setting setting = new Setting
            {
                SupportPhone = _context.Settings.First().SupportPhone,
                Address = _context.Settings.First().Address, 
                Email = _context.Settings.First().Email
            };
            return View(setting);
        }
    }
}
