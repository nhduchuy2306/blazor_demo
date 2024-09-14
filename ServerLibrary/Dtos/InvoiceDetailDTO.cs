namespace ServerLibrary.Dtos;

public class InvoiceDetailDTO
{
    public int InvoiceDetailId { get; set; }

    public int InvoiceId { get; set; }

    public int WarehouseId { get; set; }

    public string WarehouseName { get; set; } = null!;

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }
}
