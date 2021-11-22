﻿using FuelGarage.Domain.Entities;
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
                 .FirstOrDefault();
        }

        public List<Order> GetByCustomerId(int id)
        {
            return _dbContext.Orders
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .Include(x => x.Fuel)
                .Include(x => x.Status)
                .Where(x => x.CustomerId == id).ToList();
        }
    }
}