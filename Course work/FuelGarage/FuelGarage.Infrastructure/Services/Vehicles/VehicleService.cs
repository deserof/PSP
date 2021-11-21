using FuelGarage.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
    }
}
