namespace InvoiceManager.DTO.Messages.Companies
{
    public class CompanyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
    }
}
