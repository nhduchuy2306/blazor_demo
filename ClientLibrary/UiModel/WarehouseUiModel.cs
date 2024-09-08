namespace ClientLibrary.UiModel
{
    public class WarehouseUiModel
    {
        public int WarehouseId { get; set; }

        public string WarehouseCode { get; set; } = null!;

        public string WarehouseName { get; set; } = null!;

        public string? Location { get; set; }
    }
}
