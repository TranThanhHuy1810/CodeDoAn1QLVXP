using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class PhongChieu2
    {

        public static PhongChieu1 GetTenPhongChieu(string TenPhong)
        {
            string query = "select * from dbo.PhongChieu where TenPhong = '" + TenPhong + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            return new PhongChieu1(data.Rows[0]);
        }
        public static PhongChieu1 GetMaPhongChieu(string id)
        {
            string query = "select * from dbo.PhongChieu where id = '" + id + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            if (data.Rows.Count > 0)
                return new PhongChieu1(data.Rows[0]);
            return null;
        }
        public static List<PhongChieu1> GetCinemaByScreenTypeID(string idLoaiManHinh)
        {
            List<PhongChieu1> phongChieu1s = new List<PhongChieu1>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.PhongChieu where idLoaiManHinh ='" + idLoaiManHinh + "'");
            foreach (DataRow item in data.Rows)
            {
                PhongChieu1 phongChieu1 = new PhongChieu1(item);
                phongChieu1s.Add(phongChieu1);
            }
            return phongChieu1s;
        }
        public static DataTable GetDanhSachPhongChieu()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetCinema");
        }
        public static bool ThemPhongChieu(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertCinema @idCinema , @tenPhong , @idMH , @soChoNgoi , @tinhTrang , @soHangGhe , @soGheMotHang", new object[] { id, name, idMH, seats, status, numberOfRows, seatsPerRow });
            return result > 0;
        }

        public static bool CapNhatPhongChieu(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            string command = string.Format("UPDATE dbo.PhongChieu SET TenPhong = N'{0}', idLoaiManHinh = '{1}', SoChoNgoi = {2}, TinhTrang = {3}, SoHangGhe = {4}, SoGheMotHang = {5} WHERE id = '{6}'", name, idMH, seats, status, numberOfRows, seatsPerRow, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool XoaPhongChieu(string id)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.LichChieu WHERE idPhong = '" + id + "'");

            int result = DataProvider.ExecuteNonQuery("DELETE dbo.PhongChieu WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
