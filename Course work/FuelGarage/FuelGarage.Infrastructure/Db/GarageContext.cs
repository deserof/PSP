using FuelGarage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Infrastructure.Db
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions<GarageContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                RoleName = "driver"
            },
            new Role
            {
                Id = 2,
                RoleName = "customer"
            },
            new Role
            {
                Id = 3,
                RoleName = "admin"
            });

            modelBuilder.Entity<Status>().HasData(new Status
            {
                Id = 1,
                StatusName = "Открыт"
            },
            new Status
            {
                Id = 2,
                StatusName = "В процессе"
            },
            new Status
            {
                Id = 3,
                StatusName = "Завершен"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "admin@admin.admin",
                FirstName = "adminName",
                LastName = "adminLN",
                MiddleName = "adminMN",
                Phone = "+111",
                RoleId = 3,
                UserPassword = "admin",
                VehicleId = null
            },
            new User
            {
                Id = 2,
                Email = "customer@customer.customer",
                FirstName = "customerName",
                LastName = "customerLastName",
                MiddleName = "customerMiddeName",
                Phone = "+56756",
                RoleId = 2,
                UserPassword = "customer"
            },
            new User
            {
                Id = 3,
                Email = "driver@driver.driver",
                FirstName = "иван",
                LastName = "иванов",
                MiddleName = "иваныч",
                Phone = "+980",
                RoleId = 1,
                UserPassword = "driver"
            });

            modelBuilder.Entity<Fuel>().HasData(new Fuel
            {
                Id = 1,
                Brand = "Аи-95",
                FuelDescription = "Топливо Аи-95",
                Quantity = 100
            },
            new Fuel
            {
                Id = 2,
                Brand = "Аи-92",
                FuelDescription = "Топливо Аи-92",
                Quantity = 150
            },
            new Fuel
            {
                Id = 3,
                Brand = "H-80",
                FuelDescription = "Топливо H-80",
                Quantity = 25
            },
            new Fuel
            {
                Id = 4,
                Brand = "Д/Т",
                FuelDescription = "Топливо Д/Т",
                Quantity = 500
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Fuel> Fuels { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
