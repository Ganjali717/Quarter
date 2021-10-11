using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.Include(x => x.teamDetail).ToList();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (team.FileImage != null)
            {
                if (team.FileImage.ContentType != "image/jpeg" && team.FileImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (team.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }


                string filename = team.FileImage.FileName;
                if (filename.Length > 64)
                {
                    filename = filename.Substring(filename.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + filename;

                string path = Path.Combine(_env.WebRootPath, "uploads/team", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    team.FileImage.CopyTo(stream);
                }

                team.Image = newFileName;
            }

            _context.Add(team);
            _context.SaveChanges();
            return RedirectToAction("index");

        }


        public IActionResult Edit(int id)
        {
            Team team = _context.Teams.Include(x => x.teamDetail).FirstOrDefault(x => x.Id == id);
            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Team team)
        {
            Team existTeam = _context.Teams.Include(x => x.teamDetail).FirstOrDefault(x => x.Id == team.Id);

            if (existTeam == null) return NotFound();

            existTeam.Fullname = team.Fullname;
            existTeam.teamDetail.Experience = team.teamDetail.Experience;
            existTeam.teamDetail.Email = team.teamDetail.Email;
            existTeam.teamDetail.PhoneNumber = team.teamDetail.PhoneNumber;
            existTeam.teamDetail.Desc = team.teamDetail.Desc;
            if (team.FileImage != null)
            {
                if (team.FileImage.ContentType != "image/jpeg" && team.FileImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (team.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }


                string filename = team.FileImage.FileName;
                if (filename.Length > 64)
                {
                    filename = filename.Substring(filename.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + filename;

                string path = Path.Combine(_env.WebRootPath, "uploads/team", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    team.FileImage.CopyTo(stream);
                }

                if (existTeam.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/team", existTeam.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }


                existTeam.Image = newFileName;
            }
            else if (team.Image == null && existTeam.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/team", existTeam.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existTeam.Image = null;
            }

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult DeleteFetch(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return Json(new { status = 404 });

            try
            {
                _context.Teams.Remove(team);
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
