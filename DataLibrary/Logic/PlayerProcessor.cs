using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class PlayerProcessor
    {
        public static int CreatePlayer(string playerName, string playerPosition, string playerYOB)
        {
            PlayerModel data = new PlayerModel()
            {
                Name = playerName,
                Position = playerPosition,
                YOB = playerYOB
            };

            string query = @"INSERT INTO Player (Name, Position, YOB) VALUES (@PlayerName, @PlayerPosition, @PlayerYOB);";

            return SQLDataAccess.SaveData(query, data);
        }

        public static int DeletePlayer(int playerId)
        {
            string query = @"DELETE FROM Player WHERE Id = " + playerId + ";";

            return SQLDataAccess.SaveData(query, new { });
        }

        public static List<PlayerModel> LoadPlayers()
        {
            string query = @"SELECT * FROM Player;";

            return SQLDataAccess.GetData<PlayerModel>(query);
        }
    }
}
