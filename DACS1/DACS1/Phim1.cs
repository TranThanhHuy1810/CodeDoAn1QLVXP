using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class Phim1
    {
        public Phim1(string id,string name,float ThoiLuong,DateTime GBD,DateTime GKT,string QuocGia,string DaoDien,int NamSX, byte[] anh)
        {
            this.ID = id;
            this.Name=name;
            this.ThoiLuong=ThoiLuong;   
            this.GBD=GBD;
            this.GKT=GKT;
            this.QuocGia=QuocGia;
            this.DaoDien=DaoDien;
            this.NamSX=NamSX;
            this.Anh=anh;
        }
        public Phim1(DataRow row)
        {
            this.ID = row["id"].ToString(); 
            this.Name = row["TenPhim"].ToString();
            this.ThoiLuong = float.Parse(row["ThoiLuong"].ToString());
            this.GBD = (DateTime)row["NgayKhoiChieu"];
            this.GKT = (DateTime)row["NgayKetThuc"];
            this.QuocGia = row["SanXuat"].ToString();
            this.DaoDien = row["DaoDien"].ToString();
            this.NamSX = (int)row["NamSX"];
            if (row["ApPhich"].ToString() == "")
                this.Anh = null;
            else
                this.Anh= (byte[])row["ApPhich"];
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public float ThoiLuong { get; set; }
        public DateTime GBD { get; set; }
        public DateTime GKT { get; set; }
        public string QuocGia { get; set; }
        public string DaoDien { get; set; }
        public int NamSX { get; set;}
        public byte[] Anh { get; set; }
    }
}
