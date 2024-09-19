using DACS1.QLVXPDataSetTableAdapters;
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
    public partial class PhimDangChieu : Form
    {
        public PhimDangChieu()
        {
            InitializeComponent();
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                
                LichChieu1 showTimes = listView1.SelectedItems[0].Tag as LichChieu1;
                Phim1 phim1 = listView1.SelectedItems[0].Tag as Phim1;
                frmChonGhe frm = new frmChonGhe(showTimes,phim1);
                this.Hide();
                frm.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }
        void LoadDanhSachLichChieu()
        {
            listView1.Items.Clear();
            List<LichChieu1> lichChieu1s = LichChieu2.GetAllListShowTimes();
            foreach (LichChieu1 lichChieu1 in lichChieu1s)
            {
                ListViewItem lv = new ListViewItem(lichChieu1.TenPhongChieu);
                lv.SubItems.Add(lichChieu1.TenPhim);
                lv.SubItems.Add(lichChieu1.Time.ToString("HH:mm:ss dd/MM/yyyy")); 
                if (lichChieu1.TrangThai == 1)
                {
                    lv.SubItems.Add("Đang Chiếu");
                }
                else
                {
                    lv.SubItems.Add("Sắp Chiếu");
                }
                lv.Tag = lichChieu1; 
                listView1.Items.Add(lv);
            }

        }

        private void PhimDangChieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachLichChieu();
        }
    } 
}

