using System.Threading.Tasks;
using NUnit.Framework;
using Watchflix.Data;

namespace WatchFlix.Tests
{
    [TestFixture]
    public class Movie
    {
        [Test]
        public async Task ShouldListMovies()
        {
            var movieSerivce = new MovieService();
            var movies = await movieSerivce.List();
            
            Assert.IsNotEmpty(movies);
            
        }
    }
}