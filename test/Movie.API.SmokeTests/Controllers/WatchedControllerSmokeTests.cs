using Movie.API.Models.Responses;
using System.Net;
using System.Net.Http.Json;

namespace Movie.API.SmokeTests.Controllers
{
    public class WatchedControllerSmokeTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://as-movie-demo.azurewebsites.net")
            };
        }

        [Test]
        public async Task ValidateHealthCheck()
        {
            var response = await _client.GetAsync("/Watched");
            var body = await response.Content.ReadFromJsonAsync<GetWatchedMoviesReponse>();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(body, Is.Not.Null);
        }
    }
}
