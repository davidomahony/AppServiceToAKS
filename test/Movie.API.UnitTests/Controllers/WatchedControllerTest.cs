using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.API.Controllers;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Movie.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.UnitTests.Controllers
{
    public class WatchedControllerTest
    {
        private Mock<IWatchedMoviesService> _watchedMoviesService;
        private WatchedController _watchedController;
        [SetUp]
        public void Setup()
        {
            _watchedMoviesService = new Mock<IWatchedMoviesService>();
            _watchedController = new WatchedController(_watchedMoviesService.Object);
        }

        [Test]
        public void GetWatchedMovies_ReturnsOkResult()
        {
            //Arrange
            var listWatchedMovies = new List<RatedMovieInfo>
            {
                new RatedMovieInfo{ MyRating = 9},
                new RatedMovieInfo{ MyRating = 8},
                new RatedMovieInfo{ MyRating = 7},
            };
            _watchedMoviesService.Setup(x => x.ListWatchedMovies()).Returns(listWatchedMovies);

            //Act
            var result = _watchedController.GetWatchedMovies();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetWatchedMovies_ReturnsInternalServerErrorResult()
        {
            //Arrange
            _watchedMoviesService.Setup(x => x.ListWatchedMovies()).Throws<Exception>();

            //Act
            var result = _watchedController.GetWatchedMovies();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<ObjectResult>(result);
        }

        [Test]
        public void AddWatchedMovies_ReturnsAcceptedResult()
        {
            //Arrange
            var ratedMovie = new MovieRated { MyRating = 9 };
            _watchedMoviesService.Setup(x => x.AddWatchedMovies(ratedMovie)).Verifiable();

            //Act
            var result = _watchedController.AddWatchedMovies(ratedMovie);

            //Assert
            _watchedMoviesService.Verify();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<AcceptedResult>(result);
        }

        [Test]
        public void AddWatchedMovies_ReturnsNotFoundResult()
        {
            //Arrange
            var ratedMovie = new MovieRated { MyRating = 9};
            _watchedMoviesService.Setup(x => x.AddWatchedMovies(ratedMovie)).Throws<MovieNotFoundException>();

            //Act
            var result = _watchedController.AddWatchedMovies(ratedMovie);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }
    }
}
