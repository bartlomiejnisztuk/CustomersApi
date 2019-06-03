using System;
using System.Collections.Generic;
using CustomersApi.DAL.Entities;

namespace CustomersApi.BL.Services
{
    public class AddressService: IAddressService
    {
        public IEnumerable<Address> GetCustomerAddresses(string customerId, string customerName)
        {
            throw new NotImplementedException();
        }

        public void AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Address GetCustomerAddressesOfType(string customerId, string customerName, string type)
        {
            throw new NotImplementedException();
        }
    }
}
