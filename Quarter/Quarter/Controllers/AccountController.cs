using Microsoft.AspNetCore.Identity;
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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            /*AppUser member = new AppUser
            {
                UserName = "Ganjali717",
                FullName = "Ganjali Imanov"
            };

            var result = await _userManager.CreateAsync(member, "Genceli717");*/

            /*     IdentityRole role1 = new IdentityRole("SuperAdmin");
                 await _roleManager.CreateAsync(role1);
                 IdentityRole role2 = new IdentityRole("Admin");
                 await _roleManager.CreateAsync(role2);
                 IdentityRole role3 = new IdentityRole("Member");
                 await _roleManager.CreateAsync(role3);*/

         /*   AppUser admin = new AppUser
            {
                UserName = "SuperAdmin",
                FullName = "Ali Imanov"
            };

            var result = await _userManager.CreateAsync(admin, "admin123");*/

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(registerVM.UserName);

            if (member != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            member = await _userManager.FindByEmailAsync(registerVM.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }

            member = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(member, "Member");
            await _signInManager.SignInAsync(member, true);

            return RedirectToAction("index", "home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();


            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == loginVM.UserName && x.IsAdmin == false);

            if (member == null)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(member, loginVM.Password, loginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }

            return RedirectToAction("index", "home");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }

        public IActionResult ShowAccount(string id)
        {

            AppUser appUsers = _context.AppUsers.FirstOrDefault(x => x.Id == id);
           
            return View(appUsers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowAccount(AppUser appUser)
        {
            AppUser existUser = _context.AppUsers.FirstOrDefault(x => x.Id == appUser.Id);

            if (!ModelState.IsValid) return View();

            existUser.FullName = appUser.FullName ?? existUser.FullName;
            existUser.Email = appUser.Email ?? existUser.Email;
            existUser.UserName = appUser.UserName ?? existUser.UserName;

            _context.SaveChanges();

            return RedirectToAction("index", "home");
        }


    }
}
