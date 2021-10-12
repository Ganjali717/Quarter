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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(SendEmail sendEmail, IFormFile[] attachments)
        {
            var body = "Name: " + sendEmail.Name + "<br>Address: " + sendEmail.Address + "<br>Phone: " + sendEmail.Phone + "<br>";
            var mailHelper = new MailHelper(configuration);
            List<string> fileNames = null;
            if (attachments != null && attachments.Length > 0)
            {
                fileNames = new List<string>();
                foreach (IFormFile attachment in attachments)
                {
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", attachment.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        attachment.CopyToAsync(stream);
                    }
                    fileNames.Add(path);
                }
            }
            if (mailHelper.Send(sendEmail.Email, configuration["Gmail:Username"], sendEmail.Subject, body, fileNames))
            {
                ViewBag.msg = "Sent Mail Successfully";
            }
            else
            {
                ViewBag.msg = "Failed";
            }
            return View("Index", new SendEmail());
        }
    }
}
