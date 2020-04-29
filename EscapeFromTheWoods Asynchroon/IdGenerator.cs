using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon
{
    static class IdGenerator
    {
        private static int _currentId { get; set; } = -1;
        private static string _connectionString = @"Data Source=DESKTOP-VCI7746\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True";
        public static int GetNextId()
        {
            if (_currentId == -1)
            {
                _currentId = GetLatestId();
            }
            return _currentId++;
        }
        private static int GetLatestId()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = "SELECT COUNT(DISTINCT(woodID)) AS \"Count\" FROM WoodRecords";
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                connection.Open();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int idCount = (int)reader["Count"];
                    reader.Close();
                    return idCount;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw new Exception("An error occured while retrieving the WoodId");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
