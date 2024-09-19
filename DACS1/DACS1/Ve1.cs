using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class Ve1
    {
        public Ve1(string iD, string idLichChieu, string seatName, string idKhachHang, float Gia,int TrangThai)
        {
            this.ID = iD;
            this.MãLịchChiếu = idLichChieu;
            this.SeatName = seatName;
            this.MãKháchHàng=idKhachHang;
            this.TrạngThái=TrangThai;
            this.Gía = Gia;
        }
        public Ve1(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.MãLịchChiếu = row["idLichChieu"].ToString();
            this.SeatName = row["MaGheNgoi"].ToString();
            this.MãKháchHàng = row["idKhachHang"].ToString();
            this.TrạngThái = (int)row["TrangThai"];
            if (row["TienBanVe"].ToString() == "")
                this.Gía = 0;
            else
                this.Gía = float.Parse(row["TienBanVe"].ToString());
        }
        public string ID { get; set; }
        public string MãLịchChiếu { get; set; }
        public string SeatName { get; set;}
        public string MãKháchHàng {  get; set; }
        public float Gía { get; set; }
        public int TrạngThái { get; set; }
    }
}
