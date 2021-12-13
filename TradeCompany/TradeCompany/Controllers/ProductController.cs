using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeCompany.Infrastructure.Services.Products;
using TradeCompany.Infrastructure.Services.Shops;
using TradeCompany.Infrastructure.Services.Statuses;
using TradeCompany.Models;

namespace TradeCompany.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly IStatusService _statusService;

        public ProductController(IProductService productService,
            IShopService shopService,
            IStatusService statusService)
        {
            _productService = productService;
            _shopService = shopService;
            _statusService = statusService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = _productService.GetAll();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Shop = _shopService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            _productService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.Shop = _shopService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            _productService.Edit(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
