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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public KhachHang1 KhachHang1;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = KhachHang2.LayBienTrongKhachHang(txtMaKhacHang.Text,txtHoTen.Text);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("ID hoặc Họ tên của Khách Hàng không chính xác!\nVui lòng nhập lại thông tin.");
                return;
            }
            KhachHang1 = new KhachHang1(data.Rows[0]);

            DialogResult = DialogResult.OK;
        }
    }
}
