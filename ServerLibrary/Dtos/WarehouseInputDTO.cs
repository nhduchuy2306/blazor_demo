namespace ServerLibrary.Dtos
{
    public class WarehouseInputDTO
    {
        public string WarehouseCode { get; set; } = null!;

        public string WarehouseName { get; set; } = null!;

        public string? Location { get; set; }
    }
}
