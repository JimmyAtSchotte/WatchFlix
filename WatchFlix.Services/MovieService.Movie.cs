using WatchFlix.Core.Services;

namespace WatchFlix.Services
{
    public class Movie : IMovie
    {
        public string Title { get; set; }
        public string Poster { get; set; }
    }
}