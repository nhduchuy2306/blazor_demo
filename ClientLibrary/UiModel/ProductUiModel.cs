namespace ClientLibrary.UiModel
{
    public class ProductUiModel
    {
        public int ProductId { get; set; }

        public string ProductCode { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal UnitPrice { get; set; }
    }
}
