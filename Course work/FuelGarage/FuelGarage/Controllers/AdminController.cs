using AutoMapper;
using ClosedXML.Excel;
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
using System.IO;
using System.Linq;

namespace FuelGarage.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IFuelService _fuelService;
        private readonly IOrderService _orderService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;
        private XLWorkbook _file;

        public AdminController(
            IFuelService fuelService,
            IOrderService orderService,
            IStatusService statusService,
            IUserService userService,
            IVehicleService vehicleService,
            IMapper mapper)
        {
            _fuelService = fuelService;
            _orderService = orderService;
            _statusService = statusService;
            _userService = userService;
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        #region NewOrder

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderService.GetAll().Where(x => x.DriverId is null && x.StatusId == (int)StatusType.Open);
            var status = _statusService.GetAll();
            var newOrders = _mapper.Map<IEnumerable<NewOrderViewModel>>(orders);
            ViewBag.Status = new SelectList(status, "Id", "StatusName");
            return View(newOrders);
        }

        [HttpPost]
        public IActionResult Index(NewOrderViewModel item)
        {
            var status = _statusService.GetAll().FirstOrDefault(x => x.Id == item.StatusId);
            _orderService.EditStatusById(item.Id, item.StatusId, status);
            return RedirectToAction("Index");
        }

        #endregion

        #region Fuel

        [HttpGet]
        public IActionResult ListFuel()
        {
            var fuels = _fuelService.GetAll();
            var models = _mapper.Map<IEnumerable<FuelViewModel>>(fuels);
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
            var fuel = _mapper.Map<Fuel>(model);
            _fuelService.Create(fuel);
            return RedirectToAction("ListFuel");
        }

        [HttpGet]
        public IActionResult EditFuel(int id)
        {
            var fuel = _fuelService.GetById(id);
            var model = _mapper.Map<FuelViewModel>(fuel);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditFuel(FuelViewModel model)
        {
            var fuel = _mapper.Map<Fuel>(model);
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

        public IActionResult ListOrder(string sortOrder, string search)
        {
            var orders = _orderService.GetAll();
            var orderViewModels = _mapper.Map<IEnumerable<AdminOrderViewModel>>(orders);
            if (!string.IsNullOrEmpty(search))
            {
                orderViewModels = orderViewModels
                    .Where(s => s.Status.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || s.CustomerFirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || s.CustomerLastName.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || s.CustomerMiddleName.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || s.CustomerPhone.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || s.OrderAddress.Contains(search, StringComparison.InvariantCultureIgnoreCase));
            }

            orderViewModels = sortOrder switch
            {
                "customer_desc" => orderViewModels.OrderByDescending(s => s.Customer),
                "customer_asc" => orderViewModels.OrderBy(s => s.Customer),
                "fuel_desc" => orderViewModels.OrderByDescending(s => s.FuelBrand),
                "fuel_asc" => orderViewModels.OrderBy(s => s.FuelBrand),
                "quantity_desc" => orderViewModels.OrderByDescending(s => s.FuelQuantity),
                "quantity_asc" => orderViewModels.OrderBy(s => s.FuelQuantity),
                "status_desc" => orderViewModels.OrderByDescending(s => s.Status),
                "status_asc" => orderViewModels.OrderBy(s => s.Status),
                "address_desc" => orderViewModels.OrderByDescending(s => s.OrderAddress),
                "address_asc" => orderViewModels.OrderBy(s => s.OrderAddress),
                "app_date_desc" => orderViewModels.OrderByDescending(s => s.ApplicationTime),
                "app_date_asc" => orderViewModels.OrderBy(s => s.ApplicationTime),
                "lead_date_desc" => orderViewModels.OrderByDescending(s => s.LeadTime),
                "lead_date_asc" => orderViewModels.OrderBy(s => s.LeadTime),
                _ => orderViewModels.OrderBy(s => s.ApplicationTime)
            };

            return View(orderViewModels);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var fuels = _fuelService.GetAll();
            ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
            return View();
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
            var drivers = _userService.GetAll().Where(x => x.Role.RoleName == "driver");
            var driverModels = _mapper.Map<IEnumerable<DriverFullNameViewModel>>(drivers);

            ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
            ViewBag.Status = new SelectList(status, "Id", "StatusName");
            ViewBag.Driver = new SelectList(driverModels, "Id", "Name");

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
            var orderViewModel = _mapper.Map<AdminOrderViewModel>(model);

            return View(orderViewModel);
        }

        #endregion

        #region Customer

        [HttpGet]
        public IActionResult ListCustomer()
        {
            var users = _userService.GetAll();
            var models = _mapper.Map<IEnumerable<AdminCustomerViewModel>>(users);
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
            var user = _mapper.Map<User>(model);
            user.RoleId = (int)RoleType.Customer;
            _userService.Create(user);

            return RedirectToAction("ListCustomer");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var user = _userService.GetById(id);
            var model = _mapper.Map<AdminCustomerViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCustomer(AdminCustomerViewModel model)
        {
            var user = _mapper.Map<User>(model);
            user.RoleId = (int)RoleType.Customer;
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
            var models = _mapper.Map<IEnumerable<AdminDriverViewModel>>(users);
            var drivers = models.Where(x => x.Role == "driver");
            return View(drivers);
        }

        [HttpGet]
        public IActionResult CreateDriver()
        {
            var vehicles = _vehicleService.GetAll();
            var models = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);
            ViewBag.Vehicle = new SelectList(models, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateDriver(AdminDriverViewModel model)
        {
            var user = _mapper.Map<User>(model);
            user.RoleId = (int)RoleType.Driver;
            _userService.Create(user);
            return RedirectToAction("ListDriver");
        }

        [HttpGet]
        public IActionResult EditDriver(int id)
        {
            var vehicles = _vehicleService.GetAll();
            var user = _userService.GetById(id);
            var model = _mapper.Map<AdminDriverViewModel>(user);
            var vehicleModels = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);
            ViewBag.Vehicle = new SelectList(vehicleModels, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDriver(AdminDriverViewModel model)
        {
            var user = _mapper.Map<User>(model);
            user.RoleId = (int)RoleType.Driver;
            user.UserPassword = _userService.GetUserPassword(model.Id);
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
            var models = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);
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
            var vehicle = _mapper.Map<Vehicle>(model);
            _vehicleService.Create(vehicle);
            return RedirectToAction("ListVehicle");
        }

        [HttpGet]
        public IActionResult EditVehicle(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            var model = _mapper.Map<VehicleViewModel>(vehicle);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditVehicle(VehicleViewModel model)
        {
            var vehicle = _mapper.Map<Vehicle>(model);
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

        #region ExcelReport

        [HttpGet]
        public IActionResult ExcelReport()
        {
            var users = _userService.GetAll();
            var models = _mapper.Map<IEnumerable<CustomerFullName>>(users);
            var customers = models.Where(x => x.Role == "customer");
            ViewBag.Clients = new SelectList(customers, "Id", "FullName");
            return View();
        }

        [HttpGet]
        public IActionResult DownloadExcelReport(Report model)
        {
            var file = _orderService.GenerateExcelReport(model);

            using var stream = new MemoryStream();
            file.SaveAs(stream);
            var content = stream.ToArray();

            file.Dispose();
            return File(content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Report.xlsx");
        }

        #endregion
    }
}
