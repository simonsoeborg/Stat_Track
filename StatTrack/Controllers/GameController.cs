using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatTrack.Models;
using static DataLibrary.Logic.PlayerProcessor;
using static DataLibrary.Logic.GameProcessor;

namespace StatTrack.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index(int Id)
        {
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

            // Id will be teamId, load team, and team players
        }

        public IActionResult PostGameToDb(int teamId, string modstander, int teamGoals, int awayTeamGoals)
        {
            string currentUser = TeamController.GetCurrentUser;
            DateTime date = DateTime.Now;
            string formatDate = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (teamGoals == 0 && awayTeamGoals == 0)
            {
                teamGoals = 0;
                awayTeamGoals = 0;

                GameDataModel gmd = new GameDataModel
                {
                    CreatorID = currentUser,
                    CreatorTeamId = teamId,
                    Modstander = modstander,
                    KampDato = formatDate,
                    CreatorTeamGoals = teamGoals,
                    ModstanderGoals = awayTeamGoals
                };

                CreateGame(gmd.CreatorID, gmd.CreatorTeamId, gmd.Modstander, gmd.KampDato, gmd.CreatorTeamGoals,
                    gmd.ModstanderGoals);
            }
            else
            {
                int kampId = GetKampId(currentUser, teamId, modstander, formatDate);
                UpdateGameResults(kampId, teamGoals, awayTeamGoals);
            }


            return Index(teamId);
        }

        public JsonResult RePostGameToDb([FromBody] GameDataModel d)
        {
            string currentUser = TeamController.GetCurrentUser;
            DateTime date = DateTime.Now;
            string formatDate = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (d.CreatorTeamGoals == 0 && d.ModstanderGoals == 0)
            {
                d.CreatorTeamGoals = 0;
                d.ModstanderGoals = 0;

                GameDataModel gmd = new GameDataModel
                {
                    CreatorID = currentUser,
                    CreatorTeamId = d.CreatorTeamId,
                    Modstander = d.Modstander,
                    KampDato = formatDate,
                    CreatorTeamGoals = d.CreatorTeamGoals,
                    ModstanderGoals = d.ModstanderGoals
                };

                CreateGame(gmd.CreatorID, gmd.CreatorTeamId, gmd.Modstander, gmd.KampDato, gmd.CreatorTeamGoals,
                    gmd.ModstanderGoals);
            }
            else
            {
                int kampId = GetKampId(currentUser, d.CreatorTeamId, d.Modstander, formatDate);
                UpdateGameResults(kampId, d.CreatorTeamGoals, d.ModstanderGoals);
            }


            return Json(d);
        }
    }
}
   



       /* public IActionResult GetPlayerList(int teamId)
        {
            var data = LoadTeamPlayers(teamId);


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