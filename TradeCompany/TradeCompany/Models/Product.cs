using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeCompany.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }

        public int ShopId { get; set; }

        public int StatusId { get; set; }

        public Shop Shop { get; set; }

        public Status Status { get; set; }
    }
}
