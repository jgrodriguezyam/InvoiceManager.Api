using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.Model;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;

namespace InvoiceManager.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public CreateResponse Create(CustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);
            _customerRepository.Create(customer);
            return new CreateResponse(customer.Id);
        }                

        public SuccessResponse Update(int id, CustomerRequest request)
        {
            var customeryModel = _mapper.Map<Customer>(request);
            var customer = _customerRepository.GetBy(id);
            _mapper.Map(customeryModel, customer);
            _customerRepository.Update(customer);
            return new SuccessResponse(true);
        }

        public CustomerResponse Get(int id)
        {
            var customer = _customerRepository.GetBy(id);
            var customerResponse = _mapper.Map<CustomerResponse>(customer);
            return customerResponse;
        }

        public SuccessResponse Delete(int id)
        {
            var customer = _customerRepository.GetBy(id);
            _customerRepository.Remove(customer);
            return new SuccessResponse(true);
        }

        public SuccessResponse Patch(int id, JsonPatchDocument<CustomerRequest> request)
        {
            var customer = _customerRepository.GetBy(id);
            var jsonPatch = _mapper.Map<JsonPatchDocument<Customer>>(request);
            jsonPatch.ApplyTo(customer);
            _customerRepository.Update(customer);
            return new SuccessResponse(true);
        }

        public List<CustomerResponse> Search(SearchCustomersRequest request)
        {
            var customers = _customerRepository.GetBy(p => p.IsActive);
            var customersResponse = _mapper.Map<List<CustomerResponse>>(customers);
            return customersResponse;
        }
    }
}
