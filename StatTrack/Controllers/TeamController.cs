using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatTrack.Models;
using static DataLibrary.Logic.TeamProcessor;

public class TeamController : Controller
    {
        public IActionResult Index()
        {
        return View();
    }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                CreateTeam(model.Name, model.Club, model.CreatorId, model.TeamUYear, model.Division);

                return RedirectToAction("Index");
            }
            return Index();
        }
    }
}
