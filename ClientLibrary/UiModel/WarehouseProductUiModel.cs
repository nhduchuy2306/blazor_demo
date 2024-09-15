namespace ClientLibrary.UiModel;

public class WarehouseProductUiModel
{
    public int WarehouseId { get; set; }
    public int ProductId { get; set; }
    public int StockQuantity { get; set; }
    public string WarehouseName { get; set; } = null!;
    public string ProductName { get; set; } = null!;
}
