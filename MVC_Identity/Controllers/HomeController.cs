﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Models;
using MVC_Identity.Models.DTO;
using MVC_Identity.Models.Entity;
using System.Diagnostics;

namespace MVC_Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager )
        {
            _logger = logger;
            _userManager= userManager;
            _signInManager= signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        //Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemi


                AppUser user = new AppUser
                {
                    UserName = register.Username,
                    Email = register.Email,

                };
                var result=await _userManager.CreateAsync(user,register.Password);

                if (result.Succeeded)
                {
                    //Identity Create
                    TempData["Success"] = $"{user.UserName} başarılı şekilde kaydoldu.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(register);
                }

                
            }
            else
            {
                return View(register);
            }
            
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(login.Email);
                if(user == null)
                {
                    TempData["Error"] = "Kullanıcı Bulunamadı.";
                    return View();
                }
                var result=await _signInManager.PasswordSignInAsync(user,login.Password,false,false);
                if (result.Succeeded)
                {
                    TempData["Success"] = $"{login.Email} başarıyla giriş yaptı.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(login);
                }
                
            }
            else
            {
                return View(login);
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}