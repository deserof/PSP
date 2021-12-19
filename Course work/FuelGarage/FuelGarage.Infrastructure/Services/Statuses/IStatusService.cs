using FuelGarage.Domain.Entities;
using System.Collections.Generic;

namespace FuelGarage.Infrastructure.Services.Statuses
{
    public interface IStatusService
    {
        List<Status> GetAll();
    }
}
