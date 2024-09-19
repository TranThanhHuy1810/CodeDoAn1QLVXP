using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class DoanhThu2
    {
        public static DataTable DoanhThu(string idMovie, DateTime fromDate, DateTime toDate)
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetRevenueByMovieAndDate @idMovie , @fromDate , @toDate", new object[] { idMovie, fromDate, toDate });
        }
    }
}
