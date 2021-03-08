using InvoiceManager.DTO.BaseRequest;

namespace InvoiceManager.DTO.Messages.Companies
{
    public class SearchCompaniesRequest : SearchRecordsRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
