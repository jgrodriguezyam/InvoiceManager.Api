using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.DTO.Messages.Items;
using System.Collections.Generic;

namespace InvoiceManager.DTO.Messages.Invoices
{
    public class InvoiceResponse
    {
        public int Id { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public CompanyResponse Company { get; set; }
        public CustomerResponse Customer { get; set; }
        public List<ItemResponse> Items { get; set; }
    }
}
