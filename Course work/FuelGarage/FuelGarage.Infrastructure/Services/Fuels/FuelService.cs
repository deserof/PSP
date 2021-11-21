using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
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
            return _dbContext.Fuels.ToList();
        }
    }
}
