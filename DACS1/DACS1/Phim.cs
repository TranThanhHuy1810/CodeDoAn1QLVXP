using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1
{
    public partial class Phim : Form
    {
        BindingSource DanhSachPhim = new BindingSource();
        public Phim()
        {
            InitializeComponent();
            LoadPhim();
            LoaddgvPhim();
        }
        void LoadPhim()
        {
            dgvPhim.DataSource=DanhSachPhim;
           LoadDanhSachPhim();
        }
        void LoadDanhSachPhim()
        {
            DanhSachPhim.DataSource = Phim2.GetMovie();

        }
        void LoaddgvPhim()//Sử dụng databindings để click hiển thị ra text box và checkboxTheLoai
        {
            txtMaPhim.DataBindings.Add("Text", dgvPhim.DataSource, "Mã Phim", true, DataSourceUpdateMode.Never);
            txtTenPhim.DataBindings.Add("Text",dgvPhim.DataSource,"Tên Phim",true, DataSourceUpdateMode.Never);
            txtThoiLuong.DataBindings.Add("text", dgvPhim.DataSource, "Thời Lượng", true, DataSourceUpdateMode.Never);
            dptNgayKhoiChieu.DataBindings.Add("Value", dgvPhim.DataSource, "Ngày Khởi Chiếu", true, DataSourceUpdateMode.Never);
            dptNgayKetThuc.DataBindings.Add("Value", dgvPhim.DataSource, "Ngày Kết Thúc", true, DataSourceUpdateMode.Never);
            txtSanXuat.DataBindings.Add("Text", dgvPhim.DataSource, "Sản Xuất", true, DataSourceUpdateMode.Never);
            txtDaoDien.DataBindings.Add("Text",dgvPhim.DataSource,"Đạo Diễn",true,DataSourceUpdateMode.Never);
            txtNamSanXuat.DataBindings.Add("Text", dgvPhim.DataSource, "Năm SX", true, DataSourceUpdateMode.Never);
            DataGridViewImageColumn imageColumn = dgvPhim.Columns["Ảnh"] as DataGridViewImageColumn;//Chỉnh Kích Thước của ảnh dgv 
            if (imageColumn != null)
            {
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

            dgvPhim.CellFormatting += DgvPhim_CellFormatting;
            LoadclbTheLoaiPhim(clbTheLoai);
        }

        private void DgvPhim_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhim.Columns[e.ColumnIndex].Name == "Ảnh")
            {
                byte[] imageBytes = e.Value as byte[];
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        e.Value = Image.FromStream(ms);
                    }
                }
            }
        }

        void LoadclbTheLoaiPhim(CheckedListBox clb)//Load checklistbox 
        {
            List<TheLoai1> genreList = TheLoai2.GetListGenre();
            clb.DataSource = genreList;
            clb.DisplayMember = "Name";
        }

        private void txtMaPhim_TextChanged(object sender, EventArgs e)
        {   //Sử dụng để ràng buộc Thể loại Phim và hình ảnh của Phim đã được CheckedListBox
            picAnh.Image = null;
            for (int i = 0; i < clbTheLoai.Items.Count; i++)
            {
                clbTheLoai.SetItemChecked(i, false);  //Bỏ Chọn clbTheLoai
              
            }

            List<TheLoai1> listGenreOfMovie = PhanLoaiPhim2.GetListGenreByMovieID(txtMaPhim.Text);
            for (int i = 0; i < clbTheLoai.Items.Count; i++)
            {
                TheLoai1 genre = (TheLoai1)clbTheLoai.Items[i];
                foreach (TheLoai1 item in listGenreOfMovie)
                {
                    if (genre.ID == item.ID)
                    {
                        clbTheLoai.SetItemChecked(i, true);
                        break;
                    }
                }
            }
            Phim1 movie = Phim2.GetMovieByID(txtMaPhim.Text);
            if (movie == null)
                return;
            if (movie.Anh != null)
                picAnh.Image = Phim2.byteArrayToImage(movie.Anh);
        }
        void ThemPhim(string id, string name, float ThoiLuong, DateTime NBD, DateTime NKT, string sx, string DaoDien, int Nam, byte[] image)
        {
            if(Phim2.ThemPhim(id,name,ThoiLuong,NBD,NKT,sx,DaoDien,Nam,image))
            {
                MessageBox.Show("Thêm Phim Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Phim Thất Bại");
            }
        }
        void ThemPhanLoaiPhim(string MaPhim, CheckedListBox checkedListBox)//Them idPhim vs idTheLoai Vào Bảng Phân Loại Phim
        {
            List<TheLoai1> theLoai1s = new List<TheLoai1>();
            foreach(TheLoai1 Item in checkedListBox.CheckedItems)
            {
                theLoai1s.Add(Item);
            }
            PhanLoaiPhim2.ThemPhanLoaiPhim(MaPhim, theLoai1s);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaPhim.Text;
            string name = txtTenPhim.Text;
            string thoiLuong = txtThoiLuong.Text;
            DateTime NBD = dptNgayKhoiChieu.Value;
            DateTime NKT = dptNgayKetThuc.Value;
            string SX = txtSanXuat.Text;
            string DaoDien = txtDaoDien.Text;
            string namSanXuat = txtNamSanXuat.Text;

            // Kiểm tra nếu bất kỳ TextBox nào trống
            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(thoiLuong) ||
                string.IsNullOrWhiteSpace(SX) ||
                string.IsNullOrWhiteSpace(DaoDien) ||
                string.IsNullOrWhiteSpace(namSanXuat))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra nếu hình ảnh chưa được thêm
            if (picAnh.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước.");
                return;
            }

            // Kiểm tra nếu mã phim đã tồn tại trong DataGridView
            foreach (DataGridViewRow row in dgvPhim.Rows)
            {
                if (row.Cells["Mã Phim"].Value != null && row.Cells["Mã Phim"].Value.ToString() == id)
                {
                    MessageBox.Show("Mã phim đã tồn tại.");
                    return;
                }
            }

            // Chuyển đổi Thời Lượng và Năm Sản Xuất sang dạng số
            if (!float.TryParse(thoiLuong, out float TL))
            {
                MessageBox.Show("Thời lượng phải là một số.");
                return;
            }

            if (!int.TryParse(namSanXuat, out int NamSX))
            {
                MessageBox.Show("Năm sản xuất phải là một số nguyên.");
                return;
            }

            // Thêm phim mới và phân loại phim
            ThemPhim(id, name, TL, NBD, NKT, SX, DaoDien, NamSX, Phim2.imageToByteArray(picAnh.Image));
            ThemPhanLoaiPhim(id, clbTheLoai);
            LoadDanhSachPhim();
        }
        void CapNhatPhim(string id, string name, float ThoiLuong, DateTime NBD, DateTime NKT, string sx, string DaoDien, int Nam, byte[] image)
        {
            if(Phim2.CapNhatPhim(id,name,ThoiLuong,NBD,NKT,sx,DaoDien, Nam,image))
            {
                MessageBox.Show("Cập Nhật Phim Thành Công");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại");
            }
        }
        void CapNhatPhanLoaiPhim(string MaPhim,CheckedListBox checkedListBox)
        {
            List<TheLoai1> theLoai1s = new List<TheLoai1>();
            foreach (TheLoai1 Item in checkedListBox.CheckedItems)
            {
                theLoai1s.Add(Item);
            }
            PhanLoaiPhim2.CapNhatPhanLoaiPhim(MaPhim, theLoai1s);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaPhim.Text;
            string name = txtTenPhim.Text;
            float TL = float.Parse(txtThoiLuong.Text);
            DateTime NBD = dptNgayKhoiChieu.Value;
            DateTime NKT = dptNgayKetThuc.Value;
            string SX = txtSanXuat.Text;
            string DaoDien = txtDaoDien.Text;
            int NamSX = int.Parse(txtNamSanXuat.Text);
            if (picAnh.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }
            CapNhatPhim(id,name, TL, NBD, NKT,SX, DaoDien,NamSX,Phim2.imageToByteArray(picAnh.Image));
            CapNhatPhanLoaiPhim(id, clbTheLoai);
            LoadDanhSachPhim();
        }
        void XoaPhim(string id)
        {
            if(Phim2.XoaPhim(id)) {

                MessageBox.Show("Xóa Phim Thành Công");

            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaPhim.Text;
            XoaPhim(id);
            LoadDanhSachPhim();
        }

        private void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathImage = null;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePathImage = openFile.FileName;
                    picAnh.Image = Image.FromFile(filePathImage.ToString());
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void btnTaoMoi_Click(object sender, EventArgs e)//Tạo Mới Các Textbox để thêm phim
        {
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtThoiLuong.Clear();
            txtSanXuat.Clear();
            txtDaoDien.Clear();
            txtNamSanXuat.Clear();
            dptNgayKhoiChieu.Value = DateTime.Now;
            dptNgayKetThuc.Value = DateTime.Now;
            picAnh.Image = null;
            for (int i = 0; i < clbTheLoai.Items.Count; i++)
            {
                clbTheLoai.SetItemChecked(i, false);
            }

        }
    }
}
