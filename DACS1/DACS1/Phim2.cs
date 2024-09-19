using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class Phim2
    {
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        //byte[] -> ảnh
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static List<Phim1> GetListMovieByDate(DateTime date)
        {
            List<Phim1> phim1s = new List<Phim1>();
            DataTable data = DataProvider.ExecuteQuery("select * from Phim where @Date <= NgayKetThuc", new object[] { date });
            foreach (DataRow row in data.Rows)
            {
                Phim1 phim = new Phim1(row);
                phim1s.Add(phim);
            }
            return phim1s;
        }
        public static List<Phim1> GetListMovie()
        {
            List<Phim1> phim1s = new List<Phim1>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM Phim");
            foreach (DataRow row in data.Rows)
            {
                Phim1 phim = new Phim1(row);
                phim1s.Add(phim);
            }
            return phim1s;
        }
        public static DataTable GetMovie()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetMovie");
        }
        public static bool ThemPhim(string id, string name, float ThoiLuong, DateTime NBD, DateTime NKT, string sx, string DaoDien, int Nam, byte[] image)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.NVarChar) { Value = id },
        new SqlParameter("@tenPhim", SqlDbType.NVarChar) { Value = name },
        new SqlParameter("@thoiLuong", SqlDbType.Float) { Value = ThoiLuong },
        new SqlParameter("@ngayKhoiChieu", SqlDbType.DateTime) { Value = NBD },
        new SqlParameter("@ngayKetThuc", SqlDbType.DateTime) { Value = NKT },
        new SqlParameter("@sanXuat", SqlDbType.NVarChar) { Value = sx },
        new SqlParameter("@daoDien", SqlDbType.NVarChar) { Value = DaoDien },
        new SqlParameter("@namSX", SqlDbType.Int) { Value = Nam },
        new SqlParameter("@apPhich", SqlDbType.VarBinary) { Value = image }
            };

            int result = DataProvider.ExecuteNonQuery("USP_InsertMovie", parameters);
            return result > 0;
        }

        public static bool CapNhatPhim(string id, string name, float ThoiLuong, DateTime NBD, DateTime NKT, string sx, string DaoDien, int Nam, byte[] image)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.NVarChar) { Value = id },
        new SqlParameter("@tenPhim", SqlDbType.NVarChar) { Value = name },
        new SqlParameter("@thoiLuong", SqlDbType.Float) { Value = ThoiLuong },
        new SqlParameter("@ngayKhoiChieu", SqlDbType.DateTime) { Value = NBD },
        new SqlParameter("@ngayKetThuc", SqlDbType.DateTime) { Value = NKT },
        new SqlParameter("@sanXuat", SqlDbType.NVarChar) { Value = sx },
        new SqlParameter("@daoDien", SqlDbType.NVarChar) { Value = DaoDien },
        new SqlParameter("@namSX", SqlDbType.Int) { Value = Nam },
        new SqlParameter("@apPhich", SqlDbType.VarBinary) { Value = image }
            };

            int result = DataProvider.ExecuteNonQuery("USP_UpdateMovie", parameters);
            return result > 0;
        }
        public static Phim1 GetMovieByID(string id)
        {
            Phim1 phim = null;
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.Phim WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                phim = new Phim1(item);
                return phim;
            }
            return phim;
        }
        public static bool XoaPhim(string id)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + id + "'");
            DataProvider.ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE idPhim = '" + id + "'");

            PhanLoaiPhim2.XoaIdPhanLoaiPhim(id);
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.Phim WHERE id = '" + id + "'");
            return result > 0;
        }

    }
}
