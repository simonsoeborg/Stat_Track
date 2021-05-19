using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StatTrack.Models;
using static DataLibrary.Logic.PlayerProcessor;

namespace StatTrack.Controllers
{
    public class PlayerController : Controller
    {
        public static int currentTeamId { get; set; }

        /*      public IActionResult Index()
              {
                 
                  var data = LoadPlayers();
                  List<TeamPlayerModel> players = new List<TeamPlayerModel>();
      
      
                  foreach (var item in data)
                  {
                      players.Add(new TeamPlayerModel()
                      {
                          Name = item.Name,
                          Position = item.Position,
                          YOB = item.YOB,
                          TeamID = item.TeamID,
                          Id = item.Id
                      });;
                  }
                  return View(players);
              }*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamPlayerModel model)
        {
            if (ModelState.IsValid) CreatePlayer(model.Name, model.Position, model.YOB, currentTeamId);
            return RedirectToAction("PlayerLineUp", new {id = currentTeamId});
        }


        public IActionResult Edit(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel
                {Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlayerModel model)
        {
            if (ModelState.IsValid)
            {
                UpdatePlayer(model.Id, model.PlayerName, model.PlayerPosition, model.YOB);
                return RedirectToAction("PlayerLineUp", new {id = currentTeamId});
            }

            return View();
        }


        public IActionResult Delete(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel
                {Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                DeletePlayer(Id);
                return RedirectToAction("PlayerLineUp", new {id = currentTeamId});
            }

            return View();
        }

        public IActionResult Details(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel
                {Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB};

            return View(model);
        }

        public IActionResult DetailsList(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel
                {Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB};

            return View(model);
        }


        public IActionResult PlayerLineUp(int Id)
        {
            currentTeamId = Id;
            var data = LoadTeamPlayers(Id);

            var TeamPlayersViewModel = new TeamPlayersViewModel();

            var players = new List<TeamPlayerModel>();
            foreach (var item in data)
                players.Add(new TeamPlayerModel
                {
                    Name = item.Name,
                    Position = item.Position,
                    YOB = item.YOB,
                    Id = item.Id,
                    TeamID = item.TeamID
                });

            TeamPlayersViewModel.TModels = players;
            TeamPlayersViewModel.TModel = new TeamPlayerModel();
            return View(TeamPlayersViewModel);
        }
    }
}