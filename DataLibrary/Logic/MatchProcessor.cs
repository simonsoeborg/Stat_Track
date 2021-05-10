using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;


namespace DataLibrary.Logic
{
    public class MatchProcessor
    {
        public static List<DLGameDataModel> LoadMatches(string userID)
        {
            // Indputtet userId her sørger for at kun dine egne oprettede hold bliver vist.
            string query = @"SELECT * FROM KampData WHERE CreatorID = '" + userID + "';";

            return SqlDataAccess.GetData<DLGameDataModel>(query);
        }



        public static List<DLPlayerStatsModel> loadSpecifiMatch (int MatchId)
        {
        string query = @"SELECT * FROM Team WHERE CreatorId = '" + MatchId + "';";

        return SqlDataAccess.GetData<DLPlayerStatsModel>(query);
        }
    }
}
