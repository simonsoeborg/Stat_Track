using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class PlayerProcessor
    {
        public static int CreatePlayer(string playerName, string playerPosition, int playerYOB, int TeamID)
        {
            TeamPlayerModel data = new TeamPlayerModel()
            {
                Name = playerName,
                Position = playerPosition,
                YOB = playerYOB,
                TeamID = TeamID
            };

            string query = @"INSERT INTO TeamPlayer (TeamID, Name, Position, YOB) VALUES (@TeamID, @Name, @Position, @YOB);";

            return SqlDataAccess.SaveData(query, data);
        }

  
        public static int DeletePlayer(int? playerId)
        {
            string query = @"DELETE FROM TeamPlayer WHERE Id = " + playerId + ";";

            return SqlDataAccess.SaveData(query, new { });
        }

        public static List<TeamPlayerModel> LoadPlayers()
        {
            string query = @"SELECT * FROM TeamPlayer;";

            return SqlDataAccess.GetData<TeamPlayerModel>(query);
        }


        public static List<TeamPlayerModel> LoadTeamPlayers(int id)
        {
            string query = @"SELECT * FROM TeamPlayer WHERE TeamID =" + id +";";

            return SqlDataAccess.GetData<TeamPlayerModel>(query);
        }

        public static int UpdatePlayer(int playerId, string playerName, string playerPosition, int YOB)
        {
            string query = @"UPDATE TeamPlayer SET Name = " + "'" + playerName + "'" + ", Position = " + "'" + playerPosition + "'" + ", YOB = " + "'" + YOB + "'" + "  WHERE  Id =" + playerId + ";";

            Console.WriteLine(query);

            return SqlDataAccess.SaveData(query, new { });
        }

        public static List<TeamPlayerModel> LoadAllUsersPlayers(int teamId)
        {
            string query = @"SELECT * FROM TeamPlayer WHERE TeamID =" + teamId + ";";

            return SqlDataAccess.GetData<TeamPlayerModel>(query);
        }
    }
}
