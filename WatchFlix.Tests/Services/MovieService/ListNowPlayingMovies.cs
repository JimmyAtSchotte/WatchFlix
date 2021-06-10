using System.Threading.Tasks;
using ArrangeDependencies.Autofac;
using NUnit.Framework;
using WatchFlix.Core.Services;
using WatchFlix.Tests.Extensions;

namespace WatchFlix.Tests.Services.MovieService
{
    [TestFixture]
    public class ListNowPlayingMovies
    {
        [Test]
        public async Task ShouldListTopRatedMovies()
        {
            var arrange = Arrange.Dependencies<IMovieService, WatchFlix.Services.MovieService>(dependencies => dependencies.UseTMDbClient());
            
            var movieSerivce = arrange.Resolve<IMovieService>();
            
            var movies = await movieSerivce.ListNowPlayingMovies();
            
            Assert.IsNotEmpty(movies);
        }
        
    }
}