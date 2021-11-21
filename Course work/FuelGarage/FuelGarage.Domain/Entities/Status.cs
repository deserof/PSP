using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
