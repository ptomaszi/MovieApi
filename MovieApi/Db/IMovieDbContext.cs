using MovieApi.Models;
using System.Collections.Generic;

namespace MovieApi.Db
{
    public interface IMovieDbContext
    {
        List<MovieMetaData> GetMovieMetaData();

        List<Stat> GetMovieStat();
    }
}
