using AirportFlightFinder.API.Services.Interface;
using AirportFlightFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportFlightFinder.API.Clients;

namespace AirportFlightFinder.API.Test.Clients
{
    [TestFixture]
    public class FlightInfoClientTests
    {
        private IFlightInfoClient _flightInfoClient;

        [Test]
        public async Task SetUpClient()
        {
            var test = new HttpClient()
            {
                BaseAddress = new Uri("https://app.goflightlabs.com")
            };

            _flightInfoClient = new FlightInfoClient(test);

            var response = await _flightInfoClient.GetRealTimeFlightInfo("FR6639");

            Assert.NotNull(response);
        }
    }
}
