using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeCompany.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Product> Products { get; set; }

        public List<History> Histories { get; set; }
    }
}
