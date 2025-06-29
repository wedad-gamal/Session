using System.ComponentModel.DataAnnotations.Schema;

namespace Session.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
