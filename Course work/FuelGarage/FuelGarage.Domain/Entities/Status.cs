using System.Collections.Generic;

namespace FuelGarage.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
