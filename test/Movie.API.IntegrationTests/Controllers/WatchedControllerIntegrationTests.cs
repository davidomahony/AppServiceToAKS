using Microsoft.AspNetCore.Mvc.Testing;
using Movie.API.Models.Movies;
using Movie.API.Models.Requests;
using Movie.API.Models.Responses;
using System.Net;
using System.Net.Http.Json;

namespace Movie.API.IntegrationTests.Controllers
{
    [TestFixture]
    public class WatchedControllerIntegrationTests
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
                    Title = "zzzzzzzzzz"
                }
            };

            // Act
            var addResponse = await _client.PostAsJsonAsync("/Watched/Add", request);

            var con = await addResponse.Content.ReadAsStringAsync();

            addResponse.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/Watched");
            Assert.NotNull(getResponse);

            var getResponseBody = await getResponse.Content.ReadFromJsonAsync<GetWatchedMoviesReponse>();
            Assert.NotNull(getResponseBody);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, addResponse.StatusCode);
            Assert.AreEqual(true, 
                getResponseBody.WatchedMovies.Any(x => x.Title.Equals("string", StringComparison.OrdinalIgnoreCase) 
                && x.MyRating == 4));
        }
    }
}
