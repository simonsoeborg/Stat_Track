using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatTrack.Models;
using Microsoft.AspNetCore.Identity;
using static DataLibrary.Logic.TeamProcessor;
using System.Security.Claims;

public class TeamController : Controller
    {

    public IActionResult Index()
    {
        ClaimsPrincipal currentUser = this.User;
        var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        var data = LoadTeams(currentUserID);

        var TeamViewModel = new TeamViewModel();

        List<TeamModel> teams = new List<TeamModel>();
        
        foreach (var item in data)
        {
            teams.Add(new TeamModel
            {
                Name = item.Name,
                ClubId = item.ClubId,
                CreatorId = item.CreatorId,
                Division = item.Division,
                TeamUYear = item.TeamUYear,
                Id = item.Id
            }); ; 
        }

        TeamViewModel.TModels = teams;

        TeamViewModel.TModel = new TeamModel();

        return View(TeamViewModel);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TeamModel model)
        {
       
        Console.WriteLine("test 2");
            if (ModelState.IsValid)
            {
            Console.WriteLine(model.Name + "  " + model.ClubId + "  " + model.CreatorId + "   " + model.TeamUYear + "    " + model.Division); 

                CreateTeam(model.Name, model.ClubId, model.CreatorId, model.TeamUYear, model.Division);

                return RedirectToAction("Index");
            }
            return Index();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int Id)
    {
        Console.WriteLine(Id);
        if (ModelState.IsValid)
        {
            DeleteTeam(Id);
            return RedirectToAction("Index");

        }
        return View();
    }

}

