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
    public partial class CinemaCelling : Form
    {
        public bool thoat = true;
        public event EventHandler DangXuat;
        public CinemaCelling()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
        }

        private void CinemaCelling_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thoat)
            {
                Application.Exit();
            }
        }

        private void CinemaCelling_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thoat)
            {
                if (MessageBox.Show("Bạn Có Muốn Thoát Chương Trình!", "Thông Báo!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnPhimDangChieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhimDangChieu());
            label1.Text=btnPhimDangChieu.Text;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
            label1.Text=btnKhachHang.Text;
        }
    }
}
