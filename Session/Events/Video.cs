namespace Session.Events
{
    public class Video
    {
        public Video(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return $"Name: {Name} :: Description: {Description}";
        }
    }
}
