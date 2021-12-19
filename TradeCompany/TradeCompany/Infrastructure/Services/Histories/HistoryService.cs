using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using TradeCompany.Infrastructure.Db;
using TradeCompany.Models;

namespace TradeCompany.Infrastructure.Services.Histories
{
    public class HistoryService : IHistoryService
    {
        private protected ProductCompanyContext Db;

        public HistoryService(ProductCompanyContext db)
        {
            Db = db;
        }

        public List<History> GetAll()
        {
            return Db.Histories
                .Include(x => x.Shop)
                .AsNoTracking()
                .ToList();
        }

        public void Create(History item)
        {
            Db.Add(item);
            Db.SaveChanges();
        }

        public void Edit(History item)
        {
            Db.Update(item);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            Db.Remove(item);
            Db.SaveChanges();
        }

        public History GetById(int id)
        {
            return Db.Histories
                .Include(x => x.Shop)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddProductById(string text, int id)
        {
            var his = GetById(id);

            if (string.IsNullOrEmpty(his.ProductName))
            {
                his.ProductName += $"{text}";
            }
            else
            {
                his.ProductName += $", {text}";
            }

            Db.Histories.Update(his);
            Db.SaveChanges();
        }

        public XLWorkbook GenerateExcelReport(int id)
        {
            var histories = GetAll();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Заказы");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Имя заказчика";
            worksheet.Cell(currentRow, 2).Value = "Фамилия заказчика";
            worksheet.Cell(currentRow, 3).Value = "Отчество заказчика";
            worksheet.Cell(currentRow, 4).Value = "Телефон заказчика";
            worksheet.Cell(currentRow, 5).Value = "Адрес";
            worksheet.Cell(currentRow, 6).Value = "Дата оформления";
            worksheet.Cell(currentRow, 7).Value = "Дата доставки";
            worksheet.Cell(currentRow, 8).Value = "Топливо";
            worksheet.Cell(currentRow, 9).Value = "Количество";
            worksheet.Cell(currentRow, 10).Value = "Имя водителя";
            worksheet.Cell(currentRow, 11).Value = "Фамилия водителя";
            worksheet.Cell(currentRow, 12).Value = "Отчество водителя";
            worksheet.Cell(currentRow, 13).Value = "Телефон водителя";

            foreach (var order in histories)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = order.Id;
                worksheet.Cell(currentRow, 2).Value = order.ProductName ;
                worksheet.Cell(currentRow, 3).Value = order.Shop?.Name ?? "no data";
                worksheet.Cell(currentRow, 3).Value = order.Shop?. ?? "no data";
                worksheet.Cell(currentRow, 3).Value = order.Shop?.Name ?? "no data";
                worksheet.Cell(currentRow, 4).Value = order.Date;
            }

            return workbook;
        }
    }
}
