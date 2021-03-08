using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.Model;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace InvoiceManager.Services.Implements
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }        

        public CreateResponse Create(CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);
            _companyRepository.Create(company);
            return new CreateResponse(company.Id);
        }            

        public SuccessResponse Update(int id, CompanyRequest request)
        {
            var companyModel = _mapper.Map<Company>(request);
            var company = _companyRepository.GetBy(id);
            _mapper.Map(companyModel, company);
            _companyRepository.Update(company);
            return new SuccessResponse(true);
        }

        public CompanyResponse Get(int id)
        {
            var company = _companyRepository.GetBy(id);
            var companyResponse = _mapper.Map<CompanyResponse>(company);
            return companyResponse;
        }

        public SuccessResponse Delete(int id)
        {
            var company = _companyRepository.GetBy(id);
            _companyRepository.Remove(company);
            return new SuccessResponse(true);
        }        

        public SuccessResponse Patch(int id, JsonPatchDocument<CompanyRequest> request)
        {
            var company = _companyRepository.GetBy(id);
            var jsonPatch = _mapper.Map<JsonPatchDocument<Company>>(request);
            jsonPatch.ApplyTo(company);
            _companyRepository.Update(company);
            return new SuccessResponse(true);
        }

        public List<CompanyResponse> Search(SearchCompaniesRequest request)
        {
            var companies = _companyRepository.GetBy(p => p.IsActive);
            var companiesResponse = _mapper.Map<List<CompanyResponse>>(companies);
            return companiesResponse;
        }        
    }
}
