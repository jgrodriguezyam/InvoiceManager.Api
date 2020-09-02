using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;

namespace InvoiceManager.Services.Implements
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IMapper mapper)
        {
            _mapper = mapper;
        }        

        public CreateResponse Create(CompanyRequest request)
        {
            throw new NotImplementedException();
        }            

        public SuccessResponse Update(int id, CompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse Patch(int id, JsonPatchDocument<CompanyRequest> request)
        {
            throw new NotImplementedException();
        }

        public List<CompanyResponse> Search(SearchCompaniesRequest request)
        {
            throw new NotImplementedException();
        }        
    }
}
