using InvoiceManager.DTO.Messages.Items;
using System.Collections.Generic;

namespace InvoiceManager.DTO.Messages.Invoices
{
    public class InvoiceRequest
    {
        public int Id { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public List<ItemRequest> Items { get; set; }
    }
}
