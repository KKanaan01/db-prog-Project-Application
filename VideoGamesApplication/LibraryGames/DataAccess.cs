using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGames
{
    public static class DataAccess
    {
        public static DataTable GetData(string sqlQuery)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static object GetValue(string sql)
        {
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    object returnValue = cmd.ExecuteScalar();

                    conn.Close();

                    return returnValue;
                }
            }
        }

        public static int SendData(string sql)
        {
            int rowsAffected;

            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            return rowsAffected;
        }

        private static string getConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Games"].ConnectionString;
            return connectionString;
        }
    }
}
