using AutoMapper;
using CustomersApi.DAL.Entities;
using CustomersApi.Models;

namespace CustomersApi.BL.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();

                CreateMap<CustomerModel, Customer>()
                .ForMember(m => m.Addresses, opt => opt.Ignore());
        }
    }
}