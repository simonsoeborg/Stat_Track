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

            string query = @"INSERT INTO Player (Name, Position, YOB) VALUES (@Name, @Position, @YOB);";

            return SqlDataAccess.SaveData(query, data);
        }

        public static int InsertPlayerInTeam(int TeamID, int PlayerID)
        {

            TeamPlayerModel data = new TeamPlayerModel()
            {
                PlayerID = PlayerID,
                TeamID = TeamID
            };
            string query = @"INSERT INTO TeamPlayers (TeamID, PlayerID) VALUES (@TeamID, @PlayerID);";

            return SqlDataAccess.SaveData(query, data);
        }



        public static int DeletePlayer(int? playerId)
        {
            string query = @"DELETE FROM Player WHERE Id = " + playerId + ";";

            return SqlDataAccess.SaveData(query, new { });
        }

        public static List<PlayerModel> LoadPlayers()
        {
            string query = @"SELECT * FROM Player;";

            return SqlDataAccess.GetData<PlayerModel>(query);
        }


        public static List<PlayerModel> LoadSpecificPlayer(int id)
        {
            string query = @"SELECT * FROM Player Where Id = '"+ id + "' ;";

            return SqlDataAccess.GetData<PlayerModel>(query);
        }


        public static List<TeamPlayerModel> LoadTeamPlayers(int id)
        {
            string query = @"SELECT * FROM TeamLineUp WHERE TeamID = '" + id +"' ;";

            return SqlDataAccess.GetData<TeamPlayerModel>(query);
        }

        public static int UpdatePlayer(int playerId, string playerName, string playerPosition, int YOB)
        {
            string query = @"UPDATE Player SET Name = " + "'" + playerName + "'" + ", Position = " + "'" + playerPosition + "'" + ", YOB = " + "'" + YOB + "'" + "  WHERE  Id =" + playerId + ";";

            Console.WriteLine(query);

            return SqlDataAccess.SaveData(query, new { });
        }
    }
}
