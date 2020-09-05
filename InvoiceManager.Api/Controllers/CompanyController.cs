using System.Collections.Generic;
using InvoiceManager.Api.Filters;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<CreateResponse> Post(CompanyRequest request)
        {
            var createResponse = _companyService.Create(request);
            return Ok(createResponse);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<SuccessResponse> Put(int id, CompanyRequest request)
        {
            var successResponse = _companyService.Update(id, request);
            return Ok(successResponse);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<CompanyResponse> Get(int id)
        {
            var companyResponse = _companyService.Get(id);
            return Ok(companyResponse);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            var successResponse = _companyService.Delete(id);
            return Ok(successResponse);
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<SuccessResponse> Patch(int id, JsonPatchDocument<CompanyRequest> request)
        {
            var successResponse = _companyService.Patch(id, request);
            return Ok(successResponse);
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<List<CompanyResponse>> Get([FromQuery] SearchCompaniesRequest request)
        {
            var companiesResponse = _companyService.Search(request);
            return Ok(companiesResponse);
        }        
    }
}
