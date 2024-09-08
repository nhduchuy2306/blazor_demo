namespace ServerLibrary.Models;

public partial class InvoiceDetail
{
    public int InvoiceDetailId { get; set; }

    public int InvoiceId { get; set; }

    public int WarehouseId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }

    public virtual SalesInvoice Invoice { get; set; } = null!;

    public virtual WarehouseProduct WarehouseProduct { get; set; } = null!;
}
