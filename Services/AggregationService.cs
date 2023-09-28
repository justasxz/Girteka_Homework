using CsvHelper;
using Girteka_Homework.Data;
using Girteka_Homework.Data.Models;
using Girteka_Homework.Maps;
using Girteka_Homework.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Girteka_Homework.Services
{
    public class AggregationService : IAggregationService
    {
        private readonly MySqlDBContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AggregationService> _logger;
        public AggregationService(MySqlDBContext dbContext, IConfiguration configuration, ILogger<AggregationService> logger)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _logger = logger;
        }

        public List<Electronic_Data> GetAggregatedData()
        {
            var records = new List<Electronic_Data>();
            try
            {
                if (Aggregate())
                    records = _dbContext.Electronic_Data.ToList();
                else
                    _logger.LogWarning("There was error agreggating");

                return records;


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return records;
            }
        }

        //
        public bool Aggregate()
        {
            try
            {
                //Since no information was provided when to insert data into database I clean it and insert it every time the request is made.


                _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE electronic_data");

                var records = ReadCsvs().Where(x => x.ObjectName.ToUpper() == "BUTAS").GroupBy(x => x.Network).Select(x => new Electronic_Data
                {
                    HourlyProduction = x.Sum(y => y.HourlyProduction),
                    HourlyConsumption = x.Sum(y => y.HourlyConsumption),
                    Date = DateTime.Now,
                    Network = x.Key,
                    ObjectName = x.FirstOrDefault().ObjectName,
                });

                if (InsertIntoDatabase(records.ToList()))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }
        public bool InsertIntoDatabase(List<Electronic_Data> records)
        {
            try
            {
                _dbContext.Electronic_Data.AddRange(records);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public List<Electronic_Data> ReadCsvs()
        {
            var records = new List<Electronic_Data>();
            try
            {

                foreach (var csvFile in Directory.GetFiles(_configuration.GetValue<string>("PathToCSVDirectory")))
                {
                    using (var reader = new StreamReader(csvFile))

                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<ElectricDataMap>();
                        records.AddRange(csv.GetRecords<Electronic_Data>());

                    }
                }
                return records;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return records;
            }
        }
    }
}
