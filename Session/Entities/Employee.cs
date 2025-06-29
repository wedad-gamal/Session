namespace Session.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual Employee? Manager { get; set; }
        public int? ManagerId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
