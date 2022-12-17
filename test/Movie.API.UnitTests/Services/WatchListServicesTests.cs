using Moq;
using Movie.API.Clients;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Movie.API.Services;

namespace Movie.API.UnitTests.Services
{

    [TestFixture]
    public class WatchListServicesTests
    {
        private Mock<IOmdbClient> _movieClient;
        private WatchListServices _watchListServices;

        [SetUp]
        public void TestSetup()
        {
            _movieClient = new Mock<IOmdbClient>();
            _watchListServices = new WatchListServices(_movieClient.Object);
        }

        [Test]
        public void Constructor_Validation_Valid()
        {
            var obj = new WatchListServices(_movieClient.Object);
            Assert.NotNull(obj);
            Assert.That(obj.ListWatchedMovies().Count() == 0);
        }

        [Test]
        public void Constructor_Validation_NullMovieService()
        {
            Assert.Throws<ArgumentException>(() => new WatchListServices(null));
        }

        [Test]
        public async Task AddWatchedMovie_MovieAddedToList_MovieIsAddedToList()
        {
            // Arrange
            var movie = new MovieBase() { Title = "Test Movie" };
            var expected = new MovieInfo() { Title = "Test Movie" };
            _movieClient.Setup(x => x.GetMovieInfo(It.IsAny<string>())).ReturnsAsync(expected);

            // Act
            await _watchListServices.AddWatchedMovie(movie);

            // Assert
            var result = _watchListServices.ListWatchedMovies();
            Assert.AreEqual(expected, result.FirstOrDefault());
        }

        [Test]
        public async Task RemoveWatchedMovie_MovieRemovedFromList_MovieIsRemovedFromList()
        {
            // Arrange
            var movieToRemove = new MovieBase() { Title = "Test Movie" };
            var expected = new MovieInfo() { Title = "Test Movie" };
            _movieClient.Setup(x => x.GetMovieInfo(It.IsAny<string>())).ReturnsAsync(expected);

            await _watchListServices.AddWatchedMovie(movieToRemove);

            // Act
            _watchListServices.RemoveWatchedMovie(movieToRemove);

            // Assert
            var result = _watchListServices.ListWatchedMovies();
            Assert.IsEmpty(result);
        }

        [Test]
        public void RemoveWatchedMovie_MovieNotInList_ThrowsMovieNotFoundException()
        {
            // Arrange
            var movieToRemove = new MovieBase() { Title = "Test Movie" };

            // Act
            Assert.Throws<MovieNotFoundException>(() => _watchListServices.RemoveWatchedMovie(movieToRemove));
        }
    }
}
