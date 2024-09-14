namespace ServerLibrary.Dtos;

public class WarehouseDTO
{
    public int WarehouseId { get; set; }

    public string WarehouseCode { get; set; } = null!;

    public string WarehouseName { get; set; } = null!;

    public string? Location { get; set; }
}
