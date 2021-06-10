using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Trending;

namespace Watchflix.Data
{
    public class MovieService
    {
        public async Task<IEnumerable<SearchMovie>> List()
        {
            var client = new TMDbClient("9d9273dd0511107b21baa2cb13b70181");
            var movies = await client.GetTrendingMoviesAsync(TimeWindow.Day);
            return movies.Results;
        }
    }
}