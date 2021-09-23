using Garage.Bll.Services.Interfaces;
using Garage.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Bll.Services.Implementations
{
    public class FuelService : IFuelService
    {
        private protected IFuelRepository fuelRepository;

        public FuelService(IFuelRepository fuelRepository)
        {
            this.fuelRepository = fuelRepository;
        }
    }
}
