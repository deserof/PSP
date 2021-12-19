using System;

namespace FuelGarage.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int? DriverId { get; set; }

        public int? CustomerId { get; set; }

        public int FuelId { get; set; }

        public int FuelQuantity { get; set; }

        public int StatusId { get; set; }

        public string OrderAddress { get; set; }

        public string OrderDescription { get; set; }

        public DateTime ApplicationTime { get; set; }

        public DateTime LeadTime { get; set; }

        public Fuel Fuel { get; set; }

        public Status Status { get; set; }

        public User Driver { get; set; }

        public User Customer { get; set; }
    }
}
