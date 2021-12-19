using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeCompany.Infrastructure.Services.Shops;
using TradeCompany.Models;

namespace TradeCompany.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = _shopService.GetAll();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Shop model)
        {
            _shopService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _shopService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Shop model)
        {
            _shopService.Edit(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _shopService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _shopService.GetById(id);
            return View(model);
        }
    }
}
