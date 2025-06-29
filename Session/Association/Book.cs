namespace Session.Association
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public Book(string name, string author)
        {
            Name = name;
            Author = author;
        }
    }
}
