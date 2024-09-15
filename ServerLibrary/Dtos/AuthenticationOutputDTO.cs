namespace ServerLibrary.Dtos;

public class AuthenticationOutputDTO
{
    public AccountDTO Account { get; set; } = new AccountDTO();

    public string AccessToken { get; set; } = string.Empty;
}
