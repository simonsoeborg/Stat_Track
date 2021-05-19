using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using StatTrack.Models;
using static DataLibrary.Logic.TeamProcessor;

public class TeamController : Controller
{
    public static string GetCurrentUser = "";

    public IActionResult Index()
    {
        var currentUser = User;
        var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        var data = LoadTeams(currentUserID);
        GetCurrentUser = currentUserID;

        var TeamViewModel = new TeamViewModel();

        var teams = new List<TeamModel>();

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
            });
            ;
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
        if (ModelState.IsValid)
        {
            CreateTeam(model.Name, model.ClubId, model.CreatorId, model.TeamUYear, model.Division);

            return RedirectToAction("Index");
        }

        return Index();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        DeleteTeams(id);

        return RedirectToAction("Index");
    }


    public void DeleteTeams(int Id)
    {
        if (ModelState.IsValid) DeleteTeam(Id);
    }
}