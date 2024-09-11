using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.UiModel
{
    public class WarehouseUiModel
    {
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = "Warehouse Code is required.")]
        [StringLength(50, ErrorMessage = "Warehouse Code cannot be longer than 50 characters.")]
        public string WarehouseCode { get; set; } = null!;

        [Required(ErrorMessage = "Warehouse Name is required.")]
        [StringLength(100, ErrorMessage = "Warehouse Name cannot be longer than 100 characters.")]
        public string WarehouseName { get; set; } = null!;

        [StringLength(200, ErrorMessage = "Location cannot be longer than 200 characters.")]
        public string? Location { get; set; }
    }
}
