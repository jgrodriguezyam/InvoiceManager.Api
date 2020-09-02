using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<CustomerResponse>> Get([FromQuery] SearchCustomersRequest request) 
        {
            var customersResponse = _customerService.Search(request);
            return Ok(customersResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerResponse> Get([FromRoute] GetCustomerRequest request)
        {
            var customerResponse = _customerService.Get(request);
            return Ok(customerResponse);
        }
    }
}
