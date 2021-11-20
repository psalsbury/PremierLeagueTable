using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTest.Models
{
    public class LeagueTableTeam
    {

        public LeagueTableTeam(string teamName)
        {
            TeamName = teamName;
        }

        public int LeaguePosition { get; set; }
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Points { get; set; }
    }
}