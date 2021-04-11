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

namespace StatTrack.Controllers
{
    public class PlayerController : Controller
    {
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

                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }

        // Skal få oplysninger om brugeren (Get userInfo()) 
        public IActionResult Delete(int playerId, string playerName, string playerPosition, int YOB)
        {

            Console.WriteLine(playerId);
            if (playerId == null)
            {
                Console.WriteLine("pis off");
            }
            var model = new PlayerModel { Id = playerId, PlayerName = playerName, PlayerPosition = playerPosition, YOB = YOB };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(Id);
                DeletePlayer(Id);

                return RedirectToAction("Index");
            }
            return View();


        }
             

        // Skal slette personen fra ovenstående page, hvis der trykkes på knappen. 

      

        public IActionResult Details()
        {
            return View();
        }
    }
}