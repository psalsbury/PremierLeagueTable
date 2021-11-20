using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using CsvHelper;
using CsvHelper.Configuration;
using TechnicalTest.Models;

namespace TechnicalTest.Helpers
{
    public class CsvHelper
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public List<Result> UploadCsvFile(HttpPostedFileBase postedFileBase)
        {

            Logger.Info($"CsvHelper.UploadCsvFile method called");

            using (var reader = new StreamReader(postedFileBase.InputStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ResultsMap>();
                var results =  csv.GetRecords<Models.Result>();
                return results.ToList();
            }
        }
    }
    public sealed class ResultsMap : ClassMap<Models.Result>
    {
        public  ResultsMap()
        {
            Map(m => m.FixtureDate).Name("Date");
            Map(m => m.FixtureTime).Name("Time");
            Map(m => m.HomeTeam).Name("HomeTeam");
            Map(m => m.AwayTeam).Name("AwayTeam");
            Map(m => m.FullTimeHomeGoals).Name("FTHG");
            Map(m => m.FullTimeAwayGoals).Name("FTAG");

        }
    }
}