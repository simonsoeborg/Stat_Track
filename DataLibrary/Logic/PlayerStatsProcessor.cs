using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class PlayerStatsProcessor
    {
        public static List<DLPlayerStatsModel> GetOverallPlayerStats(int playerId)
        {
            string query = @"SELECT * FROM SpillerStats WHERE SpillerId = '" + playerId + "';";

            return SqlDataAccess.GetData<DLPlayerStatsModel>(query);
        }
        public static List<DLPlayerStatsModel> GetCurrentSeasonPlayerStats(int playerId)
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            string seasonStart = "01/09/" + (year - 1);
            string seasonEnd = "01/06/" + year;
            /*
            SELECT * 
            FROM sales 
            WHERE salesDate BETWEEN '2020-05-18T00:00:00.00' AND '2020-05-18T23:59:59.999'
             */
            string query = @"SELECT * FROM SpillerStats WHERE SpillerId = '" + playerId + "';";

            return SqlDataAccess.GetData<DLPlayerStatsModel>(query);
        }
    }
}
