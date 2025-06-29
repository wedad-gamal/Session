namespace Session.Events
{
    public class Channel
    {
        public Channel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Video> Videos { get; set; } = new List<Video>();
        public List<Subsriber> Subsribers { get; set; } = new List<Subsriber>();
        public void AddVideo(Video video)
        {
            Videos.Add(video);
            OnVidoeUpload?.Invoke(this, new VideoEventArgs(video));
        }

        public void AddSubscriber(Subsriber subsriber)
        {
            Subsribers.Add(subsriber);
            OnVidoeUpload += subsriber.Notify;

        }
        public void RemoveSubscriber(Subsriber subsriber)
        {
            Subsribers.Remove(subsriber);
            OnVidoeUpload -= subsriber.Notify;
        }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
        public event EventHandler<VideoEventArgs> OnVidoeUpload;
    }
}
