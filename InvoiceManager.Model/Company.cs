using InvoiceManager.Model.Base;

namespace InvoiceManager.Model
{
    public class Company : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }

        public bool IsActive { get; set; }
    }
}
