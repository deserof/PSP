using ClosedXML.Excel;
using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FuelGarage.Infrastructure.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly GarageContext _dbContext;

        public OrderService(GarageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void EditFuel(int id, int fuelCount)
        {
            var order = GetById(id);
            order.FuelQuantity = fuelCount;
            _dbContext.Update(fuelCount);
            _dbContext.SaveChanges();
        }

        public void Create(Order order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public void Edit(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            var orders = _dbContext.Orders.Include(x => x.Status)
                .Include(x => x.Fuel)
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .AsNoTracking()
                .ToList();

            return orders;
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.Where(x => x.Id == id)
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .Include(x => x.Fuel)
                .Include(x => x.Status)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public List<Order> GetByCustomerId(int id)
        {
            return _dbContext.Orders
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .Include(x => x.Fuel)
                .Include(x => x.Status)
                .AsNoTracking()
                .Where(x => x.CustomerId == id).ToList();
        }

        public void EditStatusById(int id, int statusId, Status status)
        {
            var order = GetById(id);
            order.Status = status;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public XLWorkbook GenerateExcelReport()
        {
            var orders = GetAll();

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

            foreach (var order in orders)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = order.Customer?.FirstName ?? "нет данных";
                worksheet.Cell(currentRow, 2).Value = order.Customer?.LastName ?? "нет данных";
                worksheet.Cell(currentRow, 3).Value = order.Customer?.MiddleName ?? "нет данных";
                worksheet.Cell(currentRow, 4).Value = order.Customer?.Phone ?? "нет данных";
                worksheet.Cell(currentRow, 5).Value = order.OrderAddress ?? "нет данных";
                worksheet.Cell(currentRow, 6).Value = order.ApplicationTime;
                worksheet.Cell(currentRow, 7).Value = order.LeadTime;
                worksheet.Cell(currentRow, 8).Value = order.Fuel.Brand;
                worksheet.Cell(currentRow, 9).Value = order.FuelQuantity;
                worksheet.Cell(currentRow, 10).Value = order.Driver?.FirstName ?? "нет данных";
                worksheet.Cell(currentRow, 11).Value = order.Driver?.LastName ?? "нет данных";
                worksheet.Cell(currentRow, 12).Value = order.Driver?.MiddleName ?? "нет данных";
                worksheet.Cell(currentRow, 13).Value = order.Driver?.Phone ?? "нет данных";
            }

            return workbook;
        }
    }
}