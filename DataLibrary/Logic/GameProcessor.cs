using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class GameProcessor
    {
        public static int CreateGame(string creatorId, int teamId, string modstander, string kampdato, int teamGoals, int modstanderGoals)
        {
            DLGameDataModel data = new DLGameDataModel()
            {
                CreatorID = creatorId,
                CreatorTeamId = teamId,
                Modstander = modstander,
                KampDato = kampdato,
                CreatorTeamGoals = teamGoals,
                ModstanderGoals = modstanderGoals
            };
            string query = @"INSERT INTO KampData (CreatorID, CreatorTeamId, Modstander, KampDato, CreatorTeamGoals, ModstanderGoals) VALUES (@CreatorID, @CreatorTeamId, @Modstander, @KampDato, @CreatorTeamGoals, @ModstanderGoals);";

            return SqlDataAccess.SaveData(query, data);
        }

        public static int UpdateGameResults(int kampId, int teamGoals, int modstanderGoals)
        {

            DLGameDataModel data = new DLGameDataModel()
            {
                KampId = kampId,
                CreatorTeamGoals = teamGoals,
                ModstanderGoals = modstanderGoals
            };
            string query = @"UPDATE KampData SET CreatorTeamGoals = " + teamGoals + ", ModstanderGoals = " + modstanderGoals + " WHERE KampId = " + kampId + ";";

            return SqlDataAccess.SaveData(query, data);
        }

        public static int GetKampId(string creatorId, int teamId, string modstander, string kampDato)
        {
            string query = @"SELECT KampId FROM KampData WHERE CreatorID = N'" + creatorId + "' AND CreatorTeamId = " + teamId + " AND Modstander = '" + modstander +"' AND KampDato = '" + kampDato + "';";

            List<DLGameDataModel> dataList = SqlDataAccess.GetData<DLGameDataModel>(query);
            
            return dataList.FirstOrDefault().KampId;
        }
    }
}
