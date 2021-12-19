using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradeCompany.Infrastructure.Services.Products;
using TradeCompany.Infrastructure.Services.Shops;
using TradeCompany.Infrastructure.Services.Statuses;
using TradeCompany.Models;
using TradeCompany.Infrastructure.Services.Histories;

namespace TradeCompany.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        private readonly IStatusService _statusService;
        private readonly IHistoryService _historyService;

        public ProductController(
            IProductService productService,
            IShopService shopService,
            IStatusService statusService,
            IHistoryService historyService)
        {
            _productService = productService;
            _shopService = shopService;
            _statusService = statusService;
            _historyService = historyService;
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
            ViewBag.Shop = new SelectList(_shopService.GetAll(), "Id", "Name");
            ViewBag.Status = new SelectList(_statusService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (_historyService.GetById(model.HistoryId) == null)
            {
                ModelState.AddModelError("", "history id doesn't exists");
                ViewBag.Shop = new SelectList(_shopService.GetAll(), "Id", "Name");
                ViewBag.Status = new SelectList(_statusService.GetAll(), "Id", "Name");
                return View(model);
            }

            _productService.Create(model);
            _historyService.AddProductById($"{model.Name} {model.Quantity} шт.", model.HistoryId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productService.GetById(id);
            ViewBag.Shop = new SelectList(_shopService.GetAll(), "Id", "Name");
            ViewBag.Status = new SelectList(_statusService.GetAll(), "Id", "Name");
            return View(model);
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
