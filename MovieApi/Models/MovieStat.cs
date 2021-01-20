using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class MovieStat
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public long AverageWatchDurationS { get; set; }

        public int Watches { get; set; }

        public string ReleaseYear { get; set; }
    }
}
