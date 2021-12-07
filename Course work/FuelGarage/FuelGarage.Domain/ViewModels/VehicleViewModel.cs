using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана марка")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Не указана модель")]
        public string VehicleModel { get; set; }
    }
}
