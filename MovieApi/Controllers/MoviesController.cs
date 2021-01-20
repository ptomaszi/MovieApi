using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Repositories;
using System.Collections.Generic;

namespace MovieApi.Controllers
{
    [Route("[controller]/stats")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieStatsRepository _movieStatsRepository;

        public MoviesController(IMovieStatsRepository movieStatsRepository)
        {
            _movieStatsRepository = movieStatsRepository;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<MovieStat>> Get() => Ok(_movieStatsRepository.Get());
    }
}
