using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.Services.Interfaces;
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

        public List<CompanyResponse> Search(SearchCompaniesRequest request)
        {
            throw new NotImplementedException();
        }

        public CompanyResponse Get(GetCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public CreateResponse Create(CompanyRequest request)
        {
            throw new NotImplementedException();
        }            

        public SuccessResponse Update(CompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public SuccessResponse Delete(DeleteCompanyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
