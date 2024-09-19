using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class PhongChieu1
    {
        public PhongChieu1(string id, string name,string LoaiManHinh,int seats,string TinhTrang,int row,
            int seatInrow)
        {
            this.ID=id;
            this.Name=name;
            this.LoaiManHinh=LoaiManHinh;
            this.Seats=seats;
            this.TinhTrang=TinhTrang;
            this.Row=row;
            this.SeatInRow=seatInrow;
        }
        public PhongChieu1(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenPhong"].ToString();
            this.LoaiManHinh = row["idLoaiManHinh"].ToString() ;
            this.Seats = (int)row["SoChoNgoi"];
            this.TinhTrang = row["TinhTrang"].ToString();
            this.Row = (int)row["SoHangGhe"];
            this.SeatInRow = (int)row["SoGheMotHang"];
        }
        public string ID {  get;  set; }
        public string Name { get; set; }
        public string LoaiManHinh { get; set; }
        public int Seats { get; set; }  
        public string TinhTrang { get; set; }
        public int Row { get; set; }    
        public int SeatInRow { get; set; }
            
    }
}
