using System.Collections.Generic;
using System.Web.Mvc;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Table()
        {
            ViewBag.Title = "Premier League Table";

            var results = (List<Result>)Session["Results"];
            var leagueTableTeams = Helpers.LeagueTableHelper.ReturnLeagueTable(results);

            return View(leagueTableTeams);
        }
    }
}