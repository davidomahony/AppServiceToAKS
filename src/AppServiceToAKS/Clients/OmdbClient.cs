using Movie.API.Exceptions;
using Movie.API.Models;
using Newtonsoft.Json;

namespace Movie.API.Clients
{
    public class OmdbClient : IOmdbClient
    {
        private readonly HttpClient _httpClient;

        public OmdbClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<Models.Movie> IOmdbClient.GetMovieInfo(string movieName)
        {
            var response = await _httpClient.GetAsync($"/t={movieName}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new MovieNotFoundException();
            }

            return JsonConvert.DeserializeObject<Models.Movie>(await response.Content.ReadAsStringAsync());
        }
    }
}
