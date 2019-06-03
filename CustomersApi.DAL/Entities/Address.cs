using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CustomersApi.DAL.Entities
{
    public class Address
    {
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public virtual Customer Customer { get; set; }

        public char AddressType { get; set; }
        public virtual AddressTypeMapping AddressTypeMapping { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(20)]
        public string ZIP { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [StringLength(2)]
        public string Country { get; set; }
    }
}
