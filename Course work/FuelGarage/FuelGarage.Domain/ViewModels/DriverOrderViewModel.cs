using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class DriverOrderViewModel
    {
        public int Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerMiddleName { get; set; }

        public string CustomerPhone { get; set; }

        public string FuelBrand { get; set; }

        public int FuelQuantity { get; set; }

        public string Status { get; set; }

        public string OrderAddress { get; set; }

        public string OrderDescription { get; set; }

        public DateTime ApplicationTime { get; set; }

        public DateTime LeadTime { get; set; }
    }
}
