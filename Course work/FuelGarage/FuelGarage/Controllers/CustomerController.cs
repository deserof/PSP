﻿using AutoMapper;
using FuelGarage.Domain.Entities;
using FuelGarage.Domain.Enums;
using FuelGarage.Domain.ViewModels;
using FuelGarage.Infrastructure.Services.Fuels;
using FuelGarage.Infrastructure.Services.Orders;
using FuelGarage.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;

namespace FuelGarage.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IFuelService _fuelService;
        private readonly IMapper _mapper;

        public CustomerController(
            IOrderService orderService,
            IUserService userService,
            IFuelService fuelService,
            IMapper mapper)
        {
            _orderService = orderService;
            _userService = userService;
            _fuelService = fuelService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var user = _userService.GetByEmail(email);
            var orders = _orderService.GetByCustomerId(user.Id);
            var orderViewModels = _mapper.Map<IEnumerable<CustomerOrderViewModel>>(orders);

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
            if (!_fuelService.EraseFuel(model.FuelId, model.FuelQuantity) || model.FuelQuantity <= 0)
            {
                ModelState.AddModelError("", "У нас нет столько топлива :-(");
                var fuels = _fuelService.GetAll();
                ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
                return View();
            }

            var email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var user = _userService.GetByEmail(email);
            model.StatusId = (int)StatusType.Open;
            model.CustomerId = user.Id;
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
            var fuelCurrent = _orderService.GetById(model.Id).FuelQuantity;

            if (!_fuelService.EditFuelFromCustomer(model.FuelId, model.FuelQuantity, fuelCurrent) || model.FuelQuantity <= 0)
            {
                var fuels = _fuelService.GetAll();
                ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
                ModelState.AddModelError("", "У нас нет столько топлива :-(");
                ViewBag.Fuels = new SelectList(fuels, "Id", "Brand");
                return View(model);
            }

            _orderService.EditFuel(model.Id, model.FuelQuantity);
            model.StatusId = (int)StatusType.Open;
            _orderService.Edit(model);
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult DetailsOrder(int id)
        {
            var model = _orderService.GetById(id);
            var orderViewModel = _mapper.Map<CustomerOrderViewModel>(model);

            return View(orderViewModel);
        }
    }
}
