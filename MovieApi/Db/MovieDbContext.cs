using MovieApi.Business;
using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Db
{
    public class MovieDbContext : IMovieDbContext
    {   
        public List<MovieMetaData> GetMovieMetaData()
        {
            IRecordsReader reader = new RecordsReader();

            return reader.GetMetaDataRecords();
        }

        public List<Stat> GetMovieStat()
        {
            IRecordsReader reader = new RecordsReader();

            return reader.GetStatsRecords();
        }
    }
}
