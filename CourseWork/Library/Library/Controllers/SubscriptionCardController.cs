using Library.Entities;
using Library.Infrastructure.Services.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class SubscriptionCardController : Controller
    {
        private protected ISubscriptionCardService _subscriptionCardService;
        private protected IReaderListService _readerListService;
        private protected ICatalogCardService _catalogCardService;

        public SubscriptionCardController(
            ISubscriptionCardService subscriptionCardService,
             IReaderListService readerListService,
             ICatalogCardService catalogCardService)
        {
            _subscriptionCardService = subscriptionCardService;
            _readerListService = readerListService;
            _catalogCardService = catalogCardService;
        }

        public IActionResult List()
        {
            var subscriptionCardViewModels = new List<SubscriptionCardViewModel>();
            var models = _subscriptionCardService.GetAll();

            foreach (var model in models)
            {
                var catalogCardViewModel = new SubscriptionCardViewModel()
                {
                    Id = model.Id,
                    CatalogCardId  = model.CatalogCardId,
                    ReaderListId = model.ReaderListId,
                    IssueDate = model.IssueDate,
                    ReturnDate = model.ReturnDate ?? null,
                    BookNameAndBookAuthor = model.CatalogCard.Book.Name + " - " + model.CatalogCard.Book.Author,
                    LMF = model.ReaderList.LastName + " " + model.ReaderList.FirstName + " " + model.ReaderList.MiddleName
                };
                subscriptionCardViewModels.Add(catalogCardViewModel);
            }

            return View(subscriptionCardViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var readers = _readerListService.GetAll();
            var catalogs = _catalogCardService.GetAll();
            var readersViewModels = new List<ReaderListViewModel>();
            var catalogViewModels = new List<CatalogCardViewModel>();
            foreach (var reader in readers)
            {
                var readerView = new ReaderListViewModel()
                {
                    Id = reader.Id,
                    FLM = reader.LastName + " " + reader.FirstName + " " + reader.MiddleName
                };
                readersViewModels.Add(readerView);
            }

            foreach (var catalog in catalogs)
            {
                if (_catalogCardService.IsBookGreaterThenZero(catalog.Id))
                {
                    var catalogView = new CatalogCardViewModel()
                    {
                        Id = catalog.Id,
                        BookNameAndAuthor = catalog.Book.Name + " - " + catalog.Book.Author
                    };
                    catalogViewModels.Add(catalogView);
                }
            }

            ViewBag.Reader = new SelectList(readersViewModels, "Id", "FLM");
            ViewBag.Catalog = new SelectList(catalogViewModels, "Id", "BookNameAndAuthor");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubscriptionCard model)
        {
            var catalogId = model.CatalogCardId;
            _catalogCardService.MinusBook(catalogId);
            _subscriptionCardService.Create(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _subscriptionCardService.GetById(id);
            var readers = _readerListService.GetAll();
            var catalogs = _catalogCardService.GetAll();
            var readersViewModels = new List<ReaderListViewModel>();
            var catalogViewModels = new List<CatalogCardViewModel>();
            foreach (var reader in readers)
            {
                var readerView = new ReaderListViewModel()
                {
                    Id = reader.Id,
                    FLM = reader.LastName + " " + reader.FirstName + " " + reader.MiddleName
                };
                readersViewModels.Add(readerView);
            }

            foreach (var catalog in catalogs)
            {
                var catalogView = new CatalogCardViewModel()
                {
                    Id = catalog.Id,
                    BookNameAndAuthor = catalog.Book.Name + " - " + catalog.Book.Author
                };
                catalogViewModels.Add(catalogView);
            }
            ViewBag.Catalog = new SelectList(catalogViewModels, "Id", "BookNameAndAuthor");
            ViewBag.Reader = new SelectList(readersViewModels, "Id", "FLM");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SubscriptionCard model)
        {
            _subscriptionCardService.Edit(model);

            //if()

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _catalogCardService.PlusBook(_subscriptionCardService.GetById(id).CatalogCardId);
            _subscriptionCardService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
