namespace ClientLibrary.UiModel
{
    public class InvoiceDetailUiModel
    {
        public int InvoiceDetailId { get; set; }

        public int InvoiceId { get; set; }

        public int WarehouseId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}
