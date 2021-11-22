using FuelGarage.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FuelGarage.Domain.Entities;

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
            return _dbContext.Statuses.ToList();
        }
    }
}
