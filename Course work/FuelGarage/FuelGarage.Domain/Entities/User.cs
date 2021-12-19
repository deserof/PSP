namespace FuelGarage.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserPassword { get; set; }

        public int? VehicleId { get; set; }

        public Role Role { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
