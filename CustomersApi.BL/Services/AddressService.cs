using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomersApi.DAL.Entities;
using CustomersApi.DAL.Repositories;
using CustomersApi.Models;

namespace CustomersApi.BL.Services
{
    public class AddressService : BaseService<Address, AddressModel>, IAddressService
    {
        //private new readonly AddressRepository _addressRepository;
        //private new readonly IMapper _mapper;
        private readonly AddressRepository _addressRepository;
        
        public AddressService(AddressRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _addressRepository = repository;
        }

        public IEnumerable<AddressModel> GetCustomerAddresses(string customerId, string customerName)
        {
            if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentException(
                    $"Parameter {nameof(customerId)} and {nameof(customerName)} cannot be empty.");
            }

            var addresses = _addressRepository.GetAll()
                .Where(x => x.CustomerId == customerId && x.CustomerName == customerName).ToList();

            return _mapper.Map<List<Address>, List<AddressModel>>(addresses);
        }

        public IEnumerable<AddressModel> GetAllAddresses()
        {
            var addresses = _addressRepository.GetAll().ToList();

            return _mapper.Map<List<Address>, List<AddressModel>>(addresses);
        }

        public AddressModel AddAddress(AddressModel address)
        {
            var addressEntity = _mapper.Map<AddressModel, Address>(address);

            addressEntity.AddressType = GetAddressTypeCode(address.AddressType);

            var newAddress = _addressRepository.Add(addressEntity);

            return _mapper.Map<AddressModel>(newAddress);
        }

        private char GetAddressTypeCode(string addressName)
        {
            return _addressRepository.GetMappingForAddressName(addressName).AddressType;
        }

        public bool UpdateAddress(AddressModel address)
        {
            bool isSuccess;

            try
            {
                var customerAddress = _mapper.Map<AddressModel, Address>(address);

                customerAddress.AddressType = GetAddressTypeCode(address.AddressType);

                _addressRepository.Update(customerAddress);

                isSuccess = true;
            }
            catch (Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;
        }

        //public bool DeleteAddress(AddressModel address)
        //{
        //    bool isSuccess;

        //    try
        //    {
        //        var addressEntity = _mapper.Map<AddressModel, Address>(address);

        //        _repository.Delete(addressEntity);

        //        isSuccess = true;
        //    }
        //    catch (Exception e)
        //    {

        //        isSuccess = false;
        //    }

        //    return isSuccess;
        //}

        public IEnumerable<AddressModel> GetCustomerAddressesOfType(string customerId, string customerName, string addressName)
        {
            var addresses = _addressRepository
                .GetAll()
                .Where(x =>
                    string.Equals(x.CustomerId, customerId) &&
                    string.Equals(x.CustomerName, customerName) &&
                    string.Equals(x.AddressType, GetAddressTypeCode(addressName))).ToList();

            return _mapper.Map<List<Address>, List<AddressModel>>(addresses);
        }
    }
}
