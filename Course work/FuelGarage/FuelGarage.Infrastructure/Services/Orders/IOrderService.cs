using FuelGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Infrastructure.Services.Orders
{
    public interface IOrderService
    {
        List<Order> GetAll();
    }
}
