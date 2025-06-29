namespace MVC.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
