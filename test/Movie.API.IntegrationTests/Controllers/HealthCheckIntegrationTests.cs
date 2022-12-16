using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Movie.API.IntegrationTests.Controllers
{
    [TestFixture]
    public class HealthCheckIntegrationTests
    {
        private WebApplicationFactory<Startup> _webApplicationFactory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _webApplicationFactory = new WebApplicationFactory<Startup>();
            _client = _webApplicationFactory.CreateClient();
        }

        [Test]
        public async Task ValidateHealthCheck()
        {
            // Act 
            var response = await _client.GetAsync("/hc");
            Assert.NotNull(response);

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Healthy", body);
        }
    }
}
