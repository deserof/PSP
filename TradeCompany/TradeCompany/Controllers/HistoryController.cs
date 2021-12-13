using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeCompany.Infrastructure.Services.Histories;
using TradeCompany.Models;

namespace TradeCompany.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
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
