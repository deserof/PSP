using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class FuelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string FuelDescription { get; set; }

        [Required(ErrorMessage = "Не указано количество")]
        public int Quantity { get; set; }

    }
}
