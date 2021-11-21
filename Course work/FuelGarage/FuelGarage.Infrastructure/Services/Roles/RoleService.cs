using FuelGarage.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace FuelGarage.Infrastructure.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly GarageContext _dbContext;

        public RoleService(GarageContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
