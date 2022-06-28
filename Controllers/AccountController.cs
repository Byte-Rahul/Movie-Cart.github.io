﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Cart.Data;
using Movie_Cart.Data.Static;
using Movie_Cart.Data.ViewModels;
using Movie_Cart.Models;

namespace Movie_Cart.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _db;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _db.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login()=> View(new LoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user!= null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong credentials Please try again";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials Please try again";
            return View(loginVM);
        }
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if(user!=null)
            {
                TempData["Error"] = "This email is already registered";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser,registerVM.Password);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("RegisterCompleted");

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

    }
}
