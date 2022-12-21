using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Movie.API.Models.Movies;
using Movie.API.Models.Requests;
using Movie.API.Models.Responses;
using Movie.API.Tests.Configuration;

namespace Movie.API.Tests.Controllers
{
    [TestFixture]
    public class WatchedControllerIntegrationTests
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
            var response = await _client.GetAsync("/Watched");
            Assert.That(response, Is.Not.Null);

            var responseBody = await response.Content.ReadFromJsonAsync<GetWatchedMoviesReponse>();
            Assert.That(responseBody, Is.Not.Null);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseBody.WatchedMovies.Any(), Is.EqualTo(false));
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
                    Title = "Good Movie"
                }
            };

            // Act
            var addResponse = await _client.PostAsJsonAsync("/Watched/Add", request);
            addResponse.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/Watched");
            Assert.That(getResponse, Is.Not.Null);

            var getResponseBody = await getResponse.Content.ReadFromJsonAsync<GetWatchedMoviesReponse>();
            Assert.That(getResponseBody, Is.Not.Null);

            // Assert
            Assert.That(addResponse.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            Assert.That(getResponseBody.WatchedMovies.Any(x => x.Title.Equals("Good Movie", StringComparison.OrdinalIgnoreCase) 
                && x.MyRating == 4), Is.EqualTo(true));
        }
    }
}
