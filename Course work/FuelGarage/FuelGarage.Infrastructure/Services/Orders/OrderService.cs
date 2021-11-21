using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public List<Order> GetAll()
        {
            var orders = _dbContext.Orders.Include(x => x.Status)
                .Include(x => x.Fuel)
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .ToList();

            return orders;
        }
    }
}
