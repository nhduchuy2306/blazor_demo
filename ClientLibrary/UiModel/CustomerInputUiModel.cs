using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.UiModel;

public class CustomerInputUiModel
{
    [Required(ErrorMessage = "Customer code is required.")]
    [StringLength(20, ErrorMessage = "Customer code cannot exceed 20 characters.")]
    public string CustomerCode { get; set; } = null!;

    [Required(ErrorMessage = "Customer name is required.")]
    public string CustomerName { get; set; } = null!;

    [StringLength(100, ErrorMessage = "Contact info cannot exceed 100 characters.")]
    public string? ContactInfo { get; set; }

    public string? Address { get; set; }

    [Required(ErrorMessage = "Role is required.")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = null!;
}
