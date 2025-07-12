using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels;

public class RegisterViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare(nameof(Password), ErrorMessage = "Password must match")]
    [DataType(DataType.Password)]
    [Required]
    public string ConfirmPassword { get; set; }
    public bool IsAgree { get; set; }
}
