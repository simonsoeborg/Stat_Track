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
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data1 = LoadMatches(currentUserId);

            MatchViewModel mvm = new MatchViewModel();


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

            List<MatchViewModel> mvm = new List<MatchViewModel>();

            var data2 = LoadSpecifiMatchView(matchId);

            foreach (var obj in data2)
            {
                mvm.Add(new MatchViewModel
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Time = obj.Time,
                    EventType = obj.EventType,
                    KampDato = obj.KampDato,
                    Modstander = obj.Modstander
                });
            }

            return mvm;
        }
    }
}
