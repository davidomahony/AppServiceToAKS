using Movie.API.Clients;
using Movie.API.Models.Movies;

namespace Movie.API.Services
{
    public class WatchedMoviesService : IWatchedMoviesService
    {
        private readonly IList<RatedMovieInfo> _ratedMovies;
        private readonly IOmdbClient _movieClient;

        public WatchedMoviesService(IOmdbClient movieClient)
        {
            _ratedMovies = new List<RatedMovieInfo>();
            _movieClient = movieClient ?? throw new ArgumentException(nameof(movieClient));
        }

        public async void AddWatchedMovies(MovieRated watchedMovie)
        {
            var info = await this.GetMovieInfo(watchedMovie);
            _ratedMovies.Add(new RatedMovieInfo(info, watchedMovie));
        }

        public IEnumerable<RatedMovieInfo> ListWatchedMovies() => _ratedMovies;

        private Task<MovieInfo> GetMovieInfo(MovieRated movie) => _movieClient.GetMovieInfo(movie.Title);
    }
}
