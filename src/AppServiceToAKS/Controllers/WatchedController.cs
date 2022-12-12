using Microsoft.AspNetCore.Mvc;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Movie.API.Models.Responses;
using Movie.API.Services;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchedController : ControllerBase
    {
        private readonly IWatchedMoviesService _watchedMoviesService;

        public WatchedController(IWatchedMoviesService watchedMoviesService)
        {
            _watchedMoviesService = watchedMoviesService;
        }

        [HttpGet()]
        public IActionResult GetWatchedMovies()
        {

            try
            {
                return Ok(
                    new GetWatchedMoviesReponse()
                    {
                        WatchedMovies = _watchedMoviesService.ListWatchedMovies()
                    });
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("Add")]
        public IActionResult AddWatchedMovies([FromBody] MovieRated ratedMovie)
        {
            try
            {
                _watchedMoviesService.AddWatchedMovies(ratedMovie);
                return Accepted();
            }
            catch (MovieNotFoundException)
            {
                return NotFound("Movie does not exist");
            }
        }
    }
}
