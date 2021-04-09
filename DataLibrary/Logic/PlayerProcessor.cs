using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class PlayerProcessor
    {
        public static int CreatePlayer(string playerName, string playerPosition, int playerYOB, string connectionString)
        {
            PlayerModel data = new PlayerModel()
            {
                Name = playerName,
                Position = playerPosition,
                YOB = playerYOB
            };

            string query = @"INSERT INTO Player (Name, Position, YOB) VALUES (@Name, @Position, @YOB);";

            return SQLDataAccess.SaveData(query, data, connectionString);
        }

        public static int DeletePlayer(int playerId, string connectionString)
        {
            string query = @"DELETE FROM Player WHERE Id = " + playerId + ";";

            return SQLDataAccess.SaveData(query, new { }, connectionString);
        }

        public static List<PlayerModel> LoadPlayers(string connectionString)
        {
            string query = @"SELECT * FROM Player;";

            return SQLDataAccess.GetData<PlayerModel>(query, connectionString);
        }
    }
}
