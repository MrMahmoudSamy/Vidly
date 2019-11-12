using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name ="Date Of Birth")]
        [Min18IfAMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLatter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        [Display(Name ="Membership Type")]
        public int MemberShipTypeId { get; set; }
    }
}