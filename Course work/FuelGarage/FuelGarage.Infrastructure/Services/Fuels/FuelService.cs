using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FuelGarage.Infrastructure.Services.Fuels
{
    public class FuelService : IFuelService
    {
        private readonly GarageContext _dbContext;

        public FuelService(GarageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Fuel> GetAll()
        {
            return _dbContext.Fuels
                .AsNoTracking()
                .ToList();
        }

        public void Create(Fuel fuel)
        {
            _dbContext.Fuels.Add(fuel);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var fuel = _dbContext.Fuels.FirstOrDefault(x => x.Id == id);
            _dbContext.Fuels.Remove(fuel);
            _dbContext.SaveChanges();
        }

        public void Edit(Fuel fuel)
        {
            _dbContext.Fuels.Update(fuel);
            _dbContext.SaveChanges();
        }

        public Fuel GetById(int id)
        {
            return _dbContext.Fuels
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool EraseFuel(int id, int count)
        {
            var fuel = GetById(id);
            if (fuel.Quantity - count <= 0) return false;
            fuel.Quantity -= count;
            _dbContext.Update(fuel);
            _dbContext.SaveChanges();
            return true;
        }

        public bool EditFuelFromCustomer(int id, int count, int current)
        {
            var fuel = GetById(id);
            if (fuel.Quantity - (count - current) <= 0) return false;
            fuel.Quantity -= (count - current);
            _dbContext.Update(fuel);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
