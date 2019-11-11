using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CreateNewCustomer
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customers { get; set; }
        public string Title
        {
            get
            {
                if (Customers != null && Customers.CustomerId != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }
    }
}