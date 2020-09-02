using System.Collections.Generic;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPost]
        public ActionResult<CreateResponse> Post(CustomerRequest request)
        {
            var createResponse = _customerService.Create(request);
            return Ok(createResponse);
        }

        [HttpPut("{id}")]
        public ActionResult<SuccessResponse> Put(int id, CustomerRequest request)
        {
            var successResponse = _customerService.Update(id, request);
            return Ok(successResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerResponse> Get(int id)
        {
            var customerResponse = _customerService.Get(id);
            return Ok(customerResponse);
        }

        [HttpDelete("{id}")]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            var successResponse = _customerService.Delete(id);
            return Ok(successResponse);
        }

        [HttpPatch("{id}")]
        public ActionResult<SuccessResponse> Patch(int id, JsonPatchDocument<CustomerRequest> request)
        {
            var successResponse = _customerService.Patch(id, request);
            return Ok(successResponse);
        }

        [HttpGet]
        public ActionResult<List<CustomerResponse>> Get([FromQuery] SearchCustomersRequest request)
        {
            var customersResponse = _customerService.Search(request);
            return Ok(customersResponse);
        }
    }
}
