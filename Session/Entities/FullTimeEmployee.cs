namespace Session.Entities
{
    class FullTimeEmployee : CompanyEmployee
    {
        public DateOnly StartDate { get; set; }
        public decimal Salary { get; set; }
    }
}
