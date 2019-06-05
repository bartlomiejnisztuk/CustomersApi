using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomersApi.DAL.Entities
{
    public class Customer
    {
        [MaxLength(5)]
        [Column(TypeName = "varchar(5)")]
        public string CustomerId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string ZIP { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [StringLength(2)]
        [Column(TypeName = "varchar(2)")]
        public string Country { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
