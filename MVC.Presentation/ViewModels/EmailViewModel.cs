using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels;

public class EmailViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Subject { get; set; }
    [Required]
    public string Message { get; set; }
}
