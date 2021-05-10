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
            var data1 = LoadMatches(currentUserID);

            CombinedMatchViewModel matchViewModel = new CombinedMatchViewModel();

            List<GameDataModel> MatchModel = new List<GameDataModel>();

            foreach (var item in data1)
            {
                MatchModel.Add(new GameDataModel
                {
                    CreatorID = item.CreatorID,
                    CreatorTeamGoals = item.CreatorTeamGoals,
                    CreatorTeamId = item.CreatorTeamId,
                    KampDato = item.KampDato,
                    KampId = item.KampId,
                    Modstander = item.Modstander,
                    ModstanderGoals = item.ModstanderGoals
                }); ;

                matchViewModel.GameModel = MatchModel;
            }
            return View(matchViewModel);

        }


        public List<MatchViewModel> SpecificData(int matchId)
        {
            CombinedMatchViewModel matchViewModel = new CombinedMatchViewModel();

            List<MatchViewModel> StatModel = new List<MatchViewModel>();

           var data2 = LoadSpecifiMatchView(matchId);
               
            foreach (var obj in data2)
                {
                Console.WriteLine("Test_times");
                    StatModel.Add(new MatchViewModel
                    {
                        EventType = obj.EventType,
                        id = obj.id,
                        Navn = obj.Navn,
                        Time = obj.Time,
                    });
                }

            return StatModel;
        }
    }
}
