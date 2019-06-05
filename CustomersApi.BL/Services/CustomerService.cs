using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomersApi.DAL.Entities;
using CustomersApi.DAL.Repositories;
using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.BL.Services
{
    public class CustomerService :BaseService<Customer, CustomerModel>, ICustomerService
    {
        private readonly CustomersRepository _repository;

        public CustomerService(CustomersRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public IEnumerable<CustomerModel> GetAllCustomersWithAdresses()
        {
            var customers = _repository
                .GetAll()
                .Include(x => x.Addresses)
                .ThenInclude(x => x.AddressTypeMapping)
                .ToList();

            return _mapper.Map<List<Customer>, List<CustomerModel>>(customers);
        }

        public CustomerModel GetCustomer(string customerId, string customerName)
        {
            if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentException(
                    $"Parameter {nameof(customerId)} and {nameof(customerName)} cannot be empty.");
            }

            var customer = _repository.GetCustomerWithAddresses(customerId, customerName);

            return _mapper.Map<Customer, CustomerModel>(customer);
        }

        public CustomerModel AddCustomer(CustomerModel customer)
        {
            var customerEntity = _mapper.Map<CustomerModel, Customer>(customer);
            var newCustomer = _repository.Add(customerEntity);

            return _mapper.Map<CustomerModel>(newCustomer);
        }        
    }
}