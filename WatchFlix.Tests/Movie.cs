using System.Threading.Tasks;
using ArrangeDependencies.Autofac;
using ArrangeDependencies.Autofac.Extensions;
using NUnit.Framework;
using TMDbLib.Client;
using WatchFlix.Core.Services;
using WatchFlix.Services;

namespace WatchFlix.Tests
{
    [TestFixture]
    public class Movie
    {
        private static readonly TMDbClient Client = new TMDbClient("9d9273dd0511107b21baa2cb13b70181");
        
        [Test]
        public async Task ShouldListMovies()
        {
            var arrange = Arrange.Dependencies<IMovieService, MovieService>(
                dependencies =>
                {
                    dependencies.UseImplementation<TMDbClient, TMDbClient>(Client);
                });
            
            var movieSerivce = arrange.Resolve<IMovieService>();
            
            var movies = await movieSerivce.List();
            
            Assert.IsNotEmpty(movies);
            
        }
    }
}