﻿namespace Session.Entities
{
    abstract class CompanyEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }

    }
}
