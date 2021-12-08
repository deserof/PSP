using ClosedXML.Excel;
using Library.Entities;
using Library.Infrastructure.Db;
using Library.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services.Implementations
{
    public class SubscriptionCardService : ISubscriptionCardService
    {
        private protected LibraryContext _db;

        public SubscriptionCardService(LibraryContext db)
        {
            _db = db;
        }

        public void Create(SubscriptionCard item)
        {
            _db.SubscriptionCards.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.SubscriptionCards.Where(x => x.Id == id).FirstOrDefault();
            _db.SubscriptionCards.Remove(item);
            _db.SaveChanges();
        }

        public void Edit(SubscriptionCard item)
        {
            _db.SubscriptionCards.Update(item);
            _db.SaveChanges();
        }

        public List<SubscriptionCard> GetAll()
        {
            return _db.SubscriptionCards
                .Include(x=>x.ReaderList)
                .Include(x=>x.CatalogCard)
                .Include(x=>x.CatalogCard.Book)
                .ToList();
        }

        public SubscriptionCard GetById(int id)
        {
            return _db.SubscriptionCards.Where(x => x.Id == id).FirstOrDefault();
        }

        public XLWorkbook GenerateReport()
        {
            var books = GetAll();

            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Заказы");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Имя";
            worksheet.Cell(currentRow, 2).Value = "Фамилия";
            worksheet.Cell(currentRow, 3).Value = "Отчество";
            worksheet.Cell(currentRow, 4).Value = "Адрес";
            worksheet.Cell(currentRow, 5).Value = "Автор книги";
            worksheet.Cell(currentRow, 6).Value = "Название книги";
            worksheet.Cell(currentRow, 7).Value = "Дата выдачи";
            worksheet.Cell(currentRow, 8).Value = "Дата возврата";

            foreach (var book in books)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = book.ReaderList.FirstName ?? "нет данных";
                worksheet.Cell(currentRow, 2).Value = book.ReaderList.LastName ?? "нет данных";
                worksheet.Cell(currentRow, 3).Value = book.ReaderList.MiddleName ?? "нет данных";
                worksheet.Cell(currentRow, 4).Value = book.ReaderList.Address ?? "нет данных";
                worksheet.Cell(currentRow, 5).Value = book.CatalogCard.Book.Author ?? "нет данных";
                worksheet.Cell(currentRow, 6).Value = book.CatalogCard.Book.Name ?? "нет данных";
                worksheet.Cell(currentRow, 7).Value = book.IssueDate;
                worksheet.Cell(currentRow, 8).Value = book.ReturnDate;
            }

            return workbook;
        }
    }
}
