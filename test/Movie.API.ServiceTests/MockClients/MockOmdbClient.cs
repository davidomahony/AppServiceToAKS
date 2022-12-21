using Movie.API.Clients;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;

namespace Movie.API.ServiceTests.MockClients
{
    public class MockOmdbClient : IOmdbClient
    {
        private readonly IList<MovieInfo> _mockMovies;

        public MockOmdbClient()
        {
            _mockMovies = new List<MovieInfo>
            {
                new MovieInfo()
                {
                    ImdbRating = "2.3",
                    Genre = "Bad Genre",
                    Title = "Bad Movie"
                },
                new MovieInfo()
                {
                    ImdbRating = "9.3",
                    Genre = "Good Genre",
                    Title = "Good Movie"
                },
            };
        }

        public Task<MovieInfo> GetMovieInfo(string movieName)
        {
            var movie = _mockMovies.FirstOrDefault(x => x.Title.Equals(movieName, StringComparison.OrdinalIgnoreCase));
            if (movie is null)
            {
                throw new MovieNotFoundException();
            }

            return Task.FromResult(movie);
        }
    }
}
