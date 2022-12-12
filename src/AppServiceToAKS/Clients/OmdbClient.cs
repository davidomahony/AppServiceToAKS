using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Newtonsoft.Json;

namespace Movie.API.Clients
{
    public class OmdbClient : IOmdbClient
    {
        private readonly HttpClient _httpClient;
        private readonly string appKey;

        public OmdbClient(HttpClient httpClient, IConfiguration configuration)
        {
            // need to get config from app settings
            _httpClient = httpClient;

            appKey = configuration["omdbAppKey"];
            if (string.IsNullOrEmpty(appKey))
            {
                throw new InvalidOperationException("Missing OMDB App key from Config");
            }
        }

        async Task<MovieInfo> IOmdbClient.GetMovieInfo(string movieName)
        {
            var response = await _httpClient.GetAsync($"?t={movieName}&apikey={appKey}");
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
