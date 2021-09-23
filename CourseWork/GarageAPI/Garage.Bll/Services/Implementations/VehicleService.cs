using Garage.Bll.Services.Interfaces;
using Garage.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Bll.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private protected IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }
    }
}
