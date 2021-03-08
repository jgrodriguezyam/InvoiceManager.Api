namespace InvoiceManager.DTO.Messages.Items
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
