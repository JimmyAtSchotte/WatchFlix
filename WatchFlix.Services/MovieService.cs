using System;
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
        
        public async Task<IEnumerable<IMovie>> ListTopRatedMovies()
        {
            var movies = await _client.GetMovieTopRatedListAsync();
            return movies.Results.Select(ConvertToMovie());
        }
     
        public async Task<IEnumerable<IMovie>> ListUpcomingMovies()
        {
            var movies = await _client.GetMovieUpcomingListAsync();
            return movies.Results.Select(ConvertToMovie());
        }

        public async Task<IEnumerable<IMovie>> ListNowPlayingMovies()
        {
            var movies = await _client.GetMovieNowPlayingListAsync();
            return movies.Results.Select(ConvertToMovie());
        }
        
        private static Func<SearchMovie, Movie> ConvertToMovie()
        {
            return x => new Movie();
        }
    }
}