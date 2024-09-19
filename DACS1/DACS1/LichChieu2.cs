using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class LichChieu2
    {
        public static DataTable GetListShowTimeByFormatMovie(string idDinhDang, DateTime date)
        {
            string query = "USP_GetListShowTimesByFormatMovie @ID , @Date";
            return DataProvider.ExecuteQuery(query, new object[] { idDinhDang, date });
        }
        public static List<LichChieu1> GetAllListShowTimes()
        {
            List<LichChieu1> lichChieu1s = new List<LichChieu1>();
            DataTable data = DataProvider.ExecuteQuery("USP_GetAllListShowTimes");
            foreach (DataRow row in data.Rows)
            {
                LichChieu1 lichChieu1 = new LichChieu1(row);
                lichChieu1s.Add(lichChieu1);
            }
            return lichChieu1s;
        }
        public static List<LichChieu1> GetListShowTimesNotCreateTickets()
        {
            List<LichChieu1> lichChieu1s = new List<LichChieu1>();
            DataTable data = DataProvider.ExecuteQuery("USP_GetListShowTimesNotCreateTickets");
            foreach (DataRow row in data.Rows)
            {
                LichChieu1 lichChieu1 = new LichChieu1(row);
                lichChieu1s.Add(lichChieu1);
            }
            return lichChieu1s;
        }
        public static int CapNhatTrangThaiLichChieu(string idLichChieu, int TrangThai)
        {
            string query = "USP_UpdateStatusShowTimes @idLichChieu , @status";
            return DataProvider.ExecuteNonQuery(query, new object[] { idLichChieu, TrangThai});
        }

        public static DataTable GetListShowtime()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetShowtime");
        }
        public static bool ThemLichChieu(string id, string IdPhong, string idDinhDang, DateTime time, float GiaVe)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertShowtime @id , @idPhong , @idDinhDang , @thoiGianChieu , @giaVe ", new object[] { id, IdPhong, idDinhDang, time, GiaVe });
            return result > 0;
        }

        public static bool CapNhatLichChieu(string id, string IdPhong, string idDinhDang, DateTime time, float GiaVe)
        {
            string command = string.Format("USP_UpdateShowtime @id , @idPhong , @idDinhDang , @thoiGianChieu , @giaVe ");
            int result = DataProvider.ExecuteNonQuery(command, new object[] { id, IdPhong, idDinhDang, time, GiaVe });
            return result > 0;
        }

        public static bool XoaLichChieu(string id)
        {
            Ve2.XoaVe(id);

            int result = DataProvider.ExecuteNonQuery("DELETE dbo.LichChieu WHERE id = '" + id + "'");
            return result > 0;
        }

    }
}
