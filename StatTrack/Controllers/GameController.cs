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
        public IActionResult Index(int Id)
        {
            Console.WriteLine(Id);
            var data = LoadTeamPlayers(Id);
            var MasterModel = new MasterModel();

            List<TeamPlayerModel> players = new List<TeamPlayerModel>();
            foreach (var item in data)
            {
                players.Add(new TeamPlayerModel()
                {
                    Name = item.Name,
                    Position = item.Position,
                    YOB = item.YOB,
                    Id = item.Id,
                    TeamID = item.TeamID
                });
            }

            MasterModel.TeamPlayerModels = players;

            return View(MasterModel);

            // Id will be TeamId, load team, and team players
        }
    }
}
   



       /* public IActionResult GetPlayerList(int TeamId)
        {
            var data = LoadTeamPlayers(TeamId);


            var MasterModel = new MasterModel();


            List<TeamPlayerModel> players = new List<TeamPlayerModel>();
            foreach (var item in data)
            {
                players.Add(new TeamPlayerModel()
                {
                    Name = item.Name,
                    Position = item.Position,
                    YOB = item.YOB,
                    Id = item.Id,
                    TeamID = item.TeamID
                });
            }

            MasterModel.TeamPlayerModels = players;
            MasterModel.TeamPlayerModel = new TeamPlayerModel(); 
           
            return View(MasterModel);
        }*/