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
    public partial class TheLoaiPhim : Form
    {
        BindingSource DanhSachTheLoai = new BindingSource();
        public TheLoaiPhim()
        {
            InitializeComponent();
            LoadTheLoai();
        }
        void LoadTheLoai()
        {
            dgvTheLoai.DataSource = DanhSachTheLoai;
            LoadDanhSachTheLoai();
            ThemDanhSachTheLoaidgv();
        }
        void LoadDanhSachTheLoai()
        {
            DanhSachTheLoai.DataSource = TheLoai2.GetTheLoai();
        }
        void ThemDanhSachTheLoaidgv()
        {
            txtMaTheLoai.DataBindings.Add("Text", dgvTheLoai.DataSource, "Mã Thể Loại", true, DataSourceUpdateMode.Never);
            txtTenTheLoai.DataBindings.Add("Text", dgvTheLoai.DataSource, "Tên Thể Loại", true, DataSourceUpdateMode.Never);
        }
        void ThemTheLoai(string id,string name)
        {
            if (TheLoai2.ThemTheLoai(id, name))
            {
                MessageBox.Show("Thêm Thể Loại Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Thể Loại Thât Bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaTheLoai.Text;
            string name = txtTenTheLoai.Text;

            // Kiểm tra nếu bất kỳ TextBox nào trống
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra nếu mã thể loại đã tồn tại trong DataGridView
            foreach (DataGridViewRow row in dgvTheLoai.Rows)
            {
                if (row.Cells["Mã Thể Loại"].Value != null && row.Cells["Mã Thể Loại"].Value.ToString() == id)
                {
                    MessageBox.Show("Mã thể loại đã tồn tại.");
                    return;
                }
            }

            // Thêm thể loại mới
            ThemTheLoai(id, name);
            LoadDanhSachTheLoai();
        }
        void UpdateTheLoai(string id,string name)
        {
            if (TheLoai2.CapNhatTheLoai(id, name))
            {
                MessageBox.Show("Cập Nhật Thành Công");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaTheLoai.Text;
            string name=txtTenTheLoai.Text;
            UpdateTheLoai(id, name);
            LoadDanhSachTheLoai();
        }
        void XoaTheLoai(string id)
        {
            if (TheLoai2.XoaTheLoai(id))
            {
                MessageBox.Show("Xóa Thành Công ");
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id=txtMaTheLoai.Text;
            XoaTheLoai(id);
            LoadDanhSachTheLoai();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)//Làm Trống Text box
        {
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
        }
    }
}
