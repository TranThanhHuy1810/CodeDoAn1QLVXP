using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class PhanLoaiPhim2
    {
        public static List<TheLoai1> GetListGenreByMovieID(string id)
        {
            List<TheLoai1> DanhSachTheLoai = new List<TheLoai1>();
            DataTable data = DataProvider.ExecuteQuery("EXEC USP_GetListGenreByMovie @idPhim", new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                TheLoai1 theLoai1 = new TheLoai1(item);
                 DanhSachTheLoai.Add(theLoai1);
            }
            return DanhSachTheLoai;
        }
        public static void ThemPhanLoaiPhim(string idPhim, List<TheLoai1> DanhSachTheLoai)
        {
            foreach (TheLoai1 item in DanhSachTheLoai)
            {
                string command = string.Format("INSERT dbo.PhanLoaiPhim (idPhim, idTheLoai) VALUES  ('{0}','{1}')", idPhim, item.ID);
                DataProvider.ExecuteNonQuery(command);
            }
        }

        public static void CapNhatPhanLoaiPhim(string idPhim, List<TheLoai1> DanhSachTheLoai)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + idPhim + "'");
            foreach (TheLoai1 item in DanhSachTheLoai)
            {
                string command = string.Format("INSERT dbo.PhanLoaiPhim (idPhim, idTheLoai) VALUES  ('{0}','{1}')", idPhim, item.ID);
                DataProvider.ExecuteNonQuery(command);
            }
        }

        public static void XoaIdPhanLoaiPhim(string idPhim)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + idPhim + "'");
        }
    }
}
