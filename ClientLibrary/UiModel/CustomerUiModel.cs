namespace ClientLibrary.UiModel;

public class CustomerUiModel
{
    public int CustomerId { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public string? Address { get; set; }

    public string? RoleName { get; set; }
}
