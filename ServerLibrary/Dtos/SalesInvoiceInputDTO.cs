namespace ServerLibrary.Dtos
{
    public class SalesInvoiceInputDTO
    {
        public string InvoiceNumber { get; set; } = null!;

        public DateOnly InvoiceDate { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
