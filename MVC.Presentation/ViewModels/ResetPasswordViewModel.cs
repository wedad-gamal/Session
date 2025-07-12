using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels;

public class ResetPasswordViewModel
{

    public string? Token { get; set; }
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string ConfirmPassword { get; set; }
}
