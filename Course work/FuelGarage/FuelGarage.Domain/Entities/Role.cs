﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

	    public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
