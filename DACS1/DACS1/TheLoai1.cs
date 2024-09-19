using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class TheLoai1
    {
        public TheLoai1(string id, string name) 
        { 
            this.ID=id;
            this.Name=name; 
        }
        public TheLoai1(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenTheLoai"].ToString();
        }
        public string ID { get;  set; }
        public string Name { get; set; }
    }
}
