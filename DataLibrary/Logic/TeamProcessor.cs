using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    class TeamProcessor
    {
        public static int CreateTeam(string teamName, ClubModel club, string teamUYear, List<PlayerModel> playerList, int startYear, int endYear)
        {
            TeamModel data = new TeamModel()
            {
                Name = teamName,
                Club = club,
                Year = teamUYear,
                PlayerList = playerList,
                StartYear = startYear,
                EndYear = endYear
            };

            int ClubId = club.Id; 

            string query = @"INSERT INTO Team (Name, ClubId, TeamUYear, playerId, startDate, endDate) VALUES (@Name, @Position, @YOB);";

            return SqlDataAccess.SaveData(query, data);
        }

    }
}
