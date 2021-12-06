using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using System.Collections.Generic;
using System.Linq;

namespace FuelGarage.Infrastructure.Services.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly GarageContext _dbContext;

        public VehicleService(GarageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Vehicle> GetAll()
        {
            return _dbContext.Vehicles.ToList();
        }

        public void Create(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var vehicle = _dbContext.Vehicles.FirstOrDefault(x => x.Id == id);
            _dbContext.Vehicles.Remove(vehicle);
            _dbContext.SaveChanges();
        }

        public void Edit(Vehicle vehicle)
        {
            _dbContext.Vehicles.Update(vehicle);
            _dbContext.SaveChanges();
        }

        public Vehicle GetById(int id)
        {
            return _dbContext.Vehicles.FirstOrDefault(x => x.Id == id);
        }
    }
}
