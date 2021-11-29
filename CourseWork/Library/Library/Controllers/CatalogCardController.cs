using Library.Entities;
using Library.Infrastructure.Services.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CatalogCardController : Controller
    {
        private protected ICatalogCardService _catalogCardService;
        private protected IBookService _bookService;

        public CatalogCardController(
            ICatalogCardService catalogCardService,
            IBookService bookService)
        {
            _catalogCardService = catalogCardService;
            _bookService = bookService;
        }

        public IActionResult List()
        {
            var catalogCardViewModels = new List<CatalogCardViewModel>();
            var models = _catalogCardService.GetAll();

            foreach (var model in models)
            {
                var catalogCardViewModel = new CatalogCardViewModel()
                {
                    Id = model.Id,
                    QantityOfBook = model.QantityOfBook,
                    BookAuthor = model.Book.Author,
                    BookName = model.Book.Name
                };
                catalogCardViewModels.Add(catalogCardViewModel);
            }

            return View(catalogCardViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var books = _bookService.GetAll();
            ViewBag.Book = new SelectList(books, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CatalogCard model)
        {
            _catalogCardService.Create(model);
            
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _catalogCardService.GetById(id);
            var books = _bookService.GetAll();
            ViewBag.Book = new SelectList(books, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CatalogCard model)
        {
            _catalogCardService.Edit(model);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _catalogCardService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
