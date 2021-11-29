using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name not specified")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Author not specified")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Pages not specified")]
        public int Pages { get; set; }
    }
}
