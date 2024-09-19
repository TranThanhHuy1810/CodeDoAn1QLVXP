using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DACS1
{
    public partial class NhanVien : Form
    {
        BindingSource ListNhanVien=new BindingSource();
        public NhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
        }   
        void LoadNhanVien() {
            dgv.DataSource = ListNhanVien;
            LoadListNhanVien();
            LoadDgvBindingNhanVien();
        }
        void LoadListNhanVien()
        {
            ListNhanVien.DataSource = NhanVien2.GetListStaff();
        }
       void LoadDgvBindingNhanVien()
        {
            txtMaNV.DataBindings.Add("Text", dgv.DataSource, "Mã Nhân Viên", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add("Text",dgv.DataSource,"Họ Tên",true,DataSourceUpdateMode.Never);
            dateTimePicker1.DataBindings.Add("value", dgv.DataSource, "Ngày Sinh", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", dgv.DataSource, "Địa Chỉ", true, DataSourceUpdateMode.Never);
        }
        void ThemNhanVien(string id,string hoten,DateTime NgaySinh,string DiaChi)
        {
            if(NhanVien2.InsertStaff(id, hoten,NgaySinh, DiaChi)) {
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;   
            string HoTen=txtHoTen.Text;
            DateTime NgaySinh = dateTimePicker1.Value;
            string DiaChi=txtDiaChi.Text;
            if (string.IsNullOrWhiteSpace(id) ||
               string.IsNullOrWhiteSpace(HoTen) ||
               string.IsNullOrWhiteSpace(DiaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Mã Nhân Viên"].Value != null && row.Cells["Mã Nhân Viên"].Value.ToString() == id)
                {
                    MessageBox.Show("Mã phim đã tồn tại.");
                    return;
                }
            }
            ThemNhanVien(id, HoTen, NgaySinh, DiaChi);
            LoadListNhanVien();

        }
        void xoanhanvien(string id)
        {
            if (NhanVien2.DeleteStaff(id)){
                MessageBox.Show("Xóa Thành Công");
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            xoanhanvien(id);
            LoadListNhanVien();
        }
    }
}
