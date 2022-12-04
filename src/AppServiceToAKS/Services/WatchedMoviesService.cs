using Movie.API.Clients;
using Movie.API.Exceptions;
using Movie.API.Models;

namespace Movie.API.Services
{
    public class WatchedMoviesService : IWatchedMoviesService
    {
        private readonly IList<MovieRated> _ratedMovies;
        private readonly IOmdbClient _movieClient;

        public WatchedMoviesService(IOmdbClient movieClient)
        {
            _ratedMovies = new List<MovieRated>();
        }

        public void AddWatchedMovies(MovieRated watchedMovie)
        {
            this.ValidateMovie(watchedMovie);
            throw new NotImplementedException();
        }

        public IEnumerable<MovieRated> ListWatchedMovies()
        {
            return _ratedMovies;
        }

        private void ValidateMovie(MovieRated movie)
        {
            var movieInfo = _movieClient.GetMovieInfo(movie.Title);
            if (movieInfo is null)
            {
                throw new MovieNotFoundException();
            }
        }
    }
}
