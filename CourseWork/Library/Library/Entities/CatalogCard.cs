using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class CatalogCard
    {
        public int Id { get; set; }
        public int QantityOfBook { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public List<SubscriptionCard> SubsciptionCards { get; set; } = new List<SubscriptionCard>();
    }
}
