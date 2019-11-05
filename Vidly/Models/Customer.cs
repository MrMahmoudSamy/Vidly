using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Display(Name ="Date Of Birth")]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLatter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public int MemberShipTypeId { get; set; }
    }
}