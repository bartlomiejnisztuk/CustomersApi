using AutoMapper;
using CustomersApi.DAL.Entities;
using CustomersApi.Models;

namespace CustomersApi.BL.MapperProfiles
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModel>()
                .ForMember(m => m.AddressType, opt => opt.MapFrom(src=>src.AddressTypeMapping.AddressName));

            CreateMap<AddressModel, Address>()
                .ForMember(m => m.CustomerId, opt => opt.Ignore())
                .ForMember(m => m.CustomerName, opt => opt.Ignore())
                .ForMember(m => m.Customer, opt => opt.Ignore())
                .ForMember(m => m.AddressTypeMapping, opt => opt.Ignore())
                .ForMember(m => m.CustomerId, opt => opt.Ignore());
        }
    }
}