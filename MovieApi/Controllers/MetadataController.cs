using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApi.Business;
using MovieApi.Db;
using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly IMovieMetaDataValidator _movieMetaDataValidator;
        private readonly IMovieDbContext _movieDbContext;

        public MetadataController(IMovieDbContext movieDbContext, IMovieMetaDataValidator movieMetaDataValidator)
        {
            _movieMetaDataValidator = movieMetaDataValidator;
            _movieDbContext = movieDbContext;
        }

        [Route("{movieId:int}")]
        public ActionResult<IEnumerable<MovieMetaData>> Get(int movieId)
        {
            IEnumerable<MovieMetaData> metadata = _movieDbContext.GetMovieMetaData();

            IEnumerable<MovieMetaData> matchingMovies = metadata.Where(movie => movie.MovieId == movieId);

            if (matchingMovies == null)
            {
                return NotFound();
            }

            IEnumerable<MovieMetaData> movieMetaData = matchingMovies
                .GroupBy(movie => movie.Language)
                .Select((movie) => movie.OrderByDescending(g=>g.Id).First())
                .ToList();
                        
            IEnumerable<MovieMetaData> validMovieMetaData = movieMetaData.Where(x => _movieMetaDataValidator.IsRecordValid(x));
            
            if (validMovieMetaData == null || validMovieMetaData.Count() == 0)
            {
                return BadRequest();
            }
                        

            return Ok(validMovieMetaData.OrderBy(x => x.Language));
        }

        [HttpPost]
        public ActionResult Post([FromBody] MovieMetaData model)
        {
            return CreatedAtAction("Post", model);
        }
    }
}
