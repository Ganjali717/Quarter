using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quarter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Service> services = _context.Services.Include(x => x.serviceDetail).ToList();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (service.serviceDetail.FileImage != null)
            {
                if (service.serviceDetail.FileImage.ContentType != "image/jpeg" && service.serviceDetail.FileImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (service.serviceDetail.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }


                string filename = service.serviceDetail.FileImage.FileName;
                if (filename.Length > 64)
                {
                    filename = filename.Substring(filename.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + filename;

                string path = Path.Combine(_env.WebRootPath, "uploads/service", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    service.serviceDetail.FileImage.CopyTo(stream);
                }

                service.serviceDetail.Image = newFileName;
            }

            _context.Add(service);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var service = _context.Services.Include(x => x.serviceDetail).FirstOrDefault(x => x.Id == id);
            if (service == null) return NotFound();
            return View(service);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Service existService = _context.Services.Include(x => x.serviceDetail).FirstOrDefault(x => x.Id == service.Id);

            existService.Logo = service.Logo;
            existService.Title = service.Title;
            existService.Desc = service.Desc;

            if (service.serviceDetail.FileImage != null)
            {
                if (service.serviceDetail.FileImage.ContentType != "image/jpeg" && service.serviceDetail.FileImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (service.serviceDetail.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }


                string filename = service.serviceDetail.FileImage.FileName;
                if (filename.Length > 64)
                {
                    filename = filename.Substring(filename.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + filename;

                string path = Path.Combine(_env.WebRootPath, "uploads/service", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    service.serviceDetail.FileImage.CopyTo(stream);
                }

                if (existService.serviceDetail.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/service", existService.serviceDetail.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }


                existService.serviceDetail.Image = newFileName;
            }
            else if (service.serviceDetail.Image == null && existService.serviceDetail.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/service", existService.serviceDetail.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existService.serviceDetail.Image = null;
            }


            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null) return Json(new { status = 404 });

            try
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
