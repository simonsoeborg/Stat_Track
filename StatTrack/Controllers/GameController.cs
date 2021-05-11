using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatTrack.Logic;
using StatTrack.Models;
using static DataLibrary.Logic.PlayerProcessor;
using static DataLibrary.Logic.GameProcessor;
using static DataLibrary.Logic.PlayerStatsProcessor;

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

        public static int x = 0;
        public JsonResult RePostGameToDb([FromBody] GameDataModel d)
        {
            string currentUser = TeamController.GetCurrentUser;
            DateTime date = DateTime.Now;
            string formatDate = date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
            if (d.CreatorTeamGoals == 0 && d.ModstanderGoals == 0 && x == 0)
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

                DataHandler.GameId = GetKampId(currentUser, d.CreatorTeamId, d.Modstander, formatDate); ;

                x++;
            }
            else
            {
                UpdateGameResults(DataHandler.GameId, d.CreatorTeamGoals, d.ModstanderGoals);
            }


            return Json(d);
        }

        public JsonResult PlayerStatToDb([FromBody] PlayerStatsModel d)
        {
            insertDataToPlayerStats(d.Tidspunkt, d.Attempts, d.Goals, d.KeeperSaves, d.Assists, d.PlayerId, DataHandler.GameId);

            return Json(d);
        }

        public JsonResult EventToDB([FromBody] EventModel d)
        {
            AddNewEvent(d.EventType, d.PlayerId, d.Time, DataHandler.GameId);

            return Json(d);
        }

        public JsonResult EmptyGameId([FromBody] EventModel d)
        {
            DataHandler.GameId = 0;
            x = 0;
            return Json(d);
        }
    }

}
