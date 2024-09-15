namespace ServerLibrary.Dtos;

public class ProductInputDTO
{
    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int StockQuantity { get; set; }

    public int WarehouseId { get; set; }
}
