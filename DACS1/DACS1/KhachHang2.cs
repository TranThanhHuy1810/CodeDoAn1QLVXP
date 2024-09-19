using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class KhachHang2
    {
        public static DataTable LayBienTrongKhachHang(string customerID, string name)
        {
            string query = "Select * from KhachHang where id = '" + customerID + "' and HoTen = N'" + name + "'";
            return DataProvider.ExecuteQuery(query);
        }
        public static DataTable LayDanhSachSach()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetCustomer");
        }
        public static bool ThemKhachHang(string id, string hoTen, int sdt)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertCustomer @idCus , @hoTen  , @sdt  ", new object[] { id, hoTen, sdt });
            return result > 0;
        }

        public static bool CapNhatKhachHang(string id, string hoTen,int sdt, int DiemTichLuy)
        {
            string command = string.Format("UPDATE dbo.KhachHang SET HoTen = N'{0}', SDT = '{1}', DiemTichLuy = {2} WHERE id = '{3}'", hoTen, sdt, DiemTichLuy, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool CapNhatDiemTichLuy(string id, int DiemTichLuy)
        {
            string command = string.Format("UPDATE dbo.KhachHang SET  DiemTichLuy = {0} WHERE id = '{1}'", DiemTichLuy, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool XoaKhachHang(string id)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.KhachHang WHERE id = '" + id + "'");
            return result > 0;
        }

    }
}
