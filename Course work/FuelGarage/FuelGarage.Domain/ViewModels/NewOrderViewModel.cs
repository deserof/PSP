using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class NewOrderViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string FuelName { get; set; }
        public int FuelQuantity { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int StatusId { get; set; }
    }
}
