using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class DinhDangPhim2
    {
        public static List<DinhDangPhim1> GetListFormatMovieByMovie(string idPhim)
        {
            List<DinhDangPhim1> DanhSachDinhDang = new List<DinhDangPhim1>();
            string query = "select d.id, p.TenPhim, m.TenMH " +
                "from Phim p, DinhDangPhim d, LoaiManHinh m " +
                "where p.id = d.idPhim and d.idLoaiManHinh = m.id "
                + "and p.id = '" + idPhim + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                DinhDangPhim1 dinhDangPhim1 = new DinhDangPhim1(row);
                DanhSachDinhDang.Add(dinhDangPhim1);
            }
            return DanhSachDinhDang;
        }
        public static DataTable GetFormatMovieByID(string idPhim, string idLoaiMh)
        {
            string query = "select d.id, p.TenPhim, m.TenMH " +
                "from Phim p, DinhDangPhim d, LoaiManHinh m " +
                "where p.id = d.idPhim and d.idLoaiManHinh = m.id "
                + "and p.id = '" + idPhim + "' and m.id = '" + idLoaiMh + "'";
            return DataProvider.ExecuteQuery(query);
        }
        public static DinhDangPhim1 GetFormatMovieByName(string TenPhim, string TenMh)
        {
            string command = "SELECT DD.id, P.TenPhim, MH.TenMH " +
                              "FROM dbo.DinhDangPhim DD, dbo.Phim P, dbo.LoaiManHinh MH " +
                              "WHERE DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id AND P.TenPhim = N'" + TenPhim + "' AND MH.TENMH = N'" + TenMh + "'";
            DataTable data = DataProvider.ExecuteQuery(command);
            return new DinhDangPhim1(data.Rows[0]);
        }
        public static List<DinhDangPhim1> GetFormatMovie()
        {
            List<DinhDangPhim1> DanhSachDinhDangPhim = new List<DinhDangPhim1>();
            DataTable data = DataProvider.ExecuteQuery("SELECT DD.id, P.TenPhim, MH.TenMH " +
                                                        "FROM dbo.DinhDangPhim DD, dbo.Phim P, dbo.LoaiManHinh MH " +
                                                        "WHERE DD.idPhim = P.id AND DD.idLoaiManHinh = MH.id");
            foreach (DataRow item in data.Rows)
            {
                DinhDangPhim1 dinhDangPhim1 = new DinhDangPhim1(item);
                DanhSachDinhDangPhim.Add(dinhDangPhim1);
            }
            return DanhSachDinhDangPhim;
        }
        public static DataTable GetListFormatMovie()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetListFormatMovie");
        }
        public static bool ThemDinhDangPhim(string id, string idPhim, string idManHinh)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertFormatMovie @id , @idPhim , @idLoaiManHinh ", new object[] { id, idPhim, idManHinh });
            return result > 0;
        }

        public static bool CapNhatDinhDang(string id, string idPhim, string idManHinh)
        {
            string command = string.Format("UPDATE dbo.DinhDangPhim SET idPhim = '{0}', idLoaiManHinh = '{1}' WHERE id = '{2}'", idPhim, idManHinh, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool XoaDinhDang(string id)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.LichChieu WHERE idDinhDang = '" + id + "'");

            int result = DataProvider.ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
