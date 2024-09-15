namespace ClientLibrary.UiModel;

public class AuthenticationResponseUiModel
{
    public AccountUiModel Account { get; set; } = new AccountUiModel();
    public string AccessToken { get; set; } = string.Empty;
}

public class AccountUiModel
{
    public int CustomerId { get; set; }
    public string CustomerCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public int roleId { get; set; }
    public string roleName { get; set; } = string.Empty;
}
