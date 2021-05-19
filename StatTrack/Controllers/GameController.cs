using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StatTrack.Logic;
using StatTrack.Models;
using static DataLibrary.Logic.PlayerProcessor;
using static DataLibrary.Logic.GameProcessor;
using static DataLibrary.Logic.PlayerStatsProcessor;

namespace StatTrack.Controllers
{
    public class GameController : Controller
    {
        public static int x;

        public IActionResult Index(int Id)
        {
            var data = LoadTeamPlayers(Id);
            var masterModel = new MasterModel();

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

            masterModel.TeamPlayerModels = players;

            return View(masterModel);

            // Id will be teamId, load team, and team players
        }

        public JsonResult RePostGameToDb([FromBody] GameDataModel d)
        {
            var currentUser = TeamController.GetCurrentUser;
            var date = DateTime.Now;
            var formatDate = date.Year + "/" + date.Month + "/" + date.Day;
            if (d.CreatorTeamGoals == 0 && d.ModstanderGoals == 0 && x == 0)
            {
                d.CreatorTeamGoals = 0;
                d.ModstanderGoals = 0;

                var gmd = new GameDataModel
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

                DataHandler.GameId = GetKampId(currentUser, d.CreatorTeamId, d.Modstander, formatDate);
                ;

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
            insertDataToPlayerStats(d.Tidspunkt, d.Attempts, d.Goals, d.KeeperSaves, d.Assists, d.PlayerId,
                DataHandler.GameId);

            return Json(d);
        }

        public JsonResult EventToDb([FromBody] EventModel d)
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