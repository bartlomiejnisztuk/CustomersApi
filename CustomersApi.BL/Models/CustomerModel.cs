using System.Collections.Generic;

namespace CustomersApi.Models
{
    public class CustomerModel
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
}
