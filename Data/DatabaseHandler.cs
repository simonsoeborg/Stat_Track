using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Data
{
    public class DatabaseHandler
    {
        private static string dbConnectionString = "Server=mysql30.unoeuro.com;Database=uglyrage_com_db_aspnet;User=uglyrage_com;Password=2d4f6r3t";

        public static string GetConnectionString()
        {
            return dbConnectionString;
        }
    }
}
