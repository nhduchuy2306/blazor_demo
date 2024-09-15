namespace ServerLibrary.Dtos;

public class AccountDTO
{
    public int CustomerId { get; set; }

    public string? CustomerCode { get; set; }

    public string? CustomerName { get; set; }

    public int RoleId { get; set; }

    public string? RoleName { get; set; }
}
