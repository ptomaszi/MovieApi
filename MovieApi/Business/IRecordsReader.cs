using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Business
{
    public interface IRecordsReader
    {
        List<MovieMetaData> GetMetaDataRecords();
        
        List<Stat> GetStatsRecords();
    }
}
