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
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TeamViewModel teamVM = new TeamViewModel
            {
                Teams = _context.Teams.Include(x=>x.teamDetail).ToList()
            };
            return View(teamVM);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Services = _context.Services.ToList();
            var detail = _context.Teams.Include(x => x.teamDetail).FirstOrDefault(f => f.Id == id); 
            return View(detail);
        }
    }
}
