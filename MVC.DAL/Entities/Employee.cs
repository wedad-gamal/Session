namespace MVC.DAL.Entities
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Employee
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

        //[Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [MaxLength(50)]
        public string? Phone { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public int? CityId { get; set; }
        public virtual City? City { get; set; }

        public int? CountryId { get; set; }
        public virtual Country? Country { get; set; }
    }
}
