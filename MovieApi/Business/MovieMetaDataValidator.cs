using MovieApi.Models;

namespace MovieApi.Business
{
    public class MovieMetaDataValidator : IMovieMetaDataValidator
    {
        public bool IsRecordValid(MovieMetaData movieMetaData)
        {
            return
                movieMetaData.MovieId > 0 && 
                movieMetaData.Id > 0 &&
                movieMetaData.ReleaseYear > 0 &&
                !string.IsNullOrEmpty(movieMetaData.Language) &&                
                !string.IsNullOrEmpty(movieMetaData.Title) &&
                !string.IsNullOrEmpty(movieMetaData.Duration);
        }
    }
}
