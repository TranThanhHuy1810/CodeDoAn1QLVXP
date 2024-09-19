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
    public partial class LoaiManHinh : Form
    {
        BindingSource DanhSachManHinh = new BindingSource();
        public LoaiManHinh()
        {
            InitializeComponent();
            LoadLoaiManHinh();
        }
        void LoadLoaiManHinh()
        {
            dgvLoaiManHinh.DataSource=DanhSachManHinh;
            LoadDanhSachManHinh();
            ThemDanhSachDgv();
        }
        void LoadDanhSachManHinh()
        {
            DanhSachManHinh.DataSource=LoaiManHinh2.GetScreenType();
        }
        void ThemDanhSachDgv()
        {
            txtLoaiManHinh.DataBindings.Add("Text", dgvLoaiManHinh.DataSource, "Mã Loại Màn Hình", true, DataSourceUpdateMode.Never);
            txtTenManHinh.DataBindings.Add("Text", dgvLoaiManHinh.DataSource, "Tên Màn Hình", true, DataSourceUpdateMode.Never);
        }
        void NhapLoaiManHinh(string id,string name)
        {
            if (LoaiManHinh2.ThemLoaiManHinh(id, name))
            {
                MessageBox.Show("Thêm loại màn hình thành công");
            }
            else
            {
                MessageBox.Show("Thêm loại màn hình thất bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtLoaiManHinh.Text;
            string name = txtTenManHinh.Text;

            
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            // Kiểm Tra idManHinh
            if (IsIdExists(id))
            {
                MessageBox.Show("Mã Loại Màn hình đã tồn tại, không thể thêm mới.");
            }
            else
            {
                NhapLoaiManHinh(id, name);
                LoadDanhSachManHinh();
            }
        }
        private bool IsIdExists(string id)//Hàm Kiểm Tra Nếu Có IdManHinh trong dgv thì không thêm được
        {
            foreach (DataGridViewRow row in dgvLoaiManHinh.Rows)
            {
                if (row.Cells["Mã Loại Màn Hình"].Value != null && row.Cells["Mã Loại Màn Hình"].Value.ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }
        void CapNhaLoaiManHinh(string id,string name)
        {
            if (LoaiManHinh2.CapNhatLoaiManHinh(id, name))
            {
                MessageBox.Show("Cập nhật màn hình thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật màn hình thất bại");
            }
        }
        

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtLoaiManHinh.Text;
            string name=txtTenManHinh.Text;
            CapNhaLoaiManHinh(id, name);
            LoadDanhSachManHinh() ; 
        }
        void XoaManHinh(string id)
        {
            if (LoaiManHinh2.XoaLoaiManHinh(id))
            {
                MessageBox.Show("Xoá Màn Hình Thành Công");
            }
            else
            {
                MessageBox.Show("Xóa Màn Hình Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id=txtLoaiManHinh.Text;
            XoaManHinh(id);
            LoadDanhSachManHinh();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)// Làm Trống TextBox
        {
            txtLoaiManHinh.Clear();
            txtTenManHinh.Clear();
        }
    }
}
