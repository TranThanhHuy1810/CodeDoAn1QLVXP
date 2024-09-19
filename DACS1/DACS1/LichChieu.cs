using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1
{
    public partial class LichChieu : Form
    {
        BindingSource DanhSachLichChieu = new BindingSource();
        public LichChieu()
        {
            InitializeComponent();
            LoadLichChieu();
        }
        void LoadLichChieu()
        {
            dgvLichChieu.DataSource = DanhSachLichChieu;
            LoadDanhSachLichChieu();
            LoadCbDinHDangPhim();
            LoadDgvLichChieu();
        }
        void LoadDanhSachLichChieu()
        {
            DanhSachLichChieu.DataSource = LichChieu2.GetListShowtime();
        }
        void LoadDgvLichChieu()//Load databinding
        {
            txtMaLichChieu.DataBindings.Add("Text", dgvLichChieu.DataSource, "Mã Lịch Chiếu", true, DataSourceUpdateMode.Never);
            dtpNgayChieu.DataBindings.Add("Value", dgvLichChieu.DataSource, "Thời Gian Chiếu", true, DataSourceUpdateMode.Never);
            dtpGioChieu.DataBindings.Add("Value", dgvLichChieu.DataSource, "Thời Gian Chiếu", true, DataSourceUpdateMode.Never);
            txtGiaVe.DataBindings.Add("Text", dgvLichChieu.DataSource, "Giá Vé", true, DataSourceUpdateMode.Never);
        }
        void LoadCbDinHDangPhim()
        {
            cbDinhDang.DataSource = DinhDangPhim2.GetFormatMovie();
            cbDinhDang.DisplayMember = "ID";
        }

        private void cbDinhDang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDinhDang.SelectedIndex != -1)
            {
                DinhDangPhim1 formatMovieSelecting = (DinhDangPhim1)cbDinhDang.SelectedItem;
                txtPhim.Text = formatMovieSelecting.TenPhim;
                txtManHinh.Text = formatMovieSelecting.TenManHinh;
                cbPhongChieu.DataSource = null;
                LoaiManHinh1 screenType = LoaiManHinh2.GetScreenTypeByName(formatMovieSelecting.TenManHinh);
                cbPhongChieu.DataSource = PhongChieu2.GetCinemaByScreenTypeID(screenType.ID);
                cbPhongChieu.DisplayMember = "Name";
            }
        }
        void ThemLichChieu(string id, string IdPhong, string idDinhDang, DateTime time, float GiaVe)
        {
            if (LichChieu2.ThemLichChieu(id, IdPhong, idDinhDang, time, GiaVe))
            {
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaLichChieu.Text;
            string idPhong = ((PhongChieu1)cbPhongChieu.SelectedItem).ID;
            string idDinhDang = ((DinhDangPhim1)cbDinhDang.SelectedItem).ID;
            DateTime time = new DateTime(dtpNgayChieu.Value.Year, dtpNgayChieu.Value.Month, dtpNgayChieu.Value.Day, dtpGioChieu.Value.Hour, dtpGioChieu.Value.Minute, dtpGioChieu.Value.Second);
            float giaVe;
            if (!float.TryParse(txtGiaVe.Text, out giaVe))//txtGia Ve rong 
            {
                MessageBox.Show("Giá vé không hợp lệ.");
                return;
            }

            // Kiểm tra cac textbox co rong khong
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(idPhong) || string.IsNullOrWhiteSpace(idDinhDang))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra nếu mã lịch chiếu đã tồn tại trong DataGridView
            foreach (DataGridViewRow row in dgvLichChieu.Rows)
            {
                if (row.Cells["Mã Lịch Chiếu"].Value != null && row.Cells["Mã Lịch Chiếu"].Value.ToString() == id)
                {
                    MessageBox.Show("Mã lịch chiếu đã tồn tại.");
                    return;
                }
            }

            ThemLichChieu(id, idPhong, idDinhDang, time, giaVe);
            LoadDanhSachLichChieu();
        }
        void XoaLichChieu(string id)
        {
            if (LichChieu2.XoaLichChieu(id))
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

            string id = txtMaLichChieu.Text;
            XoaLichChieu(id);
            LoadDanhSachLichChieu();
        }
        void CapNhatLichChieu(string id, string IdPhong, string idDinhDang, DateTime time, float GiaVe)
        {
            if (LichChieu2.CapNhatLichChieu(id, IdPhong, idDinhDang, time, GiaVe))
            {
                MessageBox.Show("Sữa Thành Công ");
            }
            else
            {
                MessageBox.Show("Sữa Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaLichChieu.Text;
            string IdPhong = ((PhongChieu1)cbPhongChieu.SelectedItem).ID;
            string idDinhDang = ((DinhDangPhim1)cbDinhDang.SelectedItem).ID;
            DateTime time = new DateTime(dtpNgayChieu.Value.Year, dtpNgayChieu.Value.Month, dtpNgayChieu.Value.Day, dtpGioChieu.Value.Hour, dtpGioChieu.Value.Minute, dtpGioChieu.Value.Second);
            float GiaVe = float.Parse(txtGiaVe.Text);
            CapNhatLichChieu(id, IdPhong, idDinhDang, time, GiaVe);
            LoadDanhSachLichChieu();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaLichChieu.Clear();
            txtGiaVe.Clear();
            dtpGioChieu.Value = DateTime.Now;
            dtpNgayChieu.Value = DateTime.Now;
        }

        private void txtMaLichChieu_TextChanged(object sender, EventArgs e)
        {
            #region Databinding dgvLichChieu hien thi textBox va Cb
            if (dgvLichChieu.SelectedCells.Count > 0 && dgvLichChieu.SelectedCells[0].OwningRow != null)
            {
                try
                {
                    string movieName = (string)dgvLichChieu.SelectedCells[0].OwningRow.Cells["Tên phim"].Value;
                    string screenTypeName = (string)dgvLichChieu.SelectedCells[0].OwningRow.Cells["Màn hình"].Value;
                    DinhDangPhim1 formatMovieSelecting = DinhDangPhim2.GetFormatMovieByName(movieName, screenTypeName);
                    if (formatMovieSelecting == null)
                        return;
                    int indexFormatMovie = -1;
                    for (int i = 0; i < cbDinhDang.Items.Count; i++)
                    {
                        DinhDangPhim1 item = cbDinhDang.Items[i] as DinhDangPhim1;
                        if (item.ID == formatMovieSelecting.ID)
                        {
                            indexFormatMovie = i;
                            break;
                        }
                    }
                    cbDinhDang.SelectedIndex = indexFormatMovie;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region Databinding dgvLichChieu hien thi textBox va Cb
            if (dgvLichChieu.SelectedCells.Count > 0 && dgvLichChieu.SelectedCells[0].OwningRow != null)
            {
                try
                {
                    string cinemaID = (string)dgvLichChieu.SelectedCells[0].OwningRow.Cells["Mã phòng"].Value;
                    PhongChieu1 cinemaSelecting = PhongChieu2.GetMaPhongChieu(cinemaID);
                    if (cinemaSelecting == null)
                        return;

                    int indexCinema = -1;
                    int iCinema = 0;
                    foreach (PhongChieu1 item in cbPhongChieu.Items)
                    {
                        if (item.ID == cinemaSelecting.ID)
                        {
                            indexCinema = iCinema;
                            break;
                        }
                        iCinema++;
                    }
                    cbPhongChieu.SelectedIndex = indexCinema;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
        }
    }
}
