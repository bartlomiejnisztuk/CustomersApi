using System.Collections.Generic;
using CustomersApi.Models;

namespace CustomersApi.BL.Services
{
    public interface IAddressService
    {
        IEnumerable<AddressModel> GetCustomerAddresses(string customerId, string customerName);
        IEnumerable<AddressModel> GetAllAddresses();
        AddressModel AddAddress(AddressModel address);
        bool Update(AddressModel address);
        bool UpdateAddress(AddressModel address);
        bool Delete(AddressModel address);
        IEnumerable<AddressModel> GetCustomerAddressesOfType(string customerId, string customerName, string type);
    }
}
