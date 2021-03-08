using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Invoices;
using System.Collections.Generic;

namespace InvoiceManager.Services.Interfaces
{
    public interface IInvoiceService
    {
        CreateResponse Create(InvoiceRequest request);
        SuccessResponse Update(int id, InvoiceRequest request);
        InvoiceResponse Get(int id);
        SuccessResponse Delete(int id);
        List<InvoiceResponse> Search(SearchInvoicesRequest request);
    }
}
