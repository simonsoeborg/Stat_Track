using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class TeamProcessor
    {

        public static List <TeamModel> LoadTeams(string userID)
        {
            // Indputtet userId her sørger for at kun dine egne oprettede hold bliver vist.
            string query = @"SELECT * FROM Team WHERE CreatorId = '"+ userID+"';";

            return SqlDataAccess.GetData<TeamModel>(query);
        }

        public static int CreateTeam(string teamName, string clubId, string creatorId, string teamUYear, string division)
        {

            TeamModel data = new TeamModel()
            {
                Name = teamName,
                ClubId = clubId,
                CreatorId = creatorId,
                TeamUYear = teamUYear,
                Division = division,
                // PlayerList = new List<PlayerModel>()
                
            };
            string query = @"INSERT INTO Team (Name, CreatorId, ClubId, TeamUYear, Division) VALUES (@Name, @CreatorId, @ClubId, @TeamUYear, @Division);";
            Console.WriteLine(query);

            return SqlDataAccess.SaveData(query, data);
        }


        public static int DeleteTeam(int? id)
        {
            string query = @"DELETE FROM Team WHERE Id = " + id + ";";

            return SqlDataAccess.SaveData(query, new { });
        }

    }
}
