using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TechnicalTest.Models;
using TechnicalTest.ViewModels;

namespace TechnicalTest.Controllers
{
    public class TeamResultsController : Controller
    {
        // GET: TeamResults
        public ActionResult DisplayTeamResults(string teamName)
        {
            var teamResultsViewModel = new TeamResultsViewModel();

            if(teamName=="")
                return View(teamResultsViewModel);

            teamResultsViewModel.TeamName = teamName;

            var results = (List<Result>)Session["Results"];
            if (results != null)
            {
                teamResultsViewModel.TeamResults = results.Where(r => r.HomeTeam == teamName | r.AwayTeam == teamName).ToList();
            }
 
            return View(teamResultsViewModel);
        }
    }
}