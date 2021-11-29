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
    public class BookController : Controller
    {
        private protected IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult List()
        {
            var book = _bookService.GetAll();
            
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            var book = new Book()
            {
                Author = model.Author,
                Name = model.Name,
                Pages = model.Pages
            };

             _bookService.Create(book);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookService.GetById(id);

            var model = new BookViewModel()
            {
                Author = book.Author,
                Name = book.Name,
                Pages = book.Pages
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            var book = new Book()
            {
                Id = model.Id,
                Author = model.Author,
                Name = model.Name,
                Pages = model.Pages
            };

            _bookService.Edit(book);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
