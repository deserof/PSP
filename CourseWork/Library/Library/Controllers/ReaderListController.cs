using Library.Entities;
using Library.Infrastructure.Services.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReaderListController : Controller
    {
        private protected IReaderListService _readerListService;

        public ReaderListController(IReaderListService readerListService)
        {
            _readerListService = readerListService;
        }

        public IActionResult List()
        {
            var model = _readerListService.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReaderListViewModel model)
        {
            var reader = new ReaderList()
            {
                Address = model.Address,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName
            };

            _readerListService.Create(reader);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reader = _readerListService.GetById(id);
            var model = new ReaderListViewModel()
            {
                Id = reader.Id,
                Address = reader.Address,
                FirstName = reader.Address,
                MiddleName = reader.MiddleName,
                LastName = reader.LastName
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ReaderListViewModel model)
        {
            var reader = new ReaderList()
            {
                Id = model.Id,
                Address = model.Address,
                FirstName = model.Address,
                MiddleName = model.MiddleName,
                LastName = model.LastName
            };
            _readerListService.Edit(reader);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _readerListService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
