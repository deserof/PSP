using FuelGarage.Domain.Entities;
using FuelGarage.Domain.Enums;
using FuelGarage.Domain.ViewModels;
using FuelGarage.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FuelGarage.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public JsonResult UserName()
        {
            UserEmail userEmail = new UserEmail();
            userEmail.Email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            return Json(userEmail);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUserByEmailAndPassword(model.Email, model.Password);

                if (user != null)
                {
                    var userRole = _userService.GetUserRoleByEmail(model.Email);
                    Authenticate(model.Email, userRole);

                    if (userRole == "customer")
                    {
                        return RedirectToAction("Index", "Customer");
                    }

                    if (userRole == "driver")
                    {
                        return RedirectToAction("Index", "Driver");
                    }

                    if (userRole == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetByEmail(model.Email);
                if (user == null)
                {
                    _userService.Create(new User
                    {
                        Email = model.Email,
                        UserPassword = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        Phone = model.Phone,
                        RoleId = (int)RoleType.Customer
                    });

                    var userRole = _userService.GetUserRoleByEmail(model.Email);
                    Authenticate(model.Email, userRole);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private void Authenticate(string userName, string userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
