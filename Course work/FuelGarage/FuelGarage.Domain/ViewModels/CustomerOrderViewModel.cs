using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class CustomerOrderViewModel
    {
        public int Id { get; set; }

        public string DriverFirstName { get; set; }

        public string DriverLastName { get; set; }

        public string DriverMiddleName { get; set; }

        public string DriverPhone{ get; set; }

        public string FuelBrand { get; set; }

        public int FuelQuantity { get; set; }

        public string Status { get; set; }

        public string OrderAddress { get; set; }

        public string OrderDescription { get; set; }

        public DateTime ApplicationTime { get; set; }

        public DateTime LeadTime { get; set; }
    }
}
