using Microsoft.AspNetCore.Mvc.Testing;
using Movie.API.Tests.Configuration;
using System.Net;

namespace Movie.API.Tests.Controllers
{
    [TestFixture]
    public class HealthCheckTests
    {
        private TestWebApplicationFactory _webApplicationFactory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _webApplicationFactory = new TestWebApplicationFactory();
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
