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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           txtMatKhau.UseSystemPasswordChar = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
        modify modify = new modify();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            if (string.IsNullOrWhiteSpace(tentk) || string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string query = "select * from TaiKhoan where TaiKhoan='" + tentk + "'and Matkhau='" + mk + "'";
            List<TaiKhoan> taiKhoans = modify.TaiKhoans(query);
            if (modify.TaiKhoans(query).Count != 0)
            {
                TaiKhoan taiKhoan = taiKhoans[0];
                if (taiKhoan.Quyen == "admin")
                {
                    CinemaHome cinemaHome = new CinemaHome();
                    cinemaHome.Show();
                    this.Hide();
                    cinemaHome.DangXuat += CinemaHome_DangXuat;
                    MessageBox.Show("Đăng nhập thành công !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (taiKhoan.Quyen == "user")
                {
                    CinemaCelling cinemaCelling = new CinemaCelling();
                    cinemaCelling.Show();
                    this.Hide();
                    cinemaCelling.DangXuat += CinemaCelling_DangXuat;
                    MessageBox.Show("Đăng nhập thành công !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Tên tài khoản or mật khẩu không chính xác!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CinemaCelling_DangXuat(object sender, EventArgs e)
        {
            (sender as CinemaCelling).thoat = false;
            (sender as CinemaCelling).Close();
            txtMatKhau.Clear();
            this.Show();
        }

        private void CinemaHome_DangXuat(object sender, EventArgs e)
        {
            (sender as CinemaHome).thoat = false;
            (sender as CinemaHome).Close();
            txtMatKhau.Clear(); 
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dangky = new DangKy();
            dangky.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau queMK = new QuenMatKhau();
            queMK.ShowDialog();
        }
    }
}
