namespace Movie.API.Models.Responses
{
    public class ListWatchedMoviesReponse
    {
        public IEnumerable<MovieRated> WatchedMovies { get; set; }
    }
}
