using System.Collections.Generic;
using InvoiceManager.Api.Filters;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Invoices;
using InvoiceManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<CreateResponse> Post(InvoiceRequest request)
        {
            var createResponse = _invoiceService.Create(request);
            return Ok(createResponse);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<SuccessResponse> Put(int id, InvoiceRequest request)
        {
            var successResponse = _invoiceService.Update(id, request);
            return Ok(successResponse);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<InvoiceResponse> Get(int id)
        {
            var invoiceResponse = _invoiceService.Get(id);
            return Ok(invoiceResponse);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            var successResponse = _invoiceService.Delete(id);
            return Ok(successResponse);
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilterAttribute))]
        public ActionResult<List<InvoiceResponse>> Get([FromQuery] SearchInvoicesRequest request)
        {
            var invoicesResponse = _invoiceService.Search(request);
            return Ok(invoicesResponse);
        }
    }
}
