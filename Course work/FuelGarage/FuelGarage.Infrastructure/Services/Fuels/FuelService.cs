using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            return _dbContext.Fuels.ToList();
        }

        public void Create(Fuel fuel)
        {
            _dbContext.Fuels.Add(fuel);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var fuel = _dbContext.Fuels.Where(x => x.Id == id).FirstOrDefault();
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
            return _dbContext.Fuels.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
