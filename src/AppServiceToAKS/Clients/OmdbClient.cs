using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Newtonsoft.Json;

namespace Movie.API.Clients
{
    public class OmdbClient : IOmdbClient
    {
        private readonly HttpClient _httpClient;

        public OmdbClient(HttpClient httpClient)
        {
            // need to get config from app settings
            _httpClient = httpClient;
        }

        async Task<MovieInfo> IOmdbClient.GetMovieInfo(string movieName)
        {
            var response = await _httpClient.GetAsync($"?t={movieName}&apikey=xxx");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new MovieNotFoundException();
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieInfo>(content);
        }
    }
}
