using FuelGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Infrastructure.Services.Fuels
{
    public interface IFuelService
    {
        List<Fuel> GetAll();
    }
}
