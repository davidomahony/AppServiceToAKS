namespace Movie.API.Models
{
    public class Movie
    {
        public string Title { get; set; }

        public IEnumerable<string> Genre { get; set; }

        public DateTime Released { get; set; }  

        public float ImdbRating { get; set; }
    }
}
