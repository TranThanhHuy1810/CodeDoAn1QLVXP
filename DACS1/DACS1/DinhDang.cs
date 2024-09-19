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
    public partial class DinhDang : Form
    {
        BindingSource DanhSachDinhDang = new BindingSource();
        public DinhDang()
        {
            InitializeComponent();
            LoadDinhDangPhim();
        }
        void LoadDinhDangPhim()
        {
            dgvDinhDangPhim.DataSource=DanhSachDinhDang;
            LoadDanhSachDinhDangPhim();
            LoadCbMaPhim(cbMaPhim);
            LoadCbMaMh(cbMaManHinh);
            ThemDinhDangdgv();
        }
        void LoadCbMaPhim(ComboBox cb) {
            cb.DataSource = Phim2.GetListMovie();
            cb.DisplayMember = "ID";
            cb.ValueMember = "ID";
        }
        void LoadCbMaMh(ComboBox cb) {
            cb.DataSource = LoaiManHinh2.GetListScreenType();
            cb.DisplayMember="ID";
            cb.ValueMember = "ID";  
        }
      void LoadDanhSachDinhDangPhim()
        {
            DanhSachDinhDang.DataSource=DinhDangPhim2.GetListFormatMovie();
        }
        void ThemDinhDangdgv()
        {
            txtMaDinhDang.DataBindings.Add("Text", dgvDinhDangPhim.DataSource, "Mã Định Dạng", true, DataSourceUpdateMode.Never);
        }

        private void cbMaPhim_SelectedValueChanged(object sender, EventArgs e)
        {
            Phim1 phim1=cbMaPhim.SelectedItem as Phim1;
            txtTenPhim.Text= phim1.Name;
        }

        private void cbMaManHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiManHinh1 loaiManHinh1=cbMaManHinh.SelectedItem as LoaiManHinh1;
            txtTenManHinh.Text= loaiManHinh1.Name;
        }

        private void txtMaDinhDang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Ensure there are selected cells before proceeding
                if (dgvDinhDangPhim.SelectedCells.Count == 0)
                {
                    return;
                }

                var selectedCell = dgvDinhDangPhim.SelectedCells[0];
                var owningRow = selectedCell.OwningRow;

                // Ensure the owning row is not null and the necessary cells exist
                if (owningRow == null)
                {
                    return;
                }

                // Ensure the cells are present by checking the column names
                string colMovieID = "Mã Phim"; // Replace with the correct column name if different
                string colScreenName = "Tên MH"; // Replace with the correct column name if different

                if (!owningRow.DataGridView.Columns.Contains(colMovieID) ||
                    !owningRow.DataGridView.Columns.Contains(colScreenName))
                {
                    MessageBox.Show($"Column names '{colMovieID}' or '{colScreenName}' not found.");
                    return;
                }

                // Safely retrieve the movie ID
                object movieIDValue = owningRow.Cells[colMovieID].Value;
                if (movieIDValue == null)
                {
                    return;
                }
                string movieID = movieIDValue.ToString();

                Phim1 movieSelecting = Phim2.GetMovieByID(movieID);
                if (movieSelecting == null)
                {
                    return;
                }

                int indexMovie = -1;
                int iMovie = 0;
                foreach (Phim1 item in cbMaPhim.Items)
                {
                    if (item.Name == movieSelecting.Name)
                    {
                        indexMovie = iMovie;
                        break;
                    }
                    iMovie++;
                }
                cbMaPhim.SelectedIndex = indexMovie;

                // Safely retrieve the screen name
                object screenNameValue = owningRow.Cells[colScreenName].Value;
                if (screenNameValue == null)
                {
                    return;
                }
                string screenName = screenNameValue.ToString();

                LoaiManHinh1 screenTypeSelecting = LoaiManHinh2.GetScreenTypeByName(screenName);
                if (screenTypeSelecting == null)
                {
                    return;
                }

                int indexScreen = -1;
                int iScreen = 0;
                foreach (LoaiManHinh1 item in cbMaManHinh.Items)
                {
                    if (item.Name == screenTypeSelecting.Name)
                    {
                        indexScreen = iScreen;
                        break;
                    }
                    iScreen++;
                }
                cbMaManHinh.SelectedIndex = indexScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        void ThemDinhDang(string id,string idPhim,string idMH)
        {
            if(DinhDangPhim2.ThemDinhDangPhim(id,idPhim,idMH))
            {
                MessageBox.Show("Thêm Thành Định Dạng Thành Công ");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các trường nhập liệu
            string id = txtMaDinhDang.Text;
            string idPhim = cbMaPhim.SelectedValue != null ? cbMaPhim.SelectedValue.ToString() : string.Empty;
            string idMH = cbMaManHinh.SelectedValue != null ? cbMaManHinh.SelectedValue.ToString() : string.Empty;

            // Kiểm tra nếu bất kỳ trường nào trống
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(idPhim) || string.IsNullOrWhiteSpace(idMH))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra nếu mã định dạng đã tồn tại trong DataGridView
            foreach (DataGridViewRow row in dgvDinhDangPhim.Rows)
            {
                if (row.Cells["Mã Định Dạng"].Value != null && row.Cells["Mã Định Dạng"].Value.ToString() == id)
                {
                    MessageBox.Show("Mã định dạng đã tồn tại.");
                    return;
                }
            }

            // Thêm định dạng mới
            ThemDinhDang(id, idPhim, idMH);
            LoadDanhSachDinhDangPhim();
        }
        void XoaDinhDang(string id)
        {
            if (DinhDangPhim2.XoaDinhDang(id))
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
            string id = txtMaDinhDang.Text;
            XoaDinhDang(id);
            LoadDanhSachDinhDangPhim();
        }
        void CapNhatDinhDang(string id,string idPhim,string idMH)
        {
            if(DinhDangPhim2.CapNhatDinhDang(id, idPhim, idMH))
            {
                MessageBox.Show("Sửa Thành Công");
            }
            else
            {
                MessageBox.Show("Sữa Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaDinhDang.Text;
            string idPhim=cbMaPhim.SelectedValue.ToString();
            string idMH=cbMaManHinh.SelectedValue.ToString();
            CapNhatDinhDang(id,idPhim,idMH);
            LoadDanhSachDinhDangPhim();
        }
    }
}
