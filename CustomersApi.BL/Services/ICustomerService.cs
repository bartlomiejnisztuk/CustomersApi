using System.Collections.Generic;
using CustomersApi.Models;

namespace CustomersApi.BL.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllCustomersWithAdresses();
        CustomerModel GetCustomer(string customerId, string customerName);
        CustomerModel AddCustomer(CustomerModel customer);
        bool UpdateCustomer(CustomerModel customer);
        bool DeleteCustomer(CustomerModel customer);
    }
}
