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
    class SQLDataAccess
    {
        public static List<T> GetData<T>(string query, string connectionString)
        {
            using (IDbConnection conn = new MySqlConnection(connectionString))
            {
                return conn.Query<T>(query).ToList();
            }
        }
        
        public static int SaveData<T>(string query, T data, string connectionString)
        {
            using (IDbConnection conn = new MySqlConnection(connectionString))
            {
                return conn.Execute(query, data);
            }
        }
    }
}
