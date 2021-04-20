using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class TeamProcessor
    {
     
        public static int CreateTeam(string teamName, int clubId, string creatorId, string teamUYear, string division)
        {

            TeamModel data = new TeamModel()
            {
                Name = teamName,
                Club = clubId,
                CreatorId = creatorId,
                TeamUYear = teamUYear,
                Division = division,
                PlayerList = new List<PlayerModel>()
                
            };

            int ClubId = club.Id; 

            string query = @"INSERT INTO Team (Name, CreatorId, ClubId, TeamUYear, Divison) VALUES (@Name, @CreatorId, @ClubId, @TeamUYear, @Division);";

            return SqlDataAccess.SaveData(query, data);
        }

    }
}
