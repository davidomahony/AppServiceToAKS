namespace Movie.API.Models.Movies
{
    public class RatedMovieInfo : MovieInfo, IRatedMovie
    {
        public RatedMovieInfo(MovieInfo info, IRatedMovie ratedMovie)
        {
            Title = info.Title;
            ImdbRating = info.ImdbRating;
            Genre = info.Genre;
            MyRating = ratedMovie.MyRating;
        }

        public RatedMovieInfo() { }

        public float MyRating { get; set; }
    }
}
