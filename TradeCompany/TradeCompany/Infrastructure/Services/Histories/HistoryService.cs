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
            var histories = GetAll().Where(x=>x.Id==id);

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("history");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "#";
            worksheet.Cell(currentRow, 2).Value = "products";
            worksheet.Cell(currentRow, 3).Value = "shop name";
            worksheet.Cell(currentRow, 4).Value = "shop address";
            worksheet.Cell(currentRow, 5).Value = "date";

            foreach (var order in histories)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = order.Id;
                worksheet.Cell(currentRow, 2).Value = order.ProductName ;
                worksheet.Cell(currentRow, 3).Value = order.Shop?.Name ?? "no data";
                worksheet.Cell(currentRow, 4).Value = order.Shop?.Address ?? "no data";
                worksheet.Cell(currentRow, 5).Value = order.Date;
            }

            return workbook;
        }
    }
}
