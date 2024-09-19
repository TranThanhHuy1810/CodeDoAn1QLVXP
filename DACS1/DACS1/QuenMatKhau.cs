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
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            lblKetQua.Text = "";
        }
        modify modify = new modify();

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (email.Trim() == "")
            {
                MessageBox.Show("vui lòng nhập email đăng ký!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "select * from TaiKhoan where Email= '" + email + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    lblKetQua.ForeColor = Color.Blue;
                    lblKetQua.Text = "Mật Khẩu:" + modify.TaiKhoans(query)[0].MatKhau;
                }
                else
                {
                    lblKetQua.ForeColor = Color.Red;
                    lblKetQua.Text = "Email chưa được đăng ký !";
                }
            }
        }
    }
}
