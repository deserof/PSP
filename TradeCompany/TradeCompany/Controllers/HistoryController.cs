using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradeCompany.Infrastructure.Services.Histories;
using TradeCompany.Infrastructure.Services.Products;
using TradeCompany.Infrastructure.Services.Shops;
using TradeCompany.Models;

namespace TradeCompany.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;
        private readonly IShopService _shopService;
        private readonly IProductService _productService;

        public HistoryController(IHistoryService historyService, IShopService shopService, IProductService productService)
        {
            _historyService = historyService;
            _shopService = shopService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = _historyService.GetAll();

            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Shop = new SelectList(_shopService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(History model)
        {
            _historyService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(History model)
        {
            _historyService.Edit(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _historyService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
