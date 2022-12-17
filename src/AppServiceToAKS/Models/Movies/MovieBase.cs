using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Movie.API.Models.Movies
{
    public class MovieBase
    {
        [Required]
        public string Title { get; set; }
    }
}
