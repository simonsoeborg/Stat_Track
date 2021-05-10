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


        public static List<DLPlayerStatsModel> GetOccurences(int kampId)
        {
            string query = @"SELECT * FROM SpillerStats WHERE KampId = @kampId;";

            return SqlDataAccess.GetData<DLPlayerStatsModel>(query);

        }

        public static int UpdateOccurences(int gulekort, int roedekort, int Mins2, int PlayerId, int KampId)
        {
            //   for (int i = 0; i < list.Count; i++)
            // {

            DLPlayerStatsModel data = new DLPlayerStatsModel() {
                PlayerId = PlayerId,
                Mins2 = Mins2,
                Gulekort = gulekort,
                Roedekort = roedekort,
                KampId = KampId
            };
             
            string query = @"UPDATE SpillerStats SET Mins2 = @Mins2, gulekort = @gulekort, roedekort = @roedekort WHERE SpillerId = @PlayerId AND KampId = KampId 
            ELSE INSERT INTO SpillerStats (SpillerId, Mins2, gulekort, roedekort, KampId) VALUES (@PlayerId, @Mins2, @gulekort, @roedekort, @KampId);";

            SqlDataAccess.SaveData(query, data);
            return 0;

        }
    }
}
