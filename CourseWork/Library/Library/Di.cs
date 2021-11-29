using Library.Infrastructure.Services;
using Library.Infrastructure.Services.Implementations;
using Library.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public static class Di
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICatalogCardService, CatalogCardService>();
            services.AddTransient<IReaderListService, ReaderListService>();
            services.AddTransient<ISubscriptionCardService, SubscriptionCardService>();
        }
    }
}
