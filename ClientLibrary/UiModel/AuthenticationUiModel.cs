using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.UiModel;

public class AuthenticationUiModel
{
    [Required]
    public string CustomerCode { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
