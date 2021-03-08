using InvoiceManager.Model.Base;
using System.Collections.Generic;

namespace InvoiceManager.Model
{
    public class Invoice : EntityBase, IDeletable
    {
        public int Id { get; set; }        
        public int PurchaseOrderNumber { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Item> Items { get; set; }

        public bool IsActive { get; set; }
    }
}
