using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrangeDependencies.Autofac;
using ArrangeDependencies.Autofac.Extensions;
using NUnit.Framework;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using WatchFlix.Core.Services;
using WatchFlix.Services;
using WatchFlix.Tests.Extensions;

namespace WatchFlix.Tests.Services.MovieService
{
    [TestFixture]
    public class ListTopRatedMovies
    {
        [Test]
        public async Task ShouldListTopRatedMovies()
        {
            var arrange = Arrange.Dependencies<IMovieService, WatchFlix.Services.MovieService>(dependencies =>
            {
                dependencies.UseImplementation<ITMDbClientWrapper, TMDbClientWrapper>();
                dependencies.UseTMDbClient();
            });
            
            var movieSerivce = arrange.Resolve<IMovieService>();
            
            var movies = await movieSerivce.ListTopRatedMovies();
            
            Assert.IsNotEmpty(movies);
        }
        
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
                dependencies.UseMock<ITMDbClientWrapper>(mock =>
                {
                    mock.Setup(x => x.GetMovieTopRatedListAsync())
                        .Returns(Task.FromResult(new SearchContainer<SearchMovie>()
                        {
                            Results = new List<SearchMovie>()
                            {
                                movie
                            }
                        }));
                });
            });
            
            var movieSerivce = arrange.Resolve<IMovieService>();
            
            var result = (await movieSerivce.ListTopRatedMovies()).FirstOrDefault();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(movie.Title, result.Title);
                Assert.AreEqual($"https://www.themoviedb.org/t/p/w300_and_h450_bestv2/{movie.PosterPath}", result.Poster);
            });
        }
        
        [TestCase(1)]
        [TestCase(10)]
        public async Task ShouldReturnListOfResultWithCount(int count)
        {
            var arrange = Arrange.Dependencies<IMovieService, WatchFlix.Services.MovieService>(dependencies =>
            {
                dependencies.UseMock<ITMDbClientWrapper>(mock =>
                {
                    mock.Setup(x => x.GetMovieTopRatedListAsync())
                        .Returns(Task.FromResult(new SearchContainer<SearchMovie>()
                        {
                            Results = Enumerable.Range(0, count).Select(_ => new SearchMovie()).ToList()
                        }));
                });
            });
            
            var movieSerivce = arrange.Resolve<IMovieService>();

            var result = await movieSerivce.ListTopRatedMovies();
            
            Assert.AreEqual(count, result.Count());
        }
        
        [Test]
        public async Task ShouldReturnEmptyListWhenAPIThrows()
        {
            var arrange = Arrange.Dependencies<IMovieService, WatchFlix.Services.MovieService>(dependencies =>
            {
                dependencies.UseMock<ITMDbClientWrapper>(mock =>
                {
                    mock.Setup(x => x.GetMovieTopRatedListAsync())
                        .Throws<Exception>();
                });
            });
            
            var movieSerivce = arrange.Resolve<IMovieService>();

            var result = await movieSerivce.ListTopRatedMovies();
            
            Assert.IsEmpty(result);
        }
    }
}