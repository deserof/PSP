using Garage.Bll.Services.Implementations;
using Garage.Bll.Services.Interfaces;
using Garage.Dal.Repositories.Implementations;
using Garage.Dal.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Garage.Di
{
    public static class IoC
    {
        public static void BuildIoC(this IServiceCollection services)
        {
            // Services
            services.AddSingleton<IFuelService, FuelService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IVehicleService, VehicleService>();

            // Repositories
            services.AddSingleton<IFuelRepository, FuelRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
        }
    }
}
