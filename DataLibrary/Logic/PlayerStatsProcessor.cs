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
            // "SELECT s.*, k.KampDato FROM SpillerStats s INNER JOIN KampData k ON s.KampId = k.KampId WHERE s.SpillerId = 10011"
            string query = @"SELECT s.*, k.KampDato FROM SpillerStats s INNER JOIN KampData k ON s.KampId = k.KampId WHERE s.SpillerId = '"+ playerId +"';";

            return SqlDataAccess.GetData<DLPlayerStatsModel>(query);
        }
        public static List<DLPlayerStatsModel> GetCurrentSeasonPlayerStats(int playerId)
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            string seasonStart = (year - 1) + "/09/01";
            string seasonEnd = year + "/06/01";
            /*
            SELECT s.*, k.KampDato FROM SpillerStats s 
            INNER JOIN KampData k ON s.KampId = k.KampId 
            WHERE k.KampDato BETWEEN '"+ seasonStart +"' AND '" + seasonEnd + "' 
            AND s.SpillerId = '" + playerId + "';
             */
            string query = @"SELECT s.*, k.KampDato FROM SpillerStats s INNER JOIN KampData k ON s.KampId = k.KampId WHERE k.KampDato BETWEEN '" + seasonStart + "' AND '" + seasonEnd + "' AND s.SpillerId = '" + playerId + "';";

            return SqlDataAccess.GetData<DLPlayerStatsModel>(query);
        }
    }
}
