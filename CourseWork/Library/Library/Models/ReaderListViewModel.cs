using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ReaderListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName not specified")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName not specified")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "MiddleName not specified")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Address not specified")]
        public string Address { get; set; }

        public string FLM { get; set; }
    }
}
