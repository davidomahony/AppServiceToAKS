﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.API.Controllers;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Movie.API.Models.Responses;
using Movie.API.Services;

namespace Movie.API.UnitTests.Controllers
{
    [TestFixture]
    public class WatchListControllerTests
    {
        private Mock<IWatchListServices> _mockWatchListServices;
        private WatchListController _watchListController;

        [SetUp]
        public void Setup()
        {
            _mockWatchListServices = new Mock<IWatchListServices>();
            _watchListController = new WatchListController(_mockWatchListServices.Object);
        }

        [Test]
        public void Constructor_Validation_Valid()
        {
            var obj = new WatchListController(_mockWatchListServices.Object);
            Assert.NotNull(obj);
        }

        [Test]
        public void Constructor_Validation_NullMovieService()
        {
            Assert.Throws<ArgumentException>(() => new WatchListController(null));
        }

        [Test]
        public void GetWatchList_ReturnsOk_WithListOfMovies()
        {
            // Arrange
            var movies = new List<MovieInfo> { new MovieInfo { Title = "Movie 1" } };
            _mockWatchListServices.Setup(x => x.ListWatchedMovies()).Returns(movies);

            // Act
            var result = _watchListController.GetWatchList() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(movies, (result.Value as GetWatchListResponse).Movies);
        }

        [Test]
        public void GetWatchList_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockWatchListServices.Setup(x => x.ListWatchedMovies()).Throws(new Exception());

            // Act
            var result = _watchListController.GetWatchList() as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public void AddMovie_ReturnsAccepted_WhenMovieIsAdded()
        {
            // Arrange
            var movieToAdd = new MovieBase { Title = "Movie 1" };

            // Act
            var result = _watchListController.AddMovie(movieToAdd) as AcceptedResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(202, result.StatusCode);
        }

        [Test]
        public void AddMovie_ReturnsNotFound_WhenMovieIsNotFound()
        {
            // Arrange
            var movieToAdd = new MovieBase { Title = "Movie 1" };
            _mockWatchListServices.Setup(x => x.AddWatchedMovie(movieToAdd)).Throws(new MovieNotFoundException());

            // Act
            var result = _watchListController.AddMovie(movieToAdd) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void AddMovie_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var movieToAdd = new MovieBase { Title = "Movie 1" };
            _mockWatchListServices.Setup(x => x.AddWatchedMovie(movieToAdd)).Throws(new Exception());

            // Act
            var result = _watchListController.AddMovie(movieToAdd) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public void RemoveMovie_ReturnsAccepted_WhenMovieIsRemoved()
        {
            // Arrange
            var movieToRemove = new MovieBase { Title = "Movie 1" };

            // Act
            var result = _watchListController.RemoveMovie(movieToRemove) as AcceptedResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(202, result.StatusCode);
        }

        [Test]
        public void RemoveMovie_ReturnsNotFound_WhenMovieIsNotInWatchList()
        {
            // Arrange
            var movieToRemove = new MovieBase { Title = "Movie 1" };
            _mockWatchListServices.Setup(x => x.RemoveWatchedMovie(movieToRemove)).Throws(new MovieNotFoundException());

            // Act
            var result = _watchListController.RemoveMovie(movieToRemove) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void RemoveMovie_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var movieToRemove = new MovieBase { Title = "Movie 1" };
            _mockWatchListServices.Setup(x => x.RemoveWatchedMovie(movieToRemove)).Throws(new Exception());

            // Act
            var result = _watchListController.RemoveMovie(movieToRemove) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}