﻿using FuelGarage.Infrastructure.Services.Users;
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
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            SetLayout();

            return View();
        }

        public IActionResult AboutUs()
        {
            SetLayout();

            return View();
        }

        private void SetLayout()
        {
            ViewBag.Layout = "_AnonymousLayout";

            if (User.Identity.IsAuthenticated)
            {
                var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                var role = _userService.GetUserRoleByEmail(email);

                if (role == "customer")
                {
                    ViewBag.Layout = "_CustomerLayout";
                }

                if (role == "admin")
                {
                    ViewBag.Layout = "_AdminLayout";
                }

                if (role == "driver")
                {
                    ViewBag.Layout = "_DriverLayout";
                }
            }
        }
    }
}
