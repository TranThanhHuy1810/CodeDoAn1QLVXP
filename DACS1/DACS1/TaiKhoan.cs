using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    internal class TaiKhoan
    {
        private string tenTaiKhoan;
        private string matkhau;
        private string quyen;
        public TaiKhoan()
        {
        }

        public TaiKhoan(string tenTaiKhoan, string matkhau, string quyen)
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.matkhau = matkhau;
            this.quyen = quyen;
        }
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MatKhau { get => matkhau; set => matkhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
