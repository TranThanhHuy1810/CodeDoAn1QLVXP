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
    public partial class Ve : Form
    {
        public Ve()
        {
            InitializeComponent();
            LoadDanhSachLichChieu();
        }
        void LoadDanhSachLichChieu()
        {
            lvLichChieu.Items.Clear();
            List<LichChieu1> lichChieu1s = LichChieu2.GetAllListShowTimes();
            foreach (LichChieu1 lichChieu1 in lichChieu1s)
            {
                ListViewItem lv = new ListViewItem(lichChieu1.TenPhongChieu);
                lv.SubItems.Add(lichChieu1.TenPhim);
                lv.SubItems.Add(lichChieu1.Time.ToString("HH:mm:ss dd/MM/yyyy")); 
                if (lichChieu1.TrangThai == 1)
                {
                    lv.SubItems.Add("Đã Tạo");
                }
                else
                {
                    lv.SubItems.Add("Chưa Tạo");
                }
                lv.Tag = lichChieu1; 
                lvLichChieu.Items.Add(lv);
            }

        }
        void LoadVeTheoLichChieu(string IdLichChieu)
        {
            List<Ve1> ve1s = Ve2.GetListTicketsByShowTimes(IdLichChieu);
            dgvVe.DataSource = ve1s;
        }
        void LoadMuaVeTheoLichChieu(string IdLichChieu)
        {
            List<Ve1> ve1s = Ve2.GetListTicketsBoughtByShowTimes(IdLichChieu);
            dgvVe.DataSource = ve1s;
        }
        void AutoCreatTicket(LichChieu1 lichChieu1)
        {
            int result = 0;
            PhongChieu1 phongChieu1 = PhongChieu2.GetTenPhongChieu(lichChieu1.TenPhongChieu);
            int Row = phongChieu1.Row;
            int Column = phongChieu1.SeatInRow;
            for (int i = 0; i < Row; i++)
            {
                int temp = i + 65;
                char nameRow = (char)temp;
                for (int j = 0; j < Column; j++) // sửa điều kiện vòng lặp thành j < Column
                {
                    string seatName = nameRow.ToString() + j;
                    result += Ve2.ThemVe(lichChieu1.ID, seatName);
                }
            }
            if (result == Row * Column)
            {
                int ret = LichChieu2.CapNhatTrangThaiLichChieu(lichChieu1.ID, 1);
                if (ret > 0)
                    MessageBox.Show("Tạo Vé Tự Động Thành Công!", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Tạo Vé Tự Động Thất Bại!", "Thông Báo");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                LichChieu1 lichChieu1 = lvLichChieu.SelectedItems[0].Tag as LichChieu1;
                if (lichChieu1.TrangThai == 1)
                {
                    MessageBox.Show("LỊCH CHIẾU NÀY ĐÃ ĐƯỢC TẠO VÉ!!!", "THÔNG BÁO");
                    return;
                }
                AutoCreatTicket(lichChieu1);
                LoadDanhSachLichChieu();
                LoadVeTheoLichChieu(lichChieu1.ID);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ TẠO!!!", "THÔNG BÁO");
            }
        }

        private void lvLichChieu_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                LichChieu1 lichChieu1 = lvLichChieu.SelectedItems[0].Tag as LichChieu1;
                LoadVeTheoLichChieu(lichChieu1.ID);
            }
        }
        void XoaVe(LichChieu1 lichChieu1)
        {
            PhongChieu1 phongChieu1=PhongChieu2.GetTenPhongChieu(lichChieu1.TenPhongChieu);
            int Row=phongChieu1.Row;
            int Column = phongChieu1.SeatInRow;
            int result = Ve2.XoaVe(lichChieu1.ID);
            if(result==Row*Column)
            {
                int ret = LichChieu2.CapNhatTrangThaiLichChieu(lichChieu1.ID,0);
                if(ret>0)
                {
                    MessageBox.Show("Xóa Tất Cả Lịch Chiếu Mã Lịch Chiếu" + lichChieu1.ID + "\nnThành Công!", "Thông Báo");
                }
            }
            else
            {
                MessageBox.Show("Xóa Tất Cả Lịch Chiếu Mã Lịch " + lichChieu1.ID + "\n Thất Bại!", "Thông Báo");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                LichChieu1 lichChieu1 = lvLichChieu.SelectedItems[0].Tag as LichChieu1;
                if (lichChieu1.TrangThai == 0)
                {
                    MessageBox.Show("LỊCH CHIẾU NÀY CHƯA ĐƯỢC TẠO VÉ!!!", "THÔNG BÁO");
                    return;
                }
                XoaVe(lichChieu1);
                LoadDanhSachLichChieu();
                LoadVeTheoLichChieu(lichChieu1.ID);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XÓA!!!", "THÔNG BÁO");
            }
        }

        private void btnXemLCCTV_Click(object sender, EventArgs e)
        {
            LoadLCCTV();
        }

        private void btnXemLichChieu_Click(object sender, EventArgs e)
        {
            LoadDanhSachLichChieu();
        }
        private void LoadLCCTV()
        {
            lvLichChieu.Items.Clear();

            List<LichChieu1> lichChieu1s = LichChieu2.GetListShowTimesNotCreateTickets();
            foreach (LichChieu1 lichChieu1 in lichChieu1s)
            {
                ListViewItem lv = new ListViewItem(lichChieu1.TenPhongChieu);
                lv.SubItems.Add(lichChieu1.TenPhim);
                lv.SubItems.Add(lichChieu1.Time.ToString("HH:mm:ss dd/MM/yyyy"));
                lv.Tag = lichChieu1;

                if (lichChieu1.TrangThai == 1)
                {
                    lv.SubItems.Add("Đã tạo");
                }
                else
                {
                    lv.SubItems.Add("Chưa Tạo");
                }
                lvLichChieu.Items.Add(lv);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                LichChieu1 showTimes = lvLichChieu.SelectedItems[0].Tag as LichChieu1;
                LoadMuaVeTheoLichChieu(showTimes.ID);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XEM!!!", "THÔNG BÁO");
            }
        }

        private void btnXemTatCaVe_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                LichChieu1 showTimes = lvLichChieu.SelectedItems[0].Tag as LichChieu1;
                LoadVeTheoLichChieu(showTimes.ID);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XEM!!!", "THÔNG BÁO");
            }
        }
    }
}
