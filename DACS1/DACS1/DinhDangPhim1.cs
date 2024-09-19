using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class DinhDangPhim1
    {
        public DinhDangPhim1(string id,string TenPhim,string TenManHinh) {
        this.ID=id;
        this.TenPhim=TenPhim;
        this.TenManHinh=TenManHinh;
        }
        public DinhDangPhim1(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.TenPhim = row["TenPhim"].ToString();
            this.TenManHinh = row["TenMH"].ToString() ;
        }
        public string ID { get; set; }
        public string TenPhim { get; set; }
        public string TenManHinh { get; set; }
    }
}
