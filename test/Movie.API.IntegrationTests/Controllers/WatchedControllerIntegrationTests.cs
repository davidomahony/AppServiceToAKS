using Microsoft.AspNetCore.Mvc.Testing;
using Movie.API.Models.Movies;
using Movie.API.Models.Requests;
using Movie.API.Models.Responses;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Movie.API.IntegrationTests.Controllers
{
    [TestFixture]
    public class WatchedControllerIntegrationTests
    {
        private WebApplicationFactory<Program> _webApplicationFactory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>();
            _client = _webApplicationFactory.CreateClient();
        }

        [Test]
        public async Task GetEmptyMovieCollection()
        {
            // Act 
            var response = await _client.GetAsync("/Watched");
            Assert.NotNull(response);

            var responseBody = await response.Content.ReadFromJsonAsync<GetWatchedMoviesReponse>();
            Assert.NotNull(responseBody);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(false, responseBody.WatchedMovies.Any());
        }

        [Test]
        public async Task AddMovieToWatchedList()
        {
            //Arrange
            var request = new AddWatchedMovieRequest()
            {
                WatchedMovie = new MovieRated()
                {
                    MyRating = 4,
                    Title = "string"
                }
            };

            // Act
            var addResponse = await _client.PostAsJsonAsync("/Watched/Add", request);
            addResponse.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/Watched");
            Assert.NotNull(getResponse);

            var getResponseBody = await getResponse.Content.ReadFromJsonAsync<GetWatchedMoviesReponse>();
            Assert.NotNull(getResponseBody);

            // Assert
            Assert.AreEqual(HttpStatusCode.Accepted, addResponse.StatusCode);
            Assert.AreEqual(true, 
                getResponseBody.WatchedMovies.Any(x => x.Title.Equals("string", StringComparison.OrdinalIgnoreCase) 
                && x.MyRating == 4));
        }
    }
}
