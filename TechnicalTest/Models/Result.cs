using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTest.Models
{
    public class Result
    {
        public string FixtureDate { get; set; }
        public string FixtureTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public Int16 FullTimeHomeGoals { get; set; }
        public Int16 FullTimeAwayGoals { get; set; }
        public Int32 HomePoints => FullTimeHomeGoals > FullTimeAwayGoals ? 3 : FullTimeHomeGoals == FullTimeAwayGoals ?1 : 0;
        public Int32 AwayPoints => FullTimeAwayGoals > FullTimeHomeGoals ? 3 : FullTimeAwayGoals == FullTimeHomeGoals ? 1 : 0;

    }
}