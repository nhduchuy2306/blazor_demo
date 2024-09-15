using System;
using System.Collections.Generic;

namespace ServerLibrary.Models;

public partial class WarehouseProduct
{
    public int WarehouseId { get; set; }

    public int ProductId { get; set; }

    public int StockQuantity { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
