using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
       
        public string CustomerName { get; set; }

        
        //[Min18IfAMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLatter { get; set; }
     

        [Display(Name = "Membership Type")]
        public int MemberShipTypeId { get; set; }
    }
}