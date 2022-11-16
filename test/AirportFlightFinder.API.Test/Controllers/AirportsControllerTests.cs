using AirportFlightFinder.API.Controllers;
using AirportFlightFinder.API.Services.Interface;
using AirportFlightFinder.Models.Data;
using AirportFlightFinder.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AirportFlightFinder.API.Test.Controllers
{
    [TestFixture]
    public class AirportsControllerTests
    {
        private Mock<IAirportsService> _airportsService;
        private AirportsController _airportsController;

        [SetUp]
        public void SetUp()
        {
            _airportsService = new Mock<IAirportsService>();
            _airportsController = new AirportsController(_airportsService.Object);
            Assert.NotNull(_airportsController);
        }

        [Test]
        public void ListAirports_Valid()
        {
            var airportsExpected = new List<Airport>();
            _airportsService.Setup(x => x.ListAirports()).Returns(airportsExpected);
        
            var result = _airportsController.ListAirports();
            Assert.NotNull(result);

            var okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);

            var airportsResponse = okResult.Value as GetAirportsResponse;
            Assert.NotNull(airportsResponse);
            Assert.NotNull(airportsResponse.Airports);
            CollectionAssert.AreEqual(airportsExpected, airportsResponse.Airports);
            _airportsService.Verify(x => x.ListAirports(), Times.Once);
        }
    }
}
