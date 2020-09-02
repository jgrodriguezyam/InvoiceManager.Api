using InvoiceManager.Model.Base;
using InvoiceManager.Model.Enums;

namespace InvoiceManager.Model
{
    public class Customer : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public EGenderType Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }

        public bool IsActive { get; set; }
    }
}
