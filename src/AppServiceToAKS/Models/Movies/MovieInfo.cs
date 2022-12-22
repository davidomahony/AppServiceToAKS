namespace Movie.API.Models.Movies
{
    public class MovieInfo : MovieBase
    {
        public string Genre { get; set; } = string.Empty;

        public string ImdbRating { get; set; } = string.Empty;
    }
}
