using System;

namespace FuelGarage.Domain.ViewModels
{
    public class AdminOrderViewModel
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string CustomerFirstName { get; set; }
        public string CustomerPhone { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerMiddleName { get; set; }

        public string DriverFirstName { get; set; }

        public string DriverLastName { get; set; }

        public string DriverMiddleName { get; set; }

        public string DriverPhone { get; set; }

        public string FuelBrand { get; set; }

        public int FuelQuantity { get; set; }

        public string Status { get; set; }

        public string OrderAddress { get; set; }

        public string OrderDescription { get; set; }

        public DateTime ApplicationTime { get; set; }

        public DateTime LeadTime { get; set; }
    }
}
