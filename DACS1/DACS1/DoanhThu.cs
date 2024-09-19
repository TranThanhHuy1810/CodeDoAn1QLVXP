using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
            LoadDoanhThu();
        }
        void LoadDoanhThu()
        {
            LoadPhimVaoCombox(cbTenPhim);
            LoadDTPDoanhThu();
            LoadDoanhThu1(cbTenPhim.SelectedValue.ToString(),dtpTuNgay.Value,dtpDenNgay.Value);
        }
       void LoadPhimVaoCombox(ComboBox cbTenPhim)
        {
            cbTenPhim.DataSource = Phim2.GetListMovie();
            cbTenPhim.DisplayMember="Name";
            cbTenPhim.ValueMember = "ID";
        }
        void LoadDTPDoanhThu()
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddDays(-1);
        }
        void LoadDoanhThu1(string idPhim,DateTime TuNgay,DateTime DenNgay)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            dataGridView1.DataSource=DoanhThu2.DoanhThu(idPhim, TuNgay, DenNgay);
            txtTongDoanhThu.Text=GetSumRevenue().ToString("c",culture);
        }
        decimal GetSumRevenue()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Tiền vé"].Value);
            }
            return sum;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDoanhThu1(cbTenPhim.SelectedValue.ToString(), dtpTuNgay.Value, dtpDenNgay.Value);
        }
    }
}
