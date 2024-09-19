using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class LichChieu1
    {
        public LichChieu1(string id, string TenPhongChieu, DateTime time,string idDinhDang,string TenPhim,float GiaVe,int TrangThai)
        {
            this.ID=id;
            this.TenPhongChieu=TenPhongChieu;
            this.Time = time;
            this.idDinhDang=idDinhDang;
            this.TenPhim=TenPhim;
            this.GiaVe=GiaVe;
            this.TrangThai=TrangThai;
        }
        public LichChieu1(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.TenPhongChieu = row["TenPhong"].ToString();
            this.TenPhim = row["TenPhim"].ToString();
            this.Time = (DateTime)row["ThoiGianChieu"];
            this.idDinhDang = row["idDinhDang"].ToString();
            if (row["GiaVe"].ToString() == "")
                this.GiaVe = 0;
            else
                this.GiaVe = float.Parse(row["GiaVe"].ToString());
            this.TrangThai = (int)row["TrangThai"];
        }
        public string ID {  get; set; }
        public string TenPhongChieu { get; set; }
        public string TenPhim { get; set; }
        public DateTime Time { get; set; }
        public string idDinhDang { get; set; }
        public float GiaVe { get; set;}
        public int TrangThai { get; set; }
    }
}

