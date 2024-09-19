using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class KhachHang1
    {
        public KhachHang1(string id,string TenKh,int DiemTichLuy,int SDT)
        {
            this.ID=id;
            this.TenKH=TenKh;
            this.DiemTichLuy = DiemTichLuy;
            this.SDT=SDT;
        }
        public KhachHang1(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.TenKH = row["HoTen"].ToString();
            this.DiemTichLuy = (int)row["DiemTichLuy"];
            this.SDT = (int)row["SDT"];
        }
        public string ID {  get; set; }
        public string TenKH { get; set; }
        public int SDT { get; set; }   
        public int DiemTichLuy { get; set; }
    }
}
