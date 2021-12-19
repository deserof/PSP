using ClosedXML.Excel;
using FuelGarage.Domain.Entities;
using FuelGarage.Domain.ViewModels;
using System.Collections.Generic;

namespace FuelGarage.Infrastructure.Services.Orders
{
    public interface IOrderService
    {
        List<Order> GetAll();

        public void EditFuel(int id, int fuelCount);

        void Create(Order order);

        void Edit(Order order);

        void Delete(int id);

        Order GetById(int id);

        List<Order> GetByCustomerId(int id);

        void EditStatusById(int id, int statusId, Status status);

        XLWorkbook GenerateExcelReport(Report model);
    }
}
