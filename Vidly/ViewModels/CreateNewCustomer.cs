﻿using System;
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
    }
}