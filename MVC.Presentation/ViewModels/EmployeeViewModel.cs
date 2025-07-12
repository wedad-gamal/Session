using System.ComponentModel.DataAnnotations;

namespace MVC.Presentation.ViewModels;

public class EmployeeViewModel
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; }
    public string? Address { get; set; }

    [DataType(DataType.Currency)]
    public decimal? Salary { get; set; }
    public bool IsActive { get; set; } = false;

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [MaxLength(50, ErrorMessage = "Max length 50 character")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Gender is Required")]
    public Gender Gender { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Phone]
    [MaxLength(50)]
    public string? Phone { get; set; }
    public int? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public IEnumerable<SelectListItem> Departments { get; set; } = new HashSet<SelectListItem>();
    public IEnumerable<SelectListItem> GenderList { get; set; } = new HashSet<SelectListItem>();
    public IEnumerable<SelectListItem> Countries { get; set; } = new HashSet<SelectListItem>();
    public IEnumerable<SelectListItem> Cities { get; set; } = new HashSet<SelectListItem>();
    public IFormFile? ProfilePicture { get; set; }
    public string? ImagePath { get; set; } = string.Empty;
    public int? CountryId { get; set; }
    public string? CountryName { get; set; }
    public int? CityId { get; set; }
    public string? CityName { get; set; }
    public bool IsEditMode { get; set; } = false;

}
