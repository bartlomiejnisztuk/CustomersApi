using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersApi.DAL.Entities
{
    public class Address
    {
        [Column(TypeName = "varchar(5)")]
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public virtual Customer Customer { get; set; }

        [Column(TypeName = "varchar(1)")]
        public char AddressType { get; set; }
        public virtual AddressTypeMapping AddressTypeMapping { get; set; }

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
    }
}
