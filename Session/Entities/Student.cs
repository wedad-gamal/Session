﻿namespace Session.Entities
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
