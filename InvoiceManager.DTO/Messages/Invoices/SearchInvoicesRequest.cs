using InvoiceManager.DTO.BaseRequest;

namespace InvoiceManager.DTO.Messages.Invoices
{
    public class SearchInvoicesRequest : SearchRecordsRequest
    {
        public int PurchaseOrderNumber { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
    }
}
