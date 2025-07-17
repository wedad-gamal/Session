namespace MVC.Presentation.ViewModels;

public class UserViewModel
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? Roles { get; set; }
    public List<UserRoleViewModel>? UserRoleViewModel { get; set; } = new List<UserRoleViewModel>();
}
