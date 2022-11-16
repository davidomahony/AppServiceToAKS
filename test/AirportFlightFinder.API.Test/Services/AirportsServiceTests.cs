using AirportFlightFinder.API.Services;
using AirportFlightFinder.API.Services.Interface;
using AirportFlightFinder.Models.Data;

namespace AirportFlightFinder.API.Test.Services
{
    [TestFixture]
    public class AirportsServiceTests
    {
        private IAirportsService _airportService;

        [SetUp]
        public void SetUp()
        {
            _airportService = new AirportsService();
        }

        [Test]
        public void ListAirports_Valid()
        {
            var expected = new List<Airport>()
            {
                new Airport("cork", "ireland", "ork")
            };

            var airports = _airportService.ListAirports();

            CollectionAssert.AreEqual(expected, airports);
        }

        [Test]
        public void RemoveAirports_Valid()
        {
            var airportToRemove = new Airport("cork", "ireland", "ork");
            var airports = _airportService.ListAirports();
            Assert.IsTrue(airports.Contains(airportToRemove));

            _airportService.RemoveAirport(airportToRemove);
            Assert.IsFalse(airports.Contains(airportToRemove));
        }

        [Test]
        public void AddAirports_Valid()
        {
            var airportToAdd = new Airport("dublin", "ireland", "dub");
            var airports = _airportService.ListAirports();
            Assert.IsFalse(airports.Contains(airportToAdd));

            _airportService.AddAirport(airportToAdd);
            Assert.IsTrue(airports.Contains(airportToAdd));
        }
    }
}
