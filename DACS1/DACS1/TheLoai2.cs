using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class TheLoai2
    {
        public static List<TheLoai1> GetListGenre()
        {
            List<TheLoai1> DanhSachTheLoai = new List<TheLoai1>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.TheLoai");
            foreach (DataRow item in data.Rows)
            {
                TheLoai1 TheLoai = new TheLoai1(item);
                DanhSachTheLoai.Add(TheLoai);
            }
            return DanhSachTheLoai;
        }
        public static DataTable GetTheLoai()
        {
            return DataProvider.ExecuteQuery("SELECT id AS [Mã thể loại], TenTheLoai AS [Tên thể loại] FROM dbo.TheLoai");
        }
        public static bool ThemTheLoai(string id, string name)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertGenre @idGenre , @ten ", new object[] { id, name });
            return result > 0;
        }
        public static bool CapNhatTheLoai(string id, string name)
        {
            string command = string.Format("UPDATE dbo.TheLoai SET TenTheLoai = N'{0}' WHERE id = '{1}'", name, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }
        public static bool XoaTheLoai(string id)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idTheLoai = '" + id + "'");

            int result = DataProvider.ExecuteNonQuery("DELETE dbo.TheLoai WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
