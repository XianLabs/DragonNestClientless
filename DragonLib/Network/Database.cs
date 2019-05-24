using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;

//by XIAN
//mssql
namespace Database
{
    public sealed class Database
    {
        private readonly string m_connectionString;
        private readonly object m_locker;

        public Database(string connectionString)
        {
            m_connectionString = connectionString;
            m_locker = new object();
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(m_connectionString);
        }

        private SqlDataReader ExecuteDataQuery(SqlConnection connection, string query, params object[] objects)
        {
            query = string.Format(query, objects);

            SqlCommand command = new SqlCommand(query);
            command.ExecuteNonQuery();

            return command.ExecuteReader();
        }

        public string GetNotice(int id)
        {
            SqlConnection connection = GetConnection();

            connection.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM SendNotice WHERE Sent=0 and id=@id";

                command.Prepare();

                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id_num = reader.GetInt32(0);
                        string notice = reader.GetString(1);

                        return notice;
                    }
                }
                    
            }

            return string.Empty;
        }

        public void UpdateNotice(int id)
        {
            SqlConnection connection = GetConnection();

            connection.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE SendNotice SET Sent=1 WHERE ID=@id";

                command.Prepare();

                command.Parameters.AddWithValue("@id", id);
                int numRows = command.ExecuteNonQuery();
                Console.Write("{0}", numRows);
            }

        }

    }
}