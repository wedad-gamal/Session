using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels;

public class ForgotPasswordViewModel
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
}
