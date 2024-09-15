namespace ServerLibrary.Dtos;

public class ProductUpdateDTO
{
    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public IEnumerable<WarehouseUpdateDTO> Warehouses { get; set; } = null!;
}

public class WarehouseUpdateDTO
{
    public int WarehouseId { get; set; }

    public int ProductId { get; set; }
    
    public int StockQuantity { get; set; }
}
