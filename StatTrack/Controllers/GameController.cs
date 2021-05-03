using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatTrack.Models;
using static DataLibrary.Logic.PlayerProcessor;

namespace StatTrack.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index(int id)
        {
            // Id will be TeamId, load team, and team players

            // 

            if (id == 0)
            {
                return View();
            } else { 
                return View();
            }
        }

        public List<TeamPlayerModel> GetPlayerList(int TeamId)
        {
            var data = LoadTeamPlayers(TeamId);
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
                });
            }

            return players;
        }
    }
}
