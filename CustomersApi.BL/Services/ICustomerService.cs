using System.Collections.Generic;
using CustomersApi.Models;

namespace CustomersApi.BL.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomer(string customerId, string customerName);
        CustomerModel AddCustomer(CustomerModel customer);
        void UpdateCustomer(CustomerModel customer);
        void DeleteCustomer(CustomerModel customer);
    }
}
