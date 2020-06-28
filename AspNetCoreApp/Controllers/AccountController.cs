using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using AspNetCoreApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            User user = await _userService.GetByUserName(User.Identity.Name);
            EditModel model = new EditModel() 
            {
               Password = user.Password,
               Email = user.Email,
               TelegramId = user.TelegramId
            };
            return View((object)model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model) 
        {
            if (ModelState.IsValid) 
            {
                User user = await _userService.GetByCredentials(model.UserName, model.Password);
                if (user != null) 
                {
                    await Authenticate(user.UserName);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect credentials");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model) 
        {
            if (ModelState.IsValid)
            {
                User user = await _userService.GetByUserName(model.UserName);
                if (user == null) 
                {
                    User newUser = new User()
                    {
                        UserName = model.UserName,
                        Password = model.Password,
                        Email = model.Email,
                        TelegramId = model.TelegramId
                    };

                    await _userService.Create(newUser);

                    await Authenticate(model.UserName);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect credentials");
                }
            }
            
            return View(model);
        }


        private async Task Authenticate(string userName) 
        {
            // create one claim 
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // create object ClaimsIdentity 
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // install of auth-n cookies 
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOut() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(EditModel model) 
        {
            if (ModelState.IsValid) 
            {
                User user = await _userService.GetByUserName(User.Identity.Name);
                user.Email = model.Email;
                user.Password = model.Password;
                user.TelegramId = model.TelegramId;
                await _userService.Edit(user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Incorrect credentials");
            return View(model);
        }
    }
}
