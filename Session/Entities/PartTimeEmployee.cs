namespace Session.Entities
{
    class PartTimeEmployee : CompanyEmployee
    {
        public int HourRate { get; set; }
        public int CountOfHours { get; set; }
    }
}
