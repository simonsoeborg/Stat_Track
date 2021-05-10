using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatTrack.Models;
using static DataLibrary.Logic.MatchProcessor;
using System.Security.Claims;


namespace StatTrack.Controllers
{
    public class MatchController : Controller
    {
        public static string GetCurrentUser = "";

        public IActionResult MatchesList()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = LoadMatches(currentUserID);


            List<GameDataModel> MatchModel = new List<GameDataModel>();

            foreach (var item in data)
            {
                MatchModel.Add(new GameDataModel
                {
                    CreatorID = item.CreatorID,
                    CreatorTeamGoals = item.CreatorTeamGoals,
                    CreatorTeamId = item.CreatorTeamId,
                    KampDato = item.KampDato,
                    KampId = item.KampId,
                    Modstander = item.Modstander,
                    ModstanderGoals =item.ModstanderGoals 
                });;
            }

            return View(MatchModel);
        }


        public IActionResult MatchInfo(int matchId)
        {


            return View();

        }



    }
}
