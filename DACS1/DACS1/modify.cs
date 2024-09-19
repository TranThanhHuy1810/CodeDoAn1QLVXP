using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DACS1
{
    internal class modify
    {
        public modify()
        {
        }
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public List<TaiKhoan> TaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    string tenTaiKhoan = dataReader.GetString(0);
                    string matKhau = dataReader.GetString(1);
                    string quyen = dataReader.GetString(3);
                    taiKhoans.Add(new TaiKhoan(tenTaiKhoan, matKhau, quyen));
                }
                sqlConnection.Close();
            }
            return taiKhoans;
        }
        public void Command(string query, params object[] parameters)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public DataTable Table(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public object ExecuteScalar(string query, params object[] parameters)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                return sqlCommand.ExecuteScalar();
            }
        }
        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int result = 0;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm các tham số vào câu lệnh
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                result = command.ExecuteNonQuery();
                connection.Close();
            }
            return result;

        }
    }
}