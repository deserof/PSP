using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class AdminCustomerViewModel
    {
        public int Id { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress(ErrorMessage = "Неправильный Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }

        public string Password { get; set; }
    }
}
