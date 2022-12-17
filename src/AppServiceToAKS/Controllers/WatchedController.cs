using Microsoft.AspNetCore.Mvc;
using Movie.API.Exceptions;
using Movie.API.Models.Movies;
using Movie.API.Models.Requests;
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
            _watchedMoviesService = watchedMoviesService ?? throw new ArgumentException(nameof(watchedMoviesService));
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
        public async Task<IActionResult> AddWatchedMovies([FromBody] AddWatchedMovieRequest ratedMovieRequest)
        {
            try
            {
                await _watchedMoviesService.AddWatchedMovies(ratedMovieRequest.WatchedMovie);
                return Accepted();
            }
            catch (MovieNotFoundException)
            {
                return NotFound("Movie does not exist");
            }
        }
    }
}
