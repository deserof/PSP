using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Domain.ViewModels
{
    public class AdminDriverViewModel
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Vehicle { get; set; }
    }
}
