namespace Session.Entities
{
    //[PrimaryKey(nameof(StudentId), nameof(CourseId))]
    class CourseStudent
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }
    }
}
