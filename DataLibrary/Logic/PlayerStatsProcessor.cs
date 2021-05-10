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

        public static List<int> AlreadyAddedPlayersToEntry = new List<int>();
        public static void insertDataToPlayerStats(string tidspunkt, int Attempts, int Goals, int KeeperSaves,
            int Assists, int playerId, int kampId)
        {
            if (AlreadyAddedPlayersToEntry.Contains(playerId))
            {
                UpdatePlayerStats(tidspunkt, Attempts, Goals, KeeperSaves, Assists, playerId, kampId);
            }
            else
            {
                AddPlayerStats(tidspunkt, Attempts, Goals, KeeperSaves, Assists, playerId, kampId);
                AlreadyAddedPlayersToEntry.Add(playerId);
            }
        }

        public static int UpdatePlayerStats(string tidspunkt, int Attempts, int Goals, int KeeperSaves, int Assists, int playerId, int kampId)
        {
            DLPlayerStatsModel psm = new DLPlayerStatsModel
            {
                Tidspunkt = tidspunkt,
                Attempts = Attempts,
                Assists = Assists,
                KeeperSaves = KeeperSaves,
                Goals = Goals
            };
            string query = @"UPDATE SpillerStats SET Tidspunkt = @Tidspunkt, Attempts = @Attempts, Goals = @Goals, Assists = @Assists, KeeperSaves = @KeeperSaves WHERE SpillerId = '" + playerId + "' AND KampId = '" + kampId + "';";
            return SqlDataAccess.SaveData(query, psm);
        }
        public static int AddPlayerStats(string tidspunkt, int Attempts, int Goals, int KeeperSaves, int Assists, int playerId, int kampId)
        {
            DLPlayerStatsModel psm = new DLPlayerStatsModel
            {
                Tidspunkt = tidspunkt,
                Attempts = Attempts,
                Assists = Assists,
                KeeperSaves = KeeperSaves,
                Goals = Goals
            };
            string query = @"INSERT INTO SpillerStats (SpillerId, Tidspunkt, Attempts, Goals, Assists, KeeperSaves, Mins2, gulekort, roedekort, KampId) VALUES ('"+ playerId +"', @Tidspunkt, @Attempts, @Goals, @Assists, @KeeperSaves, Mins2, Gulekort, Roedekort,'" + kampId + "');";
            return SqlDataAccess.SaveData(query, psm);
        }
    }
}
