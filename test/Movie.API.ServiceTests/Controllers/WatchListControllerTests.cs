using Movie.API.Models.Responses;
using Movie.API.Tests.Configuration;
using System.Net.Http.Json;
using System.Net;

namespace Movie.API.ServiceTests.Controllers
{
    [TestFixture]
    public  class WatchListControllerTests
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
        public async Task GetEmptyMovieCollection()
        {
            // Act 
            var response = await _client.GetAsync("/WatchList");
            Assert.That(response, Is.Not.Null);

            var responseBody = await response.Content.ReadFromJsonAsync<GetWatchListResponse>();
            Assert.That(responseBody, Is.Not.Null);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseBody.Movies.Any(), Is.EqualTo(false));
        }
    }
}
