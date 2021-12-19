using System.Collections.Generic;

namespace FuelGarage.Domain.Entities
{
    public class Fuel
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string FuelDescription { get; set; }

        public int Quantity { get; set; }

        public List<Order> Orders { get; set; }
    }
}
