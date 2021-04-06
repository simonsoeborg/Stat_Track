using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Logic;
using static DataLibrary.Logic.PlayerProcessor;
using Microsoft.Extensions.Configuration;
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
                    Id = item.Id,
                    PlayerName = item.PlayerName,
                    PlayerPosition = item.PlayerPosition,
                    YOB = item.PlayerYOB
                });
            }

            return View(players);
        }

        public IActionResult Create()
        {
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
