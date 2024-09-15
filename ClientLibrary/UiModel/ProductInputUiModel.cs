using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.UiModel;

public class ProductInputUiModel
{
    [Required(ErrorMessage = "Product code is required.")]
    [StringLength(10, ErrorMessage = "Product code cannot exceed 10 characters.")]
    public string ProductCode { get; set; } = null!;

    [Required(ErrorMessage = "Product name is required.")]
    public string ProductName { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
    public decimal UnitPrice { get; set; }

    [Required(ErrorMessage = "Warehouse is required.")]
    public int WarehouseId { get; set; }

    [Required(ErrorMessage = "Stock quantity is required.")]
    public int StockQuantity { get; set; }
}
