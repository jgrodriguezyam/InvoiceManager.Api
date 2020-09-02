using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InvoiceManager.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CustomerResponse> Search(SearchCustomersRequest request)
        {
            throw new NotImplementedException();
        }

        public CustomerResponse Get(GetCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public CreateResponse Create(CustomerRequest request)
        {
            throw new NotImplementedException();
        }                

        public SuccessResponse Update(CustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse Delete(DeleteCustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
