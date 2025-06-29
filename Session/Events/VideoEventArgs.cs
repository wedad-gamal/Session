namespace Session.Events
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }

        public VideoEventArgs(Video video)
        {
            Video = video;
        }
    }
}
