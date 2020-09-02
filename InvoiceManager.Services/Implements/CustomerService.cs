using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Customers;
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

        public CustomerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CreateResponse Create(CustomerRequest request)
        {
            throw new NotImplementedException();
        }                

        public SuccessResponse Update(int id, CustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public CustomerResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse Patch(int id, JsonPatchDocument<CustomerRequest> request)
        {
            throw new NotImplementedException();
        }

        public List<CustomerResponse> Search(SearchCustomersRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
