using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Logic;
using static DataLibrary.Logic.PlayerProcessor;
using Microsoft.Extensions.Configuration;
using StatTrack.Data;
using StatTrack.Models;
using System.Security.Claims;

namespace StatTrack.Controllers
{
    public class PlayerController : Controller
    {
        public static int currentTeamId { get; set; }
        public IActionResult Index()
        {
           
            var data = LoadPlayers();
            List<PlayerModel> players = new List<PlayerModel>();


            foreach (var item in data)
            {
                players.Add(new PlayerModel()
                {
                    PlayerName = item.Name,
                    PlayerPosition = item.Position,
                    YOB = item.YOB,
                    Id = item.Id 
                });;
            }
            return View(players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlayerModel model)
        {
            if (ModelState.IsValid)
            {
                CreatePlayer(model.PlayerName, model.PlayerPosition, model.YOB);

                Console.WriteLine("i was here");
            }
            return View();
        }


        public IActionResult Edit(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel {Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB };
            Console.WriteLine(playerId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlayerModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.Id);
                UpdatePlayer(model.Id, model.PlayerName, model.PlayerPosition, model.YOB);
                return RedirectToAction("PlayerLineUp", new { id = currentTeamId});
            }
            return View();
        }



        public IActionResult Delete(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel { Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                DeletePlayer(Id);
                return RedirectToAction("PlayerLineUp", new { id = currentTeamId });

            }
            return View();
        }

        public IActionResult Details(int playerId, string playerName, string playerPosition, int YOB)
        {
            var model = new PlayerModel { Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB };

            return View(model);       
        }

        public IActionResult PlayerLineUp(int Id)
        {
            currentTeamId = Id;
            var data = LoadTeamPlayers(Id);
            List<TeamPlayerModel> players = new List<TeamPlayerModel>();

            foreach (var item in data)
            {
                players.Add(new TeamPlayerModel()
                {
                    Name = item.Name,
                    Position = item.Position,
                    YOB = item.YOB,
                    PlayerID = item.PlayerID,
                    TeamID = item.TeamID
                }); ;
            }
            return View(players);
        }

    }
}