using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class TaiKhoan2
    {
        public static DataTable LayDanhSachSach()
        {
            return DataProvider.ExecuteQuery("EXEC USP_TaiKhoan");
        }

        public static bool XoaTaiKhoan(string TaiKhoan)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.TaiKhoan WHERE TaiKhoan = '" + TaiKhoan + "'");
            return result > 0;
        }

     
    }
}
    