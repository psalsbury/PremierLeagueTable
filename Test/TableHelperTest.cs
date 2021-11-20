using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalTest.Helpers;
using TechnicalTest.Models;

namespace Test
{
    [TestClass]
    public class TableHelperTest
    {

        [TestMethod]
        public void CheckTableOrderAndPositionsAreCorrect()
        {
            // Verify that Forest are top, and that ManUtd and Derby are joint second

            var results = new List<Result>
            {
                new Result() { HomeTeam = "Forest", AwayTeam = "ManUtd", FullTimeHomeGoals = 1, FullTimeAwayGoals = 0 },
                new Result() { HomeTeam = "Derby", AwayTeam = "ManUtd", FullTimeHomeGoals = 1, FullTimeAwayGoals = 1 },
                new Result() { HomeTeam = "Derby", AwayTeam = "Forest", FullTimeHomeGoals = 0, FullTimeAwayGoals = 1 }
            };

            var leagueTableTeams = LeagueTableHelper.ReturnLeagueTable(results);

            Assert.AreEqual(3, leagueTableTeams.Count);

            var leagueTableTeamForest = leagueTableTeams.FirstOrDefault(t => t.TeamName == "Forest");
            var leagueTableTeamDerby = leagueTableTeams.FirstOrDefault(t => t.TeamName == "Derby");
            var leagueTableTeamManUtd = leagueTableTeams.FirstOrDefault(t => t.TeamName == "ManUtd");

            Assert.IsNotNull(leagueTableTeamForest,"Table does not contain Forest");
            Assert.IsNotNull(leagueTableTeamDerby, "Table does not contain Derby");
            Assert.IsNotNull(leagueTableTeamManUtd,"Table does not contain Man Utd");

            Assert.AreEqual(leagueTableTeamForest.LeaguePosition,1, "Forest League Position is not 1");
            Assert.AreEqual(leagueTableTeamDerby.LeaguePosition, 2, "Derby League Position is not 2");
            Assert.AreEqual(leagueTableTeamManUtd.LeaguePosition, 2, "Man Utd League Position is not 2");
        }

        [TestMethod]
        public void CheckResultsAreCorrect()
        {
            // Verify that Forest are top, and that ManUtd and Derby are joint second

            var results = new List<Result>
            {
                new Result() { HomeTeam = "Forest", AwayTeam = "ManUtd", FullTimeHomeGoals = 1, FullTimeAwayGoals = 0 },
                new Result() { HomeTeam = "Derby", AwayTeam = "ManUtd", FullTimeHomeGoals = 1, FullTimeAwayGoals = 1 },
                new Result() { HomeTeam = "Derby", AwayTeam = "Forest", FullTimeHomeGoals = 0, FullTimeAwayGoals = 1 }
            };

        }

    }

}
