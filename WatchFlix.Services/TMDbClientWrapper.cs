using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace WatchFlix.Services
{
    public interface ITMDbClientWrapper
    {
        Task<SearchContainer<SearchMovie>> GetMovieTopRatedListAsync();
        Task<SearchContainerWithDates<SearchMovie>> GetMovieUpcomingListAsync();
        Task<SearchContainerWithDates<SearchMovie>> GetMovieNowPlayingListAsync();
    }
    
    public class TMDbClientWrapper : ITMDbClientWrapper
    {
        private readonly TMDbClient _client;

        public TMDbClientWrapper(TMDbClient client)
        {
            _client = client;
        }
        
        public async Task<SearchContainer<SearchMovie>> GetMovieTopRatedListAsync()
        {
            return  await _client.GetMovieTopRatedListAsync();
        }
     
        public async Task<SearchContainerWithDates<SearchMovie>> GetMovieUpcomingListAsync()
        {
            return await _client.GetMovieUpcomingListAsync();
        }

        public async Task<SearchContainerWithDates<SearchMovie>> GetMovieNowPlayingListAsync()
        {
            return await _client.GetMovieNowPlayingListAsync();
        }
    }
}