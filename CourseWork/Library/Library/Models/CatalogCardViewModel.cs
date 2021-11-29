using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CatalogCardViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "QantityOfBook not specified")]
        public int QantityOfBook { get; set; }
        [Required(ErrorMessage = "BookName not specified")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "BookAuthor not specified")]
        public string BookAuthor { get; set; }
        public string BookNameAndAuthor { get; set; }
    }
}
