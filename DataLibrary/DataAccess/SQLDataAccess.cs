using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string ConnString;

        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn =
                    new MySqlConnection(ConnString);
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public static List<T> GetData<T>(string query)
        {
            using (IDbConnection conn = GetConnection())
            {
                return conn.Query<T>(query).ToList();
            }
        }

        public static int SaveData<T>(string query, T data)
        {
            using (IDbConnection conn = GetConnection())
            {
                return conn.Execute(query, data);
            }
        }
    }
}
