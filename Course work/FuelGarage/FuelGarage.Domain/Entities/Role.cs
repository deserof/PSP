using System.Collections.Generic;

namespace FuelGarage.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

	    public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
