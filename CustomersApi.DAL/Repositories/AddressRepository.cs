using System.Linq;
using CustomersApi.DAL.Entities;

namespace CustomersApi.DAL.Repositories
{
    public class AddressRepository: BaseRepository<Address>
    {
        public AddressRepository(CustomersContext customersContext) : base(customersContext)
        {
        }

        public AddressTypeMapping GetMappingForAddressName(string addressName)
        {
            return _customersContext.AddressTypeMappings.FirstOrDefault(x => string.Equals(x.AddressName, addressName));
        }
    }
}
