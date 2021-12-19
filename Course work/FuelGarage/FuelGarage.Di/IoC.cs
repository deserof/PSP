using FuelGarage.Infrastructure.Services.Fuels;
using FuelGarage.Infrastructure.Services.Orders;
using FuelGarage.Infrastructure.Services.Statuses;
using FuelGarage.Infrastructure.Services.Users;
using FuelGarage.Infrastructure.Services.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace FuelGarage.Di
{
    public static class IoC
    {
        public static void RegisterDi(this IServiceCollection services)
        {
            services.AddTransient<IFuelService, FuelService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVehicleService, VehicleService>();
        }
    }
}
