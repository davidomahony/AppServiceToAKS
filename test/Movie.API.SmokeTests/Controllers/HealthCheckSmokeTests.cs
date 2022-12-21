using System.Net;

namespace Movie.API.SmokeTests.Controllers
{
    public class HealthCheckSmokeTests
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
            var response = await _client.GetAsync("/hc");
            var body = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(body, Is.EqualTo("Healthy"));
        }
    }
}