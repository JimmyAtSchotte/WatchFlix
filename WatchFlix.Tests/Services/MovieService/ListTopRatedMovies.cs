using System.Threading.Tasks;
using ArrangeDependencies.Autofac;
using ArrangeDependencies.Autofac.Extensions;
using NUnit.Framework;
using TMDbLib.Client;
using WatchFlix.Core.Services;
using WatchFlix.Services;
using WatchFlix.Tests.Extensions;

namespace WatchFlix.Tests
{
    [TestFixture]
    public class ListTopRatedMovies
    {
        [Test]
        public async Task ShouldListTopRatedMovies()
        {
            var arrange = Arrange.Dependencies<IMovieService, MovieService>(dependencies => dependencies.UseTMDbClient());
            
            var movieSerivce = arrange.Resolve<IMovieService>();
            
            var movies = await movieSerivce.ListTopRatedMovies();
            
            Assert.IsNotEmpty(movies);
        }
    }
}