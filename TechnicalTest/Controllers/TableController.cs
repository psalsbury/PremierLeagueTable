using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NLog;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{

    public class TableController : Controller
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: Table
        public ActionResult Table()
        {
            try
            {
                Logger.Info($"TableController.Table method called");

                ViewBag.Title = "Premier League Table";

                var results = (List<Result>)Session["Results"];
                var leagueTableTeams = Helpers.LeagueTableHelper.ReturnLeagueTable(results);

                return View(leagueTableTeams);
            }
            catch (Exception e)
            {
                Logger.Error($"Error Raised in TableController.Table --> {e.Message}");
                throw;
            }
        }
    }
}