using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public static class DataProvider
    {
        private static string connectionString = @"Data Source=DESKTOP-P2DNTFQ;Initial Catalog=QLVXP;Integrated Security=True;TrustServerCertificate=True";

        public static int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        string[] listParams = query.Split(' ');
                        int i = 0;
                        foreach (string param in listParams)
                        {
                            if (param.Contains('@'))
                            {
                                command.Parameters.AddWithValue(param, parameters[i]);
                                i++;
                            }
                        }
                    }

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public static DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        string[] listParams = query.Split(' ');
                        int i = 0;
                        foreach (string param in listParams)
                        {
                            if (param.Contains('@'))
                            {
                                command.Parameters.AddWithValue(param, parameters[i]);
                                i++;
                            }
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    return result;
                }
            }
        }
        public static object ExecuteScalar(string query, object[] parameters = null)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        string[] listParams = query.Split(' ');
                        int i = 0;
                        foreach (string param in listParams)
                        {
                            if (param.Contains('@'))
                            {
                                command.Parameters.AddWithValue(param, parameters[i]);
                                i++;
                            }
                        }
                    }

                    result = command.ExecuteScalar();
                }
            }
            return result;
        }
        public static object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
        }

    }
}
