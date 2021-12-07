using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FuelGarage.Infrastructure.Services.Statuses
{
    public class StatusService : IStatusService
    {
        private readonly GarageContext _dbContext;

        public StatusService(GarageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Status> GetAll()
        {
            return _dbContext.Statuses
                .AsNoTracking()
                .ToList();
        }
    }
}
