using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Business
{
    public interface IMovieMetaDataValidator
    {
        bool IsRecordValid(MovieMetaData movieMetaData);
    }
}
