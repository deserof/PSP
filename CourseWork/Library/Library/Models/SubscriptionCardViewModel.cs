using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class SubscriptionCardViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reader not specified")]
        public int ReaderListId { get; set; }
        [Required(ErrorMessage = "Book not specified")]
        public int CatalogCardId { get; set; }

        public string LMF { get; set; }
        public string BookNameAndBookAuthor { get; set; }

        [Required(ErrorMessage = "IssueDate not specified")]
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
