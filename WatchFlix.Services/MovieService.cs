using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Trending;
using WatchFlix.Core.Services;

namespace WatchFlix.Services
{
    public class MovieService : IMovieService
    {
        private readonly ITMDbClientWrapper _client;
        private readonly ILogger _logger;

        public MovieService(ITMDbClientWrapper client, ILogger<MovieService> logger)
        {
            _client = client;
            _logger = logger;
        }
        
        public async Task<IEnumerable<IMovie>> ListTopRatedMovies()
        {
            try
            {
                var movies = await _client.GetMovieTopRatedListAsync();
                return movies.Results.Select(ConvertToMovie());
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
          
            return Enumerable.Empty<IMovie>();
        }
     
        public async Task<IEnumerable<IMovie>> ListUpcomingMovies()
        {
            try
            {
                var movies = await _client.GetMovieUpcomingListAsync();
                return movies.Results.Select(ConvertToMovie());
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return Enumerable.Empty<IMovie>();
        }

        public async Task<IEnumerable<IMovie>> ListNowPlayingMovies()
        {
            try
            {
                var movies = await _client.GetMovieNowPlayingListAsync();

                return movies.Results.Select(ConvertToMovie());
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return Enumerable.Empty<IMovie>();
        }
        
        private static Func<SearchMovie, Movie> ConvertToMovie()
        {
            return searchMovie =>new Movie()
                {
                    Title = searchMovie.Title,
                    Poster =  $"https://www.themoviedb.org/t/p/w300_and_h450_bestv2/{searchMovie.PosterPath}"
                };
        }
    }

  
}