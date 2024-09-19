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
    public partial class CinemaHome : Form
    {
        public bool thoat = true;
        public event EventHandler DangXuat;
        public CinemaHome()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
        }

        private void CinemaHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thoat)
            {
                Application.Exit();
            }
        }

        private void CinemaHome_FormClosing(object sender, FormClosingEventArgs e)
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
            if(currentFormChild != null)
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            label1.Text="Home";
        }

        private void btnLoaiManHinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiManHinh());
            label1.Text=btnLoaiManHinh.Text;
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TheLoaiPhim());
            label1.Text=btnTheLoai.Text;
        }

        private void btnPhongChieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhongChieu());
            label1.Text=btnPhongChieu.Text;
        }

        private void btnPhim_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Phim());
            label1.Text=btnPhim.Text;
        }

        private void btnDinhDang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DinhDang());
            label1.Text=btnDinhDang.Text;
        }

        private void btnLichChieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichChieu());
            label1.Text = btnLichChieu.Text;
        }

        private void btnVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ve());
            label1.Text=btnVe.Text;
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoan1());
            label1.Text=btnTaiKhoan.Text;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
            label1.Text=btnNhanVien.Text;
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoanhThu());  
            label1.Text=btnDoanhThu.Text;
        }
    }
}
