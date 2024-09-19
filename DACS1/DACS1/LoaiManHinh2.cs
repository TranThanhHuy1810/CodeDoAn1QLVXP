using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DACS1
{
    public class LoaiManHinh2
    {
        public static List<LoaiManHinh1> GetListScreenType()
        {
            List<LoaiManHinh1> DanhSachLoaiManHinh = new List<LoaiManHinh1>();
            DataTable data =DataProvider.ExecuteQuery("SELECT * FROM dbo.LoaiManHinh");
            foreach (DataRow item in data.Rows)
            {
                LoaiManHinh1 loaiManHinh1 = new LoaiManHinh1(item);
                DanhSachLoaiManHinh.Add(loaiManHinh1);
            }
            return DanhSachLoaiManHinh;
        }
        public static DataTable GetScreenType()
        {
            return DataProvider.ExecuteQuery("SELECT id AS [Mã loại màn hình], TenMH as [Tên màn hình] FROM dbo.LoaiManHinh");
        }
        public static DataTable GetScreenTypeByFormatFilm(string LoaiManHinhID)
        {
            return DataProvider.ExecuteQuery("SELECT *  FROM dbo.LoaiManHinh where id = '" + LoaiManHinhID + "'");
        }
        public static bool ThemLoaiManHinh(string id, string name)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertScreenType @idScreenType , @ten", new object[] { id, name });
            return result > 0;
        }
        public static bool CapNhatLoaiManHinh(string id, string name)
        {
            string command = string.Format("UPDATE dbo.LoaiManHinh SET TenMH = N'{0}' WHERE id = '{1}'", name, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }
        public static bool XoaLoaiManHinh(string id)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhongChieu WHERE idLoaiManHinh = '" + id + "'");
            DataProvider.ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE idLoaiManHinh = '" + id + "'");

            int result = DataProvider.ExecuteNonQuery("DELETE dbo.LoaiManHinh WHERE id = '" + id + "'");
            return result > 0;
        }
        public static LoaiManHinh1 GetScreenTypeByName(string TenManHinh)
        {
            LoaiManHinh1 loaiManHinh1 = null;
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.LoaiManHinh WHERE TenMH = N'" + TenManHinh + "'");
            foreach (DataRow item in data.Rows)
            {
                loaiManHinh1 = new LoaiManHinh1(item);
                return loaiManHinh1;
            }
            return loaiManHinh1;
        }
    }
}
