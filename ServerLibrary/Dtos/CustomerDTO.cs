namespace ServerLibrary.Dtos;

public class CustomerDTO
{
    public int CustomerId { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public string? Address { get; set; }
}
