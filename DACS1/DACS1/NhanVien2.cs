using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class NhanVien2
    {
        public static NhanVien1 GetStaffByID(string id)
        {
            NhanVien1 staff = null;
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                staff = new NhanVien1(item);
                return staff;
            }
            return staff;
        }

        public static List<NhanVien1> GetStaff()
        {
            List<NhanVien1> staffList = new List<NhanVien1>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien");
            foreach (DataRow item in data.Rows)
            {
                NhanVien1 staff = new NhanVien1(item);
                staffList.Add(staff);
            }
            return staffList;
        }

        public static DataTable GetListStaff()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetStaff");
        }

        public static bool InsertStaff(string id, string hoTen, DateTime ngaySinh, string diaChi)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertStaff @idStaff , @hoTen , @ngaySinh , @diaChi ", new object[] { id, hoTen, ngaySinh, diaChi});
            return result > 0;
        }
        public static bool DeleteStaff(string id)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.NhanVien WHERE MaNv = '" + id + "'");
            return result > 0;
        }

    }
}
