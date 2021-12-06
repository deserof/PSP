using System;
using System.Collections.Generic;
using System.Text;
using FuelGarage.Domain.Entities;

namespace FuelGarage.Infrastructure.Services.Vehicles
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();

        void Create(Vehicle vehicle);

        void Delete(int id);

        void Edit(Vehicle vehicle);

        Vehicle GetById(int id);
    }
}
