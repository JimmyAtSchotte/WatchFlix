using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArrangeDependencies.Autofac;
using ArrangeDependencies.Autofac.Extensions;
using Moq;
using NUnit.Framework;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
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
        
        [Ignore("Non-overridable members (here: TMDbClient.GetMovieNowPlayingListAsync) may not be used in setup / verification expressions.")]
        [Test]
        public async Task ShouldSetProperties()
        {
            var movie = new SearchMovie()
            {
                Title = "Gudfadern 7",
                PosterPath = "gudfadern.jpg"
            };
            
            var arrange = Arrange.Dependencies<IMovieService, WatchFlix.Services.MovieService>(dependencies =>
            {
                dependencies.UseMock<TMDbClient>(mock =>
                {
                    mock.Setup(x => x.GetMovieNowPlayingListAsync(null, 0, null, default(CancellationToken)))
                        .Returns(Task.FromResult(new SearchContainerWithDates<SearchMovie>()
                        {
                            Results = new List<SearchMovie>()
                            {
                                movie
                            }
                        }));
                });
            });
            
            var movieSerivce = arrange.Resolve<IMovieService>();
            
            var result = (await movieSerivce.ListNowPlayingMovies()).FirstOrDefault();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(movie.Title, result.Title);
                Assert.AreEqual(movie.PosterPath, result.Poster);
            });
        }
    }
}