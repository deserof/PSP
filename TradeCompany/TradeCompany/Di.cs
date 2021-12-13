using Microsoft.Extensions.DependencyInjection;
using TradeCompany.Infrastructure.Services.Histories;
using TradeCompany.Infrastructure.Services.Products;
using TradeCompany.Infrastructure.Services.Shops;
using TradeCompany.Infrastructure.Services.Statuses;

namespace TradeCompany
{
    public static class Di
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IHistoryService, HistoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IStatusService, StatusService>();
        }
    }
}