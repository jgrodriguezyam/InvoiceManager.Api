using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public ActionResult<List<CompanyResponse>> Get([FromQuery] SearchCompaniesRequest request)
        {
            var companiesResponse = _companyService.Search(request);
            return Ok(companiesResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyResponse> Get([FromRoute] GetCompanyRequest request)
        {
            var companyResponse = _companyService.Get(request);
            return Ok(companyResponse);
        }
    }
}
