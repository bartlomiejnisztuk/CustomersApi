using System.ComponentModel.DataAnnotations;

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
