namespace InvoiceManager.DTO.BaseRequest
{
    public class ChangeStatusRequest : IdentifierRequest
    {
        public bool Status { get; set; }
    }
}
