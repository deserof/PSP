using AutoMapper;
using FuelGarage.Domain.ViewModels;
using FuelGarage.Infrastructure.Services.Orders;
using FuelGarage.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FuelGarage.Controllers
{
    [Authorize(Roles = "driver")]
    public class DriverController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public DriverController(
            IUserService userService,
            IOrderService orderService,
            IMapper mapper)
        {
            _userService = userService;
            _orderService = orderService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var user = _userService.GetByEmail(email);
            var orders = _orderService.GetAll().Where(x => x.DriverId == user.Id);
            var orderViewModels = _mapper.Map<IEnumerable<DriverOrderViewModel>>(orders);

            return View(orderViewModels);
        }
    }
}
