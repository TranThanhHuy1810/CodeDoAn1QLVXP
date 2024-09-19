using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    internal class Connection
    {
        private static string ConnectionString = @"Data Source=DESKTOP-P2DNTFQ;Initial Catalog=QLVXP;Integrated Security=True;TrustServerCertificate=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
