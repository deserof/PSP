using System.ComponentModel.DataAnnotations;

namespace FuelGarage.Domain.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана марка")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Не указана модель")]
        public string Model { get; set; }
    }
}
