using FuelGarage.Domain.Entities;
using FuelGarage.Domain.Enums;
using FuelGarage.Domain.ViewModels;
using FuelGarage.Infrastructure.Services.Fuels;
using FuelGarage.Infrastructure.Services.Orders;
using FuelGarage.Infrastructure.Services.Statuses;
using FuelGarage.Infrastructure.Services.Users;
using FuelGarage.Infrastructure.Services.Vehicles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelGarage.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private protected IFuelService _fuelService;
        private protected IOrderService _orderService;
        private protected IStatusService _statusService;
        private protected IUserService _userService;
        private protected IVehicleService _vehicleService;

        public AdminController(
            IFuelService fuelService,
            IOrderService orderService,
            IStatusService statusService,
            IUserService userService,
            IVehicleService vehicleService)
        {
            _fuelService = fuelService;
            _orderService = orderService;
            _statusService = statusService;
            _userService = userService;
            _vehicleService = vehicleService;
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
                    Customer = order.Customer.LastName + " " + order.Customer.FirstName[0] + ". " + order.Customer.MiddleName[0] + "." ?? string.Empty,
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
            return RedirectToAction("ListOrder");
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("ListOrder");
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var model = _orderService.GetById(id);
            var fuels = _fuelService.GetAll();
            var status = _statusService.GetAll();
            var driver = _userService.GetAll();
            ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
            ViewBag.Status = new SelectList(status, "Id", "StatusName");
            ViewBag.Driver = new SelectList(driver, "Id", "Brand");

            return View(model);
        }

        [HttpPost]
        public IActionResult EditOrder(Order model)
        {
            _orderService.Edit(model);
            return RedirectToAction("ListOrder");
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

        #region Customer

        [HttpGet]
        public IActionResult ListCustomer()
        {
            var users = _userService.GetAll();
            var models = new List<AdminCustomerViewModel>();
            foreach (var user in users)
            {
                var model = new AdminCustomerViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    Phone = user.Phone,
                    Role = user.Role.RoleName
                };
                models.Add(model);
            }
            var customers = models.Where(x => x.Role == "customer");
            return View(customers);
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(AdminCustomerViewModel model)
        {
            var user = new User()
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Phone = model.Phone,
                RoleId = (int)RoleType.Customer,
                UserPassword = model.Password
            };
            _userService.Create(user);
            return RedirectToAction("ListCustomer");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var user = _userService.GetById(id);
            var model = new AdminCustomerViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Role = user.Role.RoleName
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCustomer(AdminCustomerViewModel model)
        {
            var user = new User()
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Phone = model.Phone,
                RoleId = (int)RoleType.Customer
            };

            user.UserPassword = _userService.GetUserPassword(model.Id);
            _userService.Edit(user);
            return RedirectToAction("ListCustomer");
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("ListCustomer");
        }

        #endregion

        #region Driver

        [HttpGet]
        public IActionResult ListDriver()
        {
            var users = _userService.GetAll();
            var models = new List<AdminDriverViewModel>();
            foreach (var user in users)
            {
                var model = new AdminDriverViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    Phone = user.Phone,
                    Role = user.Role.RoleName,
                    Vehicle = user?.Vehicle?.Brand + " " + user.Vehicle?.Model ?? "без машины"
                };

                models.Add(model);
            }
            var drivers = models.Where(x => x.Role == "driver");
            return View(drivers);
        }

        [HttpGet]
        public IActionResult CreateDriver()
        {
            var vehicles = _vehicleService.GetAll();
            var models = new List<VehicleViewModel>();
            foreach (var veh in vehicles)
            {
                var model = new VehicleViewModel
                {
                    Id = veh.Id,
                    Name = veh.Brand + " " + veh.Model
                };
                models.Add(model);
            }
            ViewBag.Vehicle = new SelectList(models, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateDriver(AdminDriverViewModel model)
        {
            var user = new User
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Phone = model.Phone,
                RoleId = (int)RoleType.Driver,
                UserPassword = model.Password,
                VehicleId = model.VehicleId
            };
            _userService.Create(user);
            return RedirectToAction("ListDriver");
        }

        [HttpGet]
        public IActionResult EditDriver(int id)
        {
            var vehicles = _vehicleService.GetAll();
            var user = _userService.GetById(id);
            var model = new AdminDriverViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Role = user.Role.RoleName
            };
            var vehicleModels = new List<VehicleViewModel>();
            foreach (var veh in vehicles)
            {
                var vehicleModel = new VehicleViewModel
                {
                    Id = veh.Id,
                    Name = veh.Brand + " " + veh.Model
                };
                vehicleModels.Add(vehicleModel);
            }
            ViewBag.Vehicle = new SelectList(vehicleModels, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDriver(AdminDriverViewModel model)
        {
            var user = new User
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Phone = model.Phone,
                RoleId = (int)RoleType.Driver,
                UserPassword = _userService.GetUserPassword(model.Id),
                VehicleId = model.VehicleId
            };

            _userService.Edit(user);
            return RedirectToAction("ListDriver");
        }

        [HttpGet]
        public IActionResult DeleteDriver(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("ListDriver");
        }

        #endregion

        #region Vehicle

        [HttpGet]
        public IActionResult ListVehicle()
        {
            var vehicles = _vehicleService.GetAll();
            var models = new List<VehicleViewModel>();
            foreach (var vehicle in vehicles)
            {
                var model = new VehicleViewModel()
                {
                    Id = vehicle.Id,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult CreateVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVehicle(VehicleViewModel model)
        {
            var vehicle = new Vehicle
            {
                Id = model.Id,
                Brand = model.Brand,
                Model = model.Model
            };
            _vehicleService.Create(vehicle);
            return RedirectToAction("ListVehicle");
        }

        [HttpGet]
        public IActionResult EditVehicle(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            var model = new VehicleViewModel
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Model = vehicle.Model
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditVehicle(VehicleViewModel model)
        {
            var vehicle = new Vehicle
            {
                Id = model.Id,
                Brand = model.Brand,
                Model = model.Model
            };
            _vehicleService.Edit(vehicle);
            return RedirectToAction("ListVehicle");
        }

        [HttpGet]
        public IActionResult DeleteVehicle(int id)
        {
            _vehicleService.Delete(id);
            return RedirectToAction("ListVehicle");
        }

        #endregion
    }
}
