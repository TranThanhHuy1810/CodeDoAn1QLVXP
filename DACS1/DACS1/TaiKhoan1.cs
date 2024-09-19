using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1
{
    public partial class TaiKhoan1 : Form
    {   BindingSource DanhSachTaiKhoan=new BindingSource();
        public TaiKhoan1()
        {
            InitializeComponent();
            LoadTaiKhoan();
        }
        void LoadTaiKhoan()
        {
            dgvTaiKhoan.DataSource = DanhSachTaiKhoan;
            LoadDanhSachTaiKhoan();
            LoaddgvTaiKhoan();
        }
        void LoadDanhSachTaiKhoan()
        {
            DanhSachTaiKhoan.DataSource = TaiKhoan2.LayDanhSachSach();
        }
        void LoaddgvTaiKhoan()
        {
            txtTaiKhoan.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "Tài Khoản",true, DataSourceUpdateMode.Never);
            txtMatKhau.DataBindings.Add("Text",dgvTaiKhoan.DataSource,"Mật Khẩu",true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Add("Text",dgvTaiKhoan.DataSource,"Email",true,DataSourceUpdateMode.Never);
            txtQuyen.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "Quyền", true, DataSourceUpdateMode.Never);
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
           txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtEmail.Clear();
            txtQuyen.Clear();
        }
        void XoaTaiKhoan(string TaiKhoan)
        {
            if (TaiKhoan2.XoaTaiKhoan(TaiKhoan))
            {
                MessageBox.Show("Xóa Thành Công");
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string TaiKhoan=txtTaiKhoan.Text;
            XoaTaiKhoan(TaiKhoan);
            LoadDanhSachTaiKhoan();
        }
    }
}
