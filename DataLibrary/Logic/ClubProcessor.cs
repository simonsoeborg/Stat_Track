using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class ClubProcessor
    {
        public static int CreateClub(string clubInitials, string clubName, string clubAddress, int clubPostal, string clubCity, string connectionString)
        {
            ClubModel data = new ClubModel()
            {
                Initials = clubInitials,
                Name = clubName,
                Address = clubAddress,
                Postal = clubPostal,
                City = clubCity
            };

            string query = @"INSERT INTO Clubs (initials, name, address, postal, city) VALUES (@Initials, @Name, @Address, @Postal, @City);";

            return SQLDataAccess.SaveData(query, data, connectionString);
        }

        public static int DeleteClub(int clubId, string connectionString)
        {
            string query = @"DELETE FROM Clubs WHERE Id = " + clubId + ";";

            return SQLDataAccess.SaveData(query, new { }, connectionString);
        }

        public static List<ClubModel> LoadClubs(string connectionString)
        {
            string query = @"SELECT id, initials, name, address, postal, city FROM Clubs;";

            return SQLDataAccess.GetData<ClubModel>(query, connectionString);
        }
    }
}
