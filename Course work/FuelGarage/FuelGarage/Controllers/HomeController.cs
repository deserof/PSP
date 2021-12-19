using FuelGarage.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (!User.Identity.IsAuthenticated) return;

            var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var role = _userService.GetUserRoleByEmail(email);

            switch (role)
            {
                case "customer":
                    ViewBag.Layout = "_CustomerLayout";
                    break;
                case "admin":
                    ViewBag.Layout = "_AdminLayout";
                    break;
                case "driver":
                    ViewBag.Layout = "_DriverLayout";
                    break;
            }
        }
    }
}
