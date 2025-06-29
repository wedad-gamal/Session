namespace Session.Entities
{
    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
