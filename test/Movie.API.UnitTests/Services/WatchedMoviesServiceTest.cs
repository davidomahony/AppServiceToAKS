using Moq;
using Movie.API.Clients;
using Movie.API.Models.Movies;
using Movie.API.Services;

namespace Movie.API.UnitTests.Services
{

    [TestFixture]
    public class WatchedMoviesServiceTest
    {
        private readonly WatchedMoviesService _watchedMoviesService;
        private readonly Mock<IOmdbClient> _movieClient;

        private string testMovieTitle = "Test Title";

        public WatchedMoviesServiceTest()
        {
            _movieClient = new Mock<IOmdbClient>();
            _watchedMoviesService = new WatchedMoviesService(_movieClient.Object);
        }

        [Test]
        public void AddWatchedMovies_WhenGivenMovieRated_ShouldAddToList()
        {
            // Arrange
            var watchedMovie = new MovieRated { Title = testMovieTitle };
            _movieClient.Setup(x => x.GetMovieInfo(testMovieTitle)).ReturnsAsync(new MovieInfo() { Title = testMovieTitle });

            // Act
            _watchedMoviesService.AddWatchedMovies(watchedMovie);

            // Assert
            Assert.AreEqual(1, _watchedMoviesService.ListWatchedMovies().Count());
        }
    }
}
