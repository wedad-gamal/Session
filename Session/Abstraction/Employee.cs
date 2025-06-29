namespace Session.Abstraction
{
    class Employee : ICloneable, IComparable
    {
        public static int count;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        static Employee()
        {
            count = 0;
        }
        public Employee()
        {
            count++;
        }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
        public Employee(Employee employee) //Copy constructor
        {
            Id = employee.Id;
            Name = employee.Name;
            Salary = employee.Salary;
        }

        public object Clone()
        {
            return new Employee() { Id = Id, Name = Name, Salary = Salary };
        }

        public override string ToString()
        {
            return $"Id: {Id} :: Name: {Name} :: Salary:{Salary}";
        }

        public int CompareTo(object? obj)
        {
            Employee employee = (Employee)obj;
            if (this.Salary > employee.Salary)
            {
                return 1;
            }
            else if (this.Salary < employee.Salary)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
