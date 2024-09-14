namespace ServerLibrary.Dtos;

public class InvoiceDetailInputDTO
{
    public int InvoiceId { get; set; }

    public int WarehouseId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }
}
