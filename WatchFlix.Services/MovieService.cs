using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Trending;
using WatchFlix.Core.Services;

namespace WatchFlix.Services
{
    public class MovieService : IMovieService
    {
        private readonly TMDbClient _client;

        public MovieService(TMDbClient client)
        {
            _client = client;
        }
        
        public async Task<IEnumerable<IMovie>> List()
        {
            var movies = await _client.GetTrendingMoviesAsync(TimeWindow.Day);
            return movies.Results.Select(x => new Movie());
        }
    }

    public class Movie : IMovie
    {

    }
}