using CsvHelper;
using MovieApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieApi.Business
{
    public class RecordsReader : IRecordsReader
    {
        public List<MovieMetaData> GetMetaDataRecords()
        {
            using TextReader reader = new StreamReader(@".\CSV\metadata.csv");
            using CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture);
                        
            var records = new List<MovieMetaData>();
            
            csvReader.Read();
            
            csvReader.ReadHeader();
            
            while (csvReader.Read())
            {
                var record = new MovieMetaData
                {
                    Id = csvReader.GetField<int>("Id"),
                    MovieId = csvReader.GetField<int>("MovieId"),
                    Duration = csvReader.GetField<string>("Duration"),
                    Language = csvReader.GetField<string>("Language"),
                    ReleaseYear = csvReader.GetField<int>("ReleaseYear"),
                    Title = csvReader.GetField<string>("Title"),

                };
                records.Add(record);
            }

            return records;
        }

        public List<Stat> GetStatsRecords()
        {
            using TextReader reader = new StreamReader(@".\CSV\stats.csv");
            using CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture);

            var records = new List<Stat>();

            csvReader.Read();

            csvReader.ReadHeader();

            while (csvReader.Read())
            {
                var record = new Stat
                {                    
                    MovieId = csvReader.GetField<int>("MovieId"),
                    WatchDurationMs = csvReader.GetField<long>("WatchDurationMs"),

                };
                records.Add(record);
            }

            return records;
        }
    }
}
