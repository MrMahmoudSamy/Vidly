using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NewRental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movies Movie { get; set; }

       
        [Display(Name = "Rental Date")]
        public DateTime DateRental { get; set; }
        
        [Display(Name = "Returen Date")]
        public DateTime?  DateReturned { get; set; }
    }
}