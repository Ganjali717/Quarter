using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quarter.Helpers;
using Quarter.Models;
using Quarter.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
   
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        private IConfiguration configuration;

        private IWebHostEnvironment webHostEnvironment;

        public ContactController(AppDbContext context, IConfiguration _configuration, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            configuration = _configuration;
            webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Index()
        {
           /* ContactViewModel contactVM = new ContactViewModel
            {
                Setting = _context.Settings.FirstOrDefault()
                
            };*/
           
            return View("Index", new SendEmail());
        }


    }
}
