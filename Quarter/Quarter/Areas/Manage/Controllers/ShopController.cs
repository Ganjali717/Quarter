using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin,SuperAdmin")]
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
        public IActionResult Index(int page = 1, string search = null, int? cityId = null, string sort = null)
        {
            ViewBag.Cities = _context.Cities.ToList();
            var query = _context.House.Include(x => x.HouseAmenitis).Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).AsQueryable();

            ViewBag.CurrentSearch = search;
            ViewBag.CurrentCityId = cityId;
            ViewBag.CurrentSort = sort;


            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Location.Contains(search) || x.HouseAmenitis.Any(x => x.Ameniti.Name.Contains(search)));

            if (cityId != null)
                query = query.Where(x => x.CityId == cityId);

            switch (sort)
            {
                case "price":
                    query = query.OrderBy(x => x.SalePrice);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(x => x.SalePrice);
                    break;
                default:
                    query = query.OrderByDescending(x => x.Id);
                    break;
            }


            var pagenatedHouses =  PagenatedList<House>.Create(query.Include(x => x.HouseAmenitis).Include(x => x.HouseImages).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City), 4, page);

            return View(pagenatedHouses);
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
                string path = Path.Combine(_env.WebRootPath, "uploads/house", newFileName);

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


        public IActionResult Edit(int id)
        {
            House house = _context.House.Include(b => b.HouseImages).Include(t => t.HouseAmenitis).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).FirstOrDefault(x => x.Id == id);
            ViewBag.Ameniti = _context.Amenitis.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Team = _context.Teams.ToList();
            ViewBag.HouseTypes = _context.HouseTypes.ToList();
            ViewBag.HouseStatuses = _context.HouseStatuses.ToList();
            house.AmenitiIds = house.HouseAmenitis.Select(x => x.AmenitiId).ToList();
            if (house == null) return NotFound();
            return View(house);
        }

        [HttpPost]
        public IActionResult Edit(House house)
        {
            House existHouse = _context.House.Include(b => b.HouseImages).Include(t => t.HouseAmenitis).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).FirstOrDefault(x => x.Id == house.Id);

            ViewBag.Ameniti = _context.Amenitis.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Team = _context.Teams.ToList();
            ViewBag.HouseTypes = _context.HouseTypes.ToList();
            ViewBag.HouseStatuses = _context.HouseStatuses.ToList();    

            if (existHouse == null) return View();
            house.HouseImages = existHouse.HouseImages;

            if (!_context.Cities.Any(x => x.Id == house.CityId)) ModelState.AddModelError("CityId", "Cities not found!");
            if (!_context.Teams.Any(x => x.Id == house.TeamId)) ModelState.AddModelError("TeamId", "Team not found!");
            if (!_context.HouseTypes.Any(x => x.Id == house.HouseTypeId)) ModelState.AddModelError("HouseTypeId", "HouseType not found!");
            if (!_context.HouseStatuses.Any(x => x.Id == house.HouseStatusId)) ModelState.AddModelError("HouseStatusId", "HouseStatus not found!");

            foreach (var item in house.AmenitiIds)
            {
                if (!_context.Amenitis.Any(x => x.Id == item)) ModelState.AddModelError("AmenitiIds", "Ameniti not found!");
            }
           


            if (!ModelState.IsValid) return View(house);

           

            if (house.PosterFile != null)
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

                HouseImage poster = existHouse.HouseImages.FirstOrDefault(x => x.PosterStatus == true);
                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/house", house.PosterFile);

                if (poster == null)
                {
                    poster = new HouseImage
                    {
                        PosterStatus = true,
                        Image = newFileName,
                        HouseId = house.Id
                    };

                    _context.HouseImages.Add(poster);
                }
                else
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/house", existHouse.HouseImages.FirstOrDefault(x => x.PosterStatus == true).Image);
                    poster.Image = newFileName;
                }
            }


           /* existHouse.HouseAmenitis.RemoveAll((x => !house.AmenitiIds.Contains(x.AmenitiId)));*/

            if (house.AmenitiIds != null)
            {
                foreach (var amenitiId in house.AmenitiIds.Where(x => !existHouse.HouseAmenitis.Any(bt => bt.AmenitiId == x)))
                {
                    HouseAmeniti houseAmeniti = new HouseAmeniti
                    {
                        AmenitiId = amenitiId,
                        HouseId = house.Id
                    };
                    existHouse.HouseAmenitis.Add(houseAmeniti);
                }
            }

           /* existHouse.HouseImages.RemoveAll(x => x.PosterStatus == null && !house.HouseImageIds.Contains(x.Id));*/

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

                    existHouse.HouseImages.Add(image);
                }
            }

            existHouse.Area = house.Area;
            existHouse.Baths = house.Baths;
            existHouse.Beds = house.Beds;
            existHouse.CityId = house.CityId;
            existHouse.CurrentFloor = house.CurrentFloor;
            existHouse.Floor = house.Floor;
            existHouse.Desc = house.Desc;
            existHouse.Date = house.Date;
            existHouse.HouseTypeId = house.HouseTypeId;
            existHouse.HouseStatusId = house.HouseStatusId;
            existHouse.IsFeatured = house.IsFeatured;
            existHouse.IsRelated = house.IsRelated;
            existHouse.IsPopular = house.IsPopular;
            existHouse.Location = house.Location;
            existHouse.YearBuilt = house.YearBuilt;
            existHouse.TeamId = house.TeamId;
            existHouse.Rate = house.Rate;
            existHouse.Rooms = house.Rooms;
            existHouse.SalePrice = house.SalePrice;
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteHouseFetch(int id)
        {
            House house = _context.House.Include(b => b.HouseImages).Include(t => t.HouseAmenitis).Include(x => x.HouseStatus).Include(x => x.HouseType).Include(x => x.Team).Include(x => x.City).FirstOrDefault(x => x.Id == id);
            if (house == null) return Json(new { status = 404 });

            try
            {
                _context.House.Remove(house);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }


        public IActionResult Comment(int id)
        {
            House house = _context.House.Include(x => x.Comments).FirstOrDefault(x => x.Id == id);

            if (house == null) return NotFound();

            return View(house);  
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.Include(x => x.House).FirstOrDefault(x => x.Id == id);

            if (comment == null) return NotFound();

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
