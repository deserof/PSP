using FuelGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Infrastructure.Services.Orders
{
    public interface IOrderService
    {
        List<Order> GetAll();

        void Create(Order order);

        void Edit(Order order);

        void Delete(int id);

        Order GetById(int id);

        List<Order> GetByCustomerId(int id);
    }
}
