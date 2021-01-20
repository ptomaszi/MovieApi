using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApi.Repositories
{
    public interface IMovieStatsRepository
    {
        IEnumerable<MovieStat> Get();
    }
}
