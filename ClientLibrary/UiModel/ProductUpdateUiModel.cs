namespace ClientLibrary.UiModel;

public class ProductUpdateUiModel
{
    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public IEnumerable<WarehouseUpdateUiModel> Warehouses { get; set; } = null!;
}

public class WarehouseUpdateUiModel
{
    public int WarehouseId { get; set; }

    public int ProductId { get; set; }

    public int StockQuantity { get; set; }
}
