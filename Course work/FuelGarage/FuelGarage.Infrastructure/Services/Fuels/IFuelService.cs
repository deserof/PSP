using FuelGarage.Domain.Entities;
using System.Collections.Generic;

namespace FuelGarage.Infrastructure.Services.Fuels
{
    public interface IFuelService
    {
        List<Fuel> GetAll();

        void Create(Fuel fuel);

        void Delete(int id);

        void Edit(Fuel fue);

        Fuel GetById(int id);

        bool EraseFuel(int id, int count);

        bool EditFuelFromCustomer(int id, int count, int current);
    }
}
