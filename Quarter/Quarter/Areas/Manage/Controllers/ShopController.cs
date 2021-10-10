using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quarter.Helpers;
using Quarter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ShopController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<House> house = _context.House.Include(x => x.HouseAmenitis).Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).ToList();
            return View(house);
        }

        public IActionResult Create()
        {
            ViewBag.Ameniti = _context.Amenitis.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Team = _context.Teams.ToList();
            ViewBag.HouseTypes = _context.HouseTypes.ToList();
            ViewBag.HouseStatuses = _context.HouseStatuses.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(House house)
        {
            if (!_context.Cities.Any(x => x.Id == house.CityId)) ModelState.AddModelError("CityId", "Cities not found!");
            if (!_context.Teams.Any(x => x.Id == house.TeamId)) ModelState.AddModelError("TeamId", "Team not found!");
            if (!_context.HouseTypes.Any(x => x.Id == house.HouseTypeId)) ModelState.AddModelError("HouseTypeId", "HouseType not found!");
            if (!_context.HouseStatuses.Any(x => x.Id == house.HouseStatusId)) ModelState.AddModelError("HouseStatusId", "HouseStatus not found!");

            house.HouseImages = new List<HouseImage>();
            house.HouseAmenitis = new List<HouseAmeniti>();
            foreach (var amenitiId in house.AmenitiIds)
            {
                Ameniti ameniti = _context.Amenitis.FirstOrDefault(x => x.Id == amenitiId);

                if (ameniti == null)
                {
                    ModelState.AddModelError("TagIds", "Tag not found!");
                    return View();
                }

                HouseAmeniti houseAmeniti = new HouseAmeniti
                {
                    AmenitiId = amenitiId
                };

                house.HouseAmenitis.Add(houseAmeniti);
            }

            if (house.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
            }
            else
            {
                if (house.PosterFile.ContentType != "image/png" && house.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (house.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                string newFileName = Guid.NewGuid().ToString() + house.PosterFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads/book", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    house.PosterFile.CopyTo(stream);
                }

                HouseImage poster = new HouseImage
                {
                    Image = newFileName,
                    PosterStatus = true,
                };
                house.HouseImages.Add(poster);
            }


            if (house.ImageFiles != null)
            {
                foreach (var file in house.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    HouseImage image = new HouseImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/house", file)
                    };

                    house.HouseImages.Add(image);
                }
            }

            if (!ModelState.IsValid) return View();
            _context.House.Add(house);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

       /* public IActionResult Edit(int id)
        {
            var house = _context.House.Include(x => x.HouseAmenitis).Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).FirstOrDefault(x => x.Id == id);
            if (house == null) return NotFound();
            return View(house);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(House house)
        {
          
            House existHouse = _context.House.Include(x => x.HouseAmenitis).Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).FirstOrDefault(x => x.Id == house.Id); 

             
        }*/
    }
}
