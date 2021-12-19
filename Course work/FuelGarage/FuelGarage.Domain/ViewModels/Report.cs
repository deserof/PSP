using System;
using System.ComponentModel.DataAnnotations;

namespace FuelGarage.Domain.ViewModels
{
    public class Report
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Укажите начальную дату")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Укажите конечную дату")]
        public DateTime To { get; set; }
    }
}
