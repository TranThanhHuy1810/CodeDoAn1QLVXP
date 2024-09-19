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
    public partial class KhachHang : Form
    {   BindingSource DanhSachKhachHang=new BindingSource();
        public KhachHang()
        {
            InitializeComponent();
            LoadKhachHang();
        }
        void LoadKhachHang()
        {
            dgvKhachHang.DataSource=DanhSachKhachHang;
            LoadDanhSachKhachHang();
            LoaddgvKhachHang();//bindingKhachHang
        }
        void LoadDanhSachKhachHang()
        {
            DanhSachKhachHang.DataSource = KhachHang2.LayDanhSachSach();
        }
       void LoaddgvKhachHang()
        {
            txtMaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "Mã Khách Hàng", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "Họ Tên", true, DataSourceUpdateMode.Never);
            numericUpDown1.DataBindings.Add("Value", dgvKhachHang.DataSource, "Điểm Tích Lũy", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("Text",dgvKhachHang.DataSource,"SĐT",true,DataSourceUpdateMode.Never);
        }
        void ThemKhachKhang(string id,string HoTen,int SDT)
        {
            if(KhachHang2.ThemKhachHang(id, HoTen, SDT))
            {
                MessageBox.Show("Thêm Khách Hàng Thành Công!");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaKhachHang.Text.Trim();
            string HoTen = txtTenKhachHang.Text.Trim();
            string sdtStr = txtSDT.Text.Trim();

            // Kiểm tra xem các trường thông tin có rỗng không
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(HoTen) || string.IsNullOrEmpty(sdtStr))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin của khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sdt;
            // Kiểm tra xem số điện thoại có đúng định dạng không
            if (!int.TryParse(sdtStr, out sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem mã khách hàng đã tồn tại trong danh sách chưa
            if (dgvKhachHang != null && dgvKhachHang.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvKhachHang.Rows)
                {
                    if (row.Cells["Mã Khách Hàng"].Value != null && row.Cells["Mã Khách Hàng"].Value.ToString() == id)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng chọn mã khách hàng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Nếu không có trường hợp nào trên, thêm khách hàng vào danh sách
            ThemKhachKhang(id, HoTen, sdt);
            LoadDanhSachKhachHang();
        }
        void CapNhatKhachHang(string id, string HoTen,int SDT,int DiemTichLuy)
        {
            if (KhachHang2.CapNhatKhachHang(id, HoTen, SDT, DiemTichLuy))
            {
                MessageBox.Show("Sửa Thành Công ");
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaKhachHang.Text;
            string HoTen = txtTenKhachHang.Text;
            int sdt = int.Parse(txtSDT.Text);
            int DiemTichLuy = (int)numericUpDown1.Value;
            CapNhatKhachHang(id,HoTen, sdt,DiemTichLuy);
            LoadDanhSachKhachHang();
        }
        void XoaKhachHang(string id)
        {
            if (KhachHang2.XoaKhachHang(id))
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
            string id=txtMaKhachHang.Text;
            XoaKhachHang(id);
            LoadDanhSachKhachHang() ;   
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSDT.Clear();
        }
    }
}
