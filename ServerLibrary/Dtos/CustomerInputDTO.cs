namespace ServerLibrary.Dtos
{
    public class CustomerInputDTO
    {
        public string CustomerCode { get; set; } = null!;

        public string CustomerName { get; set; } = null!;

        public string? ContactInfo { get; set; }

        public string? Address { get; set; }
    }
}
