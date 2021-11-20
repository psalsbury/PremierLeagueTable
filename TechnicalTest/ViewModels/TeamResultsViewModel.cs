using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnicalTest.Models;

namespace TechnicalTest.ViewModels
{
    public class TeamResultsViewModel
    {
        public string TeamName { get; set; }

        public List<Result> TeamResults { get; set; }
    }
}