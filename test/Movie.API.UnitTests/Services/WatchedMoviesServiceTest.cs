using Moq;
using Movie.API.Clients;
using Movie.API.Models.Movies;
using Movie.API.Services;

namespace Movie.API.UnitTests.Services
{

    [TestFixture]
    public class WatchedMoviesServiceTest
    {
        private WatchedMoviesService _watchedMoviesService;
        private Mock<IOmdbClient> _movieClient;

        private string testMovieTitle = "Test Title";

        [SetUp]
        public void TestSetup()
        {
            _movieClient = new Mock<IOmdbClient>();
            _watchedMoviesService = new WatchedMoviesService(_movieClient.Object);
        }

        [Test]
        public void Constructor_Validation_Valid()
        {
            var obj = new WatchedMoviesService(_movieClient.Object);
            Assert.NotNull(obj);
            Assert.That(obj.ListWatchedMovies().Count() == 0);
        }

        [Test]
        public void Constructor_Validation_NullMovieService()
        {
            Assert.Throws<ArgumentException>(() => new WatchedMoviesService(null));
        }

        [Test]
        public async Task AddWatchedMovies_WhenGivenMovieRated_ShouldAddToList()
        {
            // Arrange
            var watchedMovie = new MovieRated { Title = testMovieTitle };
            _movieClient.Setup(x => x.GetMovieInfo(testMovieTitle)).ReturnsAsync(new MovieInfo() { Title = testMovieTitle });

            // Act
            await _watchedMoviesService.AddWatchedMovies(watchedMovie);

            // Assert
            Assert.AreEqual(1, _watchedMoviesService.ListWatchedMovies().Count());
        }
    }
}
