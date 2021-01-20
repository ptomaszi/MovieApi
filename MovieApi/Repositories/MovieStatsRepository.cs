using MovieApi.Db;
using MovieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApi.Repositories
{
    public class MovieStatsRepository : IMovieStatsRepository
    {
        private readonly IMovieDbContext _movieDbContext;

        public MovieStatsRepository(IMovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        
        public IEnumerable<MovieStat> Get()
        {
            List<MovieMetaData> metadata = _movieDbContext.GetMovieMetaData().ToList();
            List<Stat> stat = _movieDbContext.GetMovieStat().ToList();

            var statsByMovieId = stat.GroupBy(x => x.MovieId);

            List<MovieStat> movieStats = new List<MovieStat>();

            foreach (var group in statsByMovieId)
            {
                MovieMetaData movieMetaData = metadata.FirstOrDefault(x => x.MovieId == group.Key);

                if (movieMetaData == null)
                {
                    continue;
                }

                MovieStat movieStat = new MovieStat
                {
                    MovieId = group.Key,
                    Watches = group.Count(),
                    Title = movieMetaData.Title,
                    ReleaseYear = movieMetaData.ReleaseYear.ToString(),
                    AverageWatchDurationS = (group.Sum(x => x.WatchDurationMs) / group.Count()) / 1000
                };

                movieStats.Add(movieStat);
            }

            return movieStats
                .OrderByDescending(x => x.ReleaseYear)
                .OrderByDescending(x => x.Watches);
        }
    }
}
