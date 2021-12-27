﻿using System.Collections.Generic;

namespace FuelGarage.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public List<User> Users { get; set; }
    }
}