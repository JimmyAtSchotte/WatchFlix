using System.Collections.Generic;
using System.Threading.Tasks;

namespace WatchFlix.Core.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<IMovie>> ListTopRatedMovies();
        Task<IEnumerable<IMovie>> ListUpcomingMovies();
        Task<IEnumerable<IMovie>> ListNowPlayingMovies();
    }
}