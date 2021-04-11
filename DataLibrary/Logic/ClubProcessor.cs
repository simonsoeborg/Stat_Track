using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class ClubProcessor
    {
        public static int CreateClub(string clubInitials, string clubName, string clubAddress, int clubPostal, string clubCity)
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

            return SQLDataAccess.SaveData(query, data);
        }

        public static int DeleteClub(int clubId)
        {
            string query = @"DELETE FROM Clubs WHERE Id = " + clubId + ";";

            return SQLDataAccess.SaveData(query, new { });
        }

        public static List<ClubModel> LoadClubs()
        {
            string query = @"SELECT id, initials, name, address, postal, city FROM Clubs;";

            return SQLDataAccess.GetData<ClubModel>(query);
        }

        public static int UpdateClub(int clubId, string clubInitials, string clubName, string clubCity, int clubPostal, string clubAddress)
        {
            string query = @"UPDATE Clubs SET initials = " + "'" + clubInitials + "'" + ", name = " + "'" + clubName + "'" + ", address = " + "'" + clubAddress + "'" + ", postal = " + clubPostal + ", city = " + "'" + clubCity + "'" + "  WHERE  id =" + clubId + ";";

            Console.WriteLine(query);

            return SQLDataAccess.SaveData(query, new { });
        }

    }
}
