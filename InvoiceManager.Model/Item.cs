using InvoiceManager.Model.Base;

namespace InvoiceManager.Model
{
    public class Item : EntityBase
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
