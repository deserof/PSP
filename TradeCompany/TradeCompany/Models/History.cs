using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace TradeCompany.Models
{
    public class History
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public DateTime Date { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
