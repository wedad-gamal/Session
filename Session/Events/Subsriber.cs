namespace Session.Events
{
    public class Subsriber
    {
        public Subsriber(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public void Notify(object? sender, VideoEventArgs eventArgs)
        {
            if (sender is Channel channel)
            {
                Console.WriteLine($"{Name} received notification from {channel.Name} is {eventArgs.Video}");
            }

        }
    }
}
