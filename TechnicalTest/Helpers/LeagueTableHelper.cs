using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnicalTest.Models;

namespace TechnicalTest.Helpers
{
    public static class LeagueTableHelper
    {

        public static List<LeagueTableTeam> ReturnLeagueTable(List<Result> results)
        {

            if (results == null)
                return null;

            var leagueTableTeams = GetStartingLeagueTable(results);

            foreach (var result in results)
            {
                var homeLeagueTableTeam = leagueTableTeams.FirstOrDefault(t => t.TeamName == result.HomeTeam);
                var awayLeagueTableTeam = leagueTableTeams.FirstOrDefault(t => t.TeamName == result.AwayTeam);

                UpdateLeagueTableTeam(homeLeagueTableTeam, awayLeagueTableTeam, result);

            }

            leagueTableTeams = leagueTableTeams.OrderByDescending(c => c.Points)
                .ThenByDescending(e => e.GoalDifference)
                .ThenByDescending(e => e.GoalsFor).ToList();

            var firstTeam = leagueTableTeams.First();
            firstTeam.LeaguePosition = 1;

            // Calculate the position
            var firstPass = true;
            var previousLeagueTableTeam = firstTeam;
            var counter = 1;
            foreach (var leagueTableTeam in leagueTableTeams.OrderByDescending(c => c.Points)
                .ThenByDescending(e => e.GoalDifference)
                .ThenByDescending(e => e.GoalsFor).ToList())
            {
                if(firstPass)
                {
                    firstPass = false;
                }
                else if(leagueTableTeam.Points == previousLeagueTableTeam.Points &&
                        leagueTableTeam.GoalDifference == previousLeagueTableTeam.GoalDifference &&
                        leagueTableTeam.GoalsFor == previousLeagueTableTeam.GoalsFor)
                {
                    leagueTableTeam.LeaguePosition = previousLeagueTableTeam.LeaguePosition;
                }
                else
                {
                    leagueTableTeam.LeaguePosition = counter;
                }

                counter += 1;
                previousLeagueTableTeam = leagueTableTeam;
            }

            return leagueTableTeams.OrderBy(p => p.LeaguePosition).ToList();
        }

        private static List<LeagueTableTeam> GetStartingLeagueTable(List<Result> results)
        {
            var leagueTableTeams = new List<LeagueTableTeam>();

            // Get a distinct list of all the teams, combining home and away teams
            var teamNames = results.Select(t => t.HomeTeam).Distinct().Union(results.Select(t => t.AwayTeam).Distinct());

            foreach (var teamName in teamNames)
            {
                leagueTableTeams.Add(new LeagueTableTeam(teamName));
            }

            return leagueTableTeams;
        }

        private static void UpdateLeagueTableTeam(LeagueTableTeam leagueTableTeamHome, LeagueTableTeam leagueTableTeamAway, Result result)
        {

            leagueTableTeamHome.Points += result.HomePoints;
            leagueTableTeamAway.Points += result.AwayPoints;

            leagueTableTeamHome.GamesPlayed += 1;
            leagueTableTeamAway.GamesPlayed += 1;

            leagueTableTeamHome.Won += result.HomePoints == 3 ? 1 : 0;
            leagueTableTeamHome.Drawn += result.HomePoints == 1 ? 1 : 0;
            leagueTableTeamHome.Lost += result.HomePoints == 0 ? 1 : 0;

            leagueTableTeamAway.Won += result.AwayPoints == 3 ? 1 : 0;
            leagueTableTeamAway.Drawn += result.AwayPoints == 1 ? 1 : 0;
            leagueTableTeamAway.Lost += result.AwayPoints == 0 ? 1 : 0;

            leagueTableTeamHome.GoalsFor += result.FullTimeHomeGoals;
            leagueTableTeamHome.GoalsAgainst += result.FullTimeAwayGoals;

            leagueTableTeamAway.GoalsFor += result.FullTimeAwayGoals;
            leagueTableTeamAway.GoalsAgainst += result.FullTimeHomeGoals;

        }

    }
}