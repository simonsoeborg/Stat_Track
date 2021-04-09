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

            var data = LoadPlayers(DatabaseHandler.GetConnectionString());
            List<PlayerModel> players = new List<PlayerModel>();

            foreach (var item in data)
            {
                players.Add(new PlayerModel()
                {
                    // Id = item.Id,
                    PlayerName = item.Name,
                    PlayerPosition = item.Position,
                    YOB = item.YOB
                });
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
                CreatePlayer(model.PlayerName, model.PlayerPosition, model.YOB, DatabaseHandler.GetConnectionString());
     
                    return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
