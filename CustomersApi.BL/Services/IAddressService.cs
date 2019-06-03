using System.Collections.Generic;
using CustomersApi.DAL.Entities;

namespace CustomersApi.BL.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> GetCustomerAddresses(string customerId, string customerName);
        void AddAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(Address address);
        Address GetCustomerAddressesOfType(string customerId, string customerName, string type);
    }
}
