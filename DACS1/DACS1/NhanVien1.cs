using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class NhanVien1
    {
        public NhanVien1(string MaNv,string HoTen,DateTime NgaySinh,string DiaChi)
        {
            this.MaNv=MaNv;
            this.HoTen=HoTen;
            this.NgaySinh=NgaySinh;
            this.DiaChi=DiaChi;
        }
        public NhanVien1(DataRow row)
        {
            this.MaNv = row["MaNv"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.NgaySinh = (DateTime)row["NgaySinh"]; ;
            this.DiaChi = row["SDT"].ToString();
        
        }
        public string MaNv {  get; set; }
        public string HoTen { get; set; }   
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set;}
    }
}
