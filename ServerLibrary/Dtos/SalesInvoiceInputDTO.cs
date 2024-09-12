namespace ServerLibrary.Dtos
{
    public class SalesInvoiceInputDTO
    {

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public List<InvoiceDetailInputDTO> InvoiceDetails { get; set; } = new List<InvoiceDetailInputDTO>();
    }
}
