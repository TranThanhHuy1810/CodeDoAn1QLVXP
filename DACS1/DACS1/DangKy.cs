using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool checkEmail(string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        modify modify = new modify();

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            string NhapLaiMatKhau = txtNhapLaiMatKhau.Text;
            string email = txtEmail.Text;
            if (modify.TaiKhoans("select * from TaiKhoan where TaiKhoan ='" + tentk + "'").Count != 0)
            {
                MessageBox.Show("Tên tài khoản đã được đăng ký!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự với các ký tự chữ và số ,chữ hoa và chữ thường ! ", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!checkAccount(matkhau))
            {
                MessageBox.Show("Vui lòng nhập tên mật khẩu dài 6-24 ký tự với các ký tự chữ và số ,chữ hoa và chữ thường ! ", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (NhapLaiMatKhau != matkhau)
            {
                MessageBox.Show("vui lòng xác nhận mật khẩu chính xác ! ", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng Email!", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (modify.TaiKhoans("select * from TaiKhoan where Email ='" + email + "'").Count != 0)
            {
                MessageBox.Show("Email đã được đăng ký !", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string query = " INSERT INTO TaiKhoan (TaiKhoan, MatKhau, Email, Quyen) VALUES('" + tentk + "', '" + matkhau + "', '" + email + "','user')";
                modify.Command(query);
                if (MessageBox.Show("Đăng Ký Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Đã Có Lỗi Xảy Ra Khi Đăng Ký Tài Khoản!");
            }
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtNhapLaiMatKhau.UseSystemPasswordChar = !checkBox2.Checked;
            if (checkBox2.Checked)
            {
               txtNhapLaiMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
