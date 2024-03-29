﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApi.Models
{
    public class AddressModel
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string AddressType { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
