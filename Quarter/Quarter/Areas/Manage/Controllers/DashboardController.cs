using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin,SuperAdmin")]
        [Area("manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
