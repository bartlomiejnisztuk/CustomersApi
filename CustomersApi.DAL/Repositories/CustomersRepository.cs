using System.Linq;
using CustomersApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.DAL.Repositories
{
    public class CustomersRepository: BaseRepository<Customer>
    {
        public CustomersRepository(CustomersContext customersContext) : base(customersContext)
        {
        }

        public Customer GetCustomerWithAddresses(string id, string name)
        {
            return _customersContext.Customers.Include(x => x.Addresses)
                .SingleOrDefault(x => x.CustomerId == id && x.Name == name);
        }
    }
}
