using Movie.API.Models.Movies;

namespace Movie.API.Models.Requests
{
    public class AddWatchedMovieRequest
    {
        public MovieRated WatchedMovie { get; set; }
    }
}
