using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class SubscriptionCard
    {
        public int Id { get; set; }
        public int ReaderListId { get; set; }
        public int CatalogCardId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ReaderList ReaderList { get; set; }
        public CatalogCard CatalogCard{ get; set; }
    }
}
