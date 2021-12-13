using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeCompany.Models;

namespace TradeCompany.Infrastructure.Db
{
    public sealed class ProductCompanyContext : DbContext
    {
        public ProductCompanyContext(DbContextOptions<ProductCompanyContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 1,
                Name = "В магазине"
            },
            new Status
            {
                Id = 2,
                Name = "Заказан"
            },
            new Status
            {
                Id = 3,
                Name = "Продан"
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<History> Histories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Status> Statuses { get; set; }
    }
}
