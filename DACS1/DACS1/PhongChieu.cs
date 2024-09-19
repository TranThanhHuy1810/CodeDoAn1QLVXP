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
    public partial class PhongChieu : Form
    {
        BindingSource DanhSachPhongChieu = new BindingSource();
        public PhongChieu()
        {
            InitializeComponent();
            LoadPhongChieu();
        }
        void LoadPhongChieu()
        {
            dgvPhongChieu.DataSource=DanhSachPhongChieu;
            LoadDanhSachPhongChieu();
            ThemPhongChieuDgv();
        }
        void LoadDanhSachPhongChieu()
        {
            DanhSachPhongChieu.DataSource = PhongChieu2.GetDanhSachPhongChieu();
        }
        void ThemPhongChieuDgv()
        {
            txtMaPhongChieu.DataBindings.Add("Text", dgvPhongChieu.DataSource, "Mã Phòng", true, DataSourceUpdateMode.Never);
            txtTenPhongChieu.DataBindings.Add("Text", dgvPhongChieu.DataSource, "Tên Phòng", true, DataSourceUpdateMode.Never);
            txtChoNgoi.DataBindings.Add("Text", dgvPhongChieu.DataSource, "Số Chỗ Ngồi", true, DataSourceUpdateMode.Never);
            txtTinhTrang.DataBindings.Add("Text", dgvPhongChieu.DataSource, "Tình Trạng", true, DataSourceUpdateMode.Never);
            txtSoHangGhe.DataBindings.Add("Text", dgvPhongChieu.DataSource, "Số Hàng Ghế", true, DataSourceUpdateMode.Never);
            txtSeatInRow.DataBindings.Add("Text", dgvPhongChieu.DataSource, "Ghế Mỗi Hàng", true, DataSourceUpdateMode.Never);
            LoadCbManHinh(cbManHinh);   
        }
        void LoadCbManHinh(ComboBox cb)
        {
            cb.DataSource = LoaiManHinh2.GetListScreenType();
            cb.DisplayMember="Name";
            cb.ValueMember="ID";
        }

        private void txtMaPhongChieu_TextChanged(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedCells.Count > 0)
            {
                string screenName = (string)dgvPhongChieu.SelectedCells[0].OwningRow.Cells["Tên màn hình"].Value;
                LoaiManHinh1 screenType = LoaiManHinh2.GetScreenTypeByName(screenName);

                if (screenType != null)
                {
                    cbManHinh.SelectedItem = screenType;

                    int index = -1;
                    int i = 0;
                    foreach (LoaiManHinh1 item in cbManHinh.Items)
                    {
                        if (item.Name == screenType.Name)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbManHinh.SelectedIndex = index;
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy loại màn hình
                }
            }
        }
        void ThemPhongChieu(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            if(PhongChieu2.ThemPhongChieu(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
            {
                MessageBox.Show("Thêm Phòng Chiếu Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaPhongChieu.Text;
            string name = txtTenPhongChieu.Text;
            string LMH = cbManHinh.SelectedValue.ToString();
            int Seats, TrangThai, numberofrow, seatInRow;

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(LMH) || string.IsNullOrWhiteSpace(txtChoNgoi.Text) ||
                string.IsNullOrWhiteSpace(txtTinhTrang.Text) || string.IsNullOrWhiteSpace(txtSoHangGhe.Text) ||
                string.IsNullOrWhiteSpace(txtSeatInRow.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            // Try parsing integer fields and handle invalid input
            if (!int.TryParse(txtChoNgoi.Text, out Seats) || !int.TryParse(txtTinhTrang.Text, out TrangThai) ||
                !int.TryParse(txtSoHangGhe.Text, out numberofrow) || !int.TryParse(txtSeatInRow.Text, out seatInRow))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho các trường số");
                return;
            }

            // Check if the ID already exists
            if (IsIdExists(id))
            {
                MessageBox.Show("Mã Phòng Chiếu đã tồn tại, không thể thêm mới.");
            }
            else
            {
                ThemPhongChieu(id, name, LMH, Seats, TrangThai, numberofrow, seatInRow);
                LoadDanhSachPhongChieu();
            }
        }
        private bool IsIdExists(string id)
        {
            foreach (DataGridViewRow row in dgvPhongChieu.Rows)
            {
                if (row.Cells["Mã Phòng"].Value != null && row.Cells["Mã Phòng"].Value.ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }
        void CapNhatPhongChieu(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            if(PhongChieu2.CapNhatPhongChieu(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
            {
                MessageBox.Show("Sửa Phòng Chiếu Thành Công");
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaPhongChieu.Text;
            string name = txtTenPhongChieu.Text;
            string LMH = cbManHinh.SelectedValue.ToString();
            int Seats = int.Parse(txtChoNgoi.Text);
            int TrangThai = int.Parse(txtTinhTrang.Text);
            int numberofrow = int.Parse(txtSoHangGhe.Text);
            int seatInRow = int.Parse(txtSeatInRow.Text);
            CapNhatPhongChieu(id,name,LMH,Seats, TrangThai, numberofrow, seatInRow);
            LoadDanhSachPhongChieu();   
        }
        void XoaPhongChieu(string id)
        {
            if (PhongChieu2.XoaPhongChieu(id))
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
            string id = txtMaPhongChieu.Text;
            XoaPhongChieu(id);
            LoadDanhSachPhongChieu();
        }
    }
}
