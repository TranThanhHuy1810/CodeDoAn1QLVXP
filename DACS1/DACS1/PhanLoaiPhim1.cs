using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class PhanLoaiPhim1
    {
        public  PhanLoaiPhim1(string idPhim,string idTheLoai)
        {
            this.IDPhim=idPhim;
            this.IDTheLoai=idTheLoai;
        }
        public PhanLoaiPhim1(DataRow row) {
            this.IDPhim = row["idPhim"].ToString();
            this.IDTheLoai = row["idTheLoai"].ToString();
        
        }
        public string IDPhim { get; set; }  
        public string IDTheLoai { get; set; }
    }
}
