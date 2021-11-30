using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FuelGarage.Domain.Entities;
using FuelGarage.Domain.Enums;
using FuelGarage.Domain.ViewModels;
using FuelGarage.Infrastructure.Services.Fuels;
using FuelGarage.Infrastructure.Services.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FuelGarage.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private protected IFuelService _fuelService;
        private protected IOrderService _orderService;

        public AdminController(IFuelService fuelService, IOrderService orderService)
        {
            _fuelService = fuelService;
            _orderService = orderService;

        }

        public IActionResult Index()
        {
            return View();
        }

#region Fuel

        [HttpGet]
        public IActionResult ListFuel()
        {
            var fuels = _fuelService.GetAll();
            var models = new List<FuelViewModel>();
            foreach (var fuel in fuels)
            {
                var model = new FuelViewModel()
                {
                    Id = fuel.Id,
                    Brand = fuel.Brand,
                    FuelDescription = fuel.FuelDescription,
                    Quantity = fuel.Quantity
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult CreateFuel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFuel(FuelViewModel model)
        {
            var fuel = new Fuel()
            {
                Id = model.Id,
                Brand = model.Brand,
                FuelDescription = model.FuelDescription,
                Quantity = model.Quantity
            };
            _fuelService.Create(fuel);
            return RedirectToAction("ListFuel");
        }

        [HttpGet]
        public IActionResult EditFuel(int id)
        {
            var fuel = _fuelService.GetById(id);
            var model = new FuelViewModel()
            {
                Id = fuel.Id,
                Brand = fuel.Brand,
                FuelDescription = fuel.FuelDescription,
                Quantity = fuel.Quantity
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditFuel(FuelViewModel model)
        {
            var fuel = new Fuel()
            {
                Id = model.Id,
                Brand = model.Brand,
                FuelDescription = model.FuelDescription,
                Quantity = model.Quantity
            };
            _fuelService.Edit(fuel);
            return RedirectToAction("ListFuel");
        }

        [HttpGet]
        public IActionResult DeleteFuel(int id)
        {
            _fuelService.Delete(id);
            return RedirectToAction("ListFuel");
        }
        #endregion

#region  Order
        [HttpGet]
        public IActionResult ListOrder()
        {
            List<AdminOrderViewModel> orderViewModels = new List<AdminOrderViewModel>();
            var orders = _orderService.GetAll();

            foreach (var order in orders)
            {
                orderViewModels.Add(new AdminOrderViewModel()
                {
                    Id = order.Id,
                    Customer = order.Customer.LastName+" "+ order.Customer.FirstName[0]+". "+order.Customer.MiddleName[0]+"." ?? string.Empty,
                    ApplicationTime = order.ApplicationTime,
                    FuelBrand = order.Fuel.Brand ?? string.Empty,
                    FuelQuantity = order.Fuel.Quantity,
                    LeadTime = order.LeadTime,
                    OrderAddress = order.OrderAddress,
                    OrderDescription = order.OrderDescription,
                    Status = order.Status?.StatusName ?? string.Empty
                });
            }

            return View(orderViewModels);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var fuels = _fuelService.GetAll();
            ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order model)
        {
            //var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            //var user = _userService.GetByEmail(email);
            //model.StatusId = (int)StatusType.Open;
            //model.CustomerId = user.Id;
            _orderService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var model = _orderService.GetById(id);
            var fuels = _fuelService.GetAll();
            ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");

            return View(model);
        }

        [HttpPost]
        public IActionResult EditOrder(Order model)
        {
            model.StatusId = (int)StatusType.Open;
            _orderService.Edit(model);
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult DetailsOrder(int id)
        {
            var model = _orderService.GetById(id);

            AdminOrderViewModel orderViewModel = new AdminOrderViewModel()
            {
                Id = model.Id,
                ApplicationTime = model.ApplicationTime,
                DriverFirstName = model.Driver?.FirstName ?? string.Empty,
                DriverLastName = model.Driver?.LastName ?? string.Empty,
                DriverMiddleName = model.Driver?.MiddleName ?? string.Empty,
                DriverPhone = model.Driver?.Phone ?? string.Empty,
                FuelBrand = model.Fuel.Brand ?? string.Empty,
                FuelQuantity = model.Fuel.Quantity,
                LeadTime = model.LeadTime,
                OrderAddress = model.OrderAddress,
                OrderDescription = model.OrderDescription,
                Status = model.Status?.StatusName ?? string.Empty
            };

            return View(orderViewModel);
        }
        #endregion
    }
}
