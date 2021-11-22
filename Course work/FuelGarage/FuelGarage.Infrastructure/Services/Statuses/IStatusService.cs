using FuelGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Infrastructure.Services.Statuses
{
    public interface IStatusService
    {
        List<Status> GetAll();
    }
}
