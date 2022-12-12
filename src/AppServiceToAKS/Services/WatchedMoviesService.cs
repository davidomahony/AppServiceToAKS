using Movie.API.Clients;
using Movie.API.Exceptions;
using Movie.API.Models;

namespace Movie.API.Services
{
    public class WatchedMoviesService : IWatchedMoviesService
    {
        private readonly IList<RatedMovieInfo> _ratedMovies;
        private readonly IOmdbClient _movieClient;

        public WatchedMoviesService(IOmdbClient movieClient)
        {
            _ratedMovies = new List<RatedMovieInfo>();
            _movieClient = movieClient;
        }

        public void AddWatchedMovies(MovieRated watchedMovie)
        {
            var info = this.GetMovieInfo(watchedMovie);
            _ratedMovies.Add(new RatedMovieInfo(info, watchedMovie));
        }

        public IEnumerable<RatedMovieInfo> ListWatchedMovies()
        {
            return _ratedMovies;
        }

        private MovieInfo GetMovieInfo(MovieRated movie)
        {
            return _movieClient.GetMovieInfo(movie.Title).Result;
        }
    }
}
