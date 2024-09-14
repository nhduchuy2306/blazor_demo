namespace ServerLibrary.Dtos;

public class WarehouseProductDTO
{
    public int WarehouseId { get; set; }

    public int ProductId { get; set; }

    public int StockQuantity { get; set; }

    public string WarehouseName { get; set; } = null!;
    
    public string ProductName { get; set; } = null!;
}
