using FuelGarage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FuelGarage.Domain.ViewModels;
using FuelGarage.Infrastructure.Services.Orders;
using FuelGarage.Infrastructure.Services.Users;

namespace FuelGarage.Controllers
{
    [Authorize(Roles = "driver")]
    public class DriverController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public DriverController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            List<DriverOrderViewModel> orderViewModels = new List<DriverOrderViewModel>();
            var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var user = _userService.GetByEmail(email);

            var orders = _orderService.GetAll().Where(x=>x.DriverId==user.Id);
            foreach (var order in orders)
            {
                orderViewModels.Add(new DriverOrderViewModel
                {
                    Id = order.Id,
                    CustomerFirstName = order.Customer.FirstName,
                    CustomerLastName = order.Customer.LastName,
                    CustomerMiddleName = order.Customer.MiddleName,
                    CustomerPhone = order.Customer.Phone,
                    ApplicationTime = order.ApplicationTime,
                    FuelBrand = order.Fuel.Brand ?? string.Empty,
                    FuelQuantity = order.FuelQuantity,
                    LeadTime = order.LeadTime,
                    OrderAddress = order.OrderAddress,
                    OrderDescription = order.OrderDescription,
                    Status = order.Status?.StatusName ?? string.Empty
                });
            }

            return View(orderViewModels);
        }
    }
}
