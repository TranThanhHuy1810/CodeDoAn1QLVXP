using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace DACS1
{
    public partial class frmChonGhe : Form
    {
        int SIZE = 30;//Size của ghế
        int GAP = 7;//Khoảng cách giữa các ghế

        List<Ve1> listSeat = new List<Ve1>();

        //dùng lưu Ghế đang chọn
        List<Button> listSeatSelected = new List<Button>();

        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé
        float tienve;//so tien ve trong ve in

        KhachHang1 khachHang1;//lưu lại khách hàng thành viên

        LichChieu1 Times;
        Phim1 Phim1;
        public frmChonGhe(LichChieu1 lichChieu1, Phim1 phim1)
        {
            InitializeComponent();
            Times = lichChieu1;
            this.WindowState = FormWindowState.Maximized;
            Phim1 = phim1;
        }

        private void frmChonGhe_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.GiaVe;
            lbInformation.Text = "CGV Cần Thơ |" + Times.TenPhongChieu + "|" + Times.TenPhim;
            lbThoiGian.Text = Times.Time.ToShortDateString() + "|" + Times.Time.ToShortTimeString();
            lblTenRap.Text = "CGV Cần Thơ";
            lblTenPhim.Text = Times.TenPhim;
            lblTenPhongChieu.Text = Times.TenPhongChieu;
            lblThoiGian.Text = Times.Time.ToShortDateString() + "|" + Times.Time.ToShortTimeString();
            checkBox1.Enabled = false;
            LoadDataCinema(Times.TenPhongChieu);

            ShowOrHideLablePoint();
            listSeat = Ve2.GetListTicketsByShowTimes(Times.ID);

            LoadSeats(listSeat);
        }
        private void LoadDataCinema(string cinemaName)
        {
            PhongChieu1 cinema = PhongChieu2.GetTenPhongChieu(cinemaName);
            int Row = cinema.Row;
            int Column = cinema.SeatInRow;
            flowLayoutPanel1.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }
        private void ShowOrHideLablePoint()
        {
            if (checkBox1.Checked == true)
            {
                pnKhachHang.Visible = true;
            }
            else
            {
                pnKhachHang.Visible = false;
            }
        }
        private void LoadSeats(List<Ve1> list)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Button btnSeat = new Button() { Width = SIZE + 20, Height = SIZE };
                btnSeat.Text = list[i].SeatName;
                if (list[i].TrạngThái == 1)
                    btnSeat.BackColor = Color.Red;
                else
                    btnSeat.BackColor = Color.White;
                btnSeat.Click += BtnSeat_Click;
                flowLayoutPanel1.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                btnSeat.BackColor = Color.Yellow;
                Ve1 ticket = btnSeat.Tag as Ve1;
                lblGhe.Text += "[" + btnSeat.Text + "]";
                ticket.Gía = ticketPrice;
                displayPrice = ticket.Gía;
                total += ticketPrice;
                payment = total - discount;
                tienve = total - discount;

                listSeatSelected.Add(btnSeat);
                plusPoint++;
                lblDiemCong.Text = plusPoint + "";
            }
            else if (btnSeat.BackColor == Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ve1 ticket = btnSeat.Tag as Ve1;

                total -= ticket.Gía;
                payment = total - discount;
                tienve = total - discount;
                ticket.Gía = 0;
                displayPrice = ticket.Gía;
                ticket.Gía = 0;

                listSeatSelected.Remove(btnSeat);
                plusPoint--;
                lblDiemCong.Text = plusPoint + "";
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
            }

        }
        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            lblToltal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayMent.Text = payment.ToString("c", culture);
            lblThanhToan.Text = tienve.ToString("c", culture);

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                frmKhachHang frm = new frmKhachHang();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    khachHang1 = frm.KhachHang1;
                    lbTenKhachHang.Text = khachHang1.TenKH;
                    lblDiem.Text = khachHang1.DiemTichLuy + "";
                    ShowOrHideLablePoint();
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                ShowOrHideLablePoint();
                khachHang1 = null;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn hủy tất cả những vé đã chọn ko?",
                "Hủy Mua Vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (Button btn in listSeatSelected)
            {
                btn.BackColor = Color.White;
            }
            RestoreDefault();
            RestoreVe();
            this.OnLoad(new EventArgs());
        }
        private void RestoreDefault()//Cac method se tro lai ban dau
        {
            listSeatSelected.Clear();
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            ShowOrHideLablePoint();
            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;
            LoadBill();
        }
        private void RestoreVe()
        {
            lblGhe.Text = "";
            lblThanhToan.Text = "";
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán!");
                return;
            }
            string message = "Bạn có chắc chắn mua những vé: \n";
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {

                int ret = 0;
                if (checkBox1.Checked == true)
                {
                    foreach (Button btn in listSeatSelected)
                    {
                        Ve1 ticket = btn.Tag as Ve1;

                        ret += Ve2.BuyTicket1(ticket.ID, khachHang1.ID, ticket.Gía);
                    }
                    khachHang1.DiemTichLuy += plusPoint;
                    KhachHang2.CapNhatDiemTichLuy(khachHang1.ID, khachHang1.DiemTichLuy);
                }
                else
                {
                    foreach (Button btn in listSeatSelected)
                    {
                        Ve1 ticket = btn.Tag as Ve1;

                        ret += Ve2.BuyTicket(ticket.ID, ticket.Gía);
                    }
                }
                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");
                    btnInVe.Enabled=true;
                }
            }
            RestoreDefault();

            this.OnLoad(new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int freeTickets = (int)numericUpDown1.Value;
            if (freeTickets <= 0) return;

            if (freeTickets > listSeat.Count)
            {
                MessageBox.Show("BẠN CHỈ ĐỔI ĐƯỢC TỐT ĐA [" + listSeatSelected.Count + "] VÉ", "THÔNG BÁO");
                return;
            }
            int pointFreeTicket = freeTickets * 10;
            if (khachHang1.DiemTichLuy < pointFreeTicket)
            {
                MessageBox.Show("BẠN KHÔNG ĐỦ ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ", "THÔNG BÁO");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("BẠN CÓ MUỐN DÙNG ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ MIỄN PHÍ KHÔNG?",
                                        "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    khachHang1.DiemTichLuy -= pointFreeTicket;
                    plusPoint -= freeTickets;

                    if (KhachHang2.CapNhatDiemTichLuy(khachHang1.ID, khachHang1.DiemTichLuy))
                    {
                        MessageBox.Show("BẠN ĐÃ DỔI ĐƯỢC [" + freeTickets + "] VÉ MIỄN PHÍ THÀNH CÔNG", "THÔNG BÁO");
                    }
                    lblDiem.Text = "" + khachHang1.DiemTichLuy;
                    lblDiemCong.Text = "" + plusPoint;

                    for (int i = 0; i < listSeatSelected.Count && freeTickets > 0; i++)
                    {
                        Ve1 ticket = listSeatSelected[i].Tag as Ve1;
                        if (ticket.Gía != 0)
                        {
                            discount += ticket.Gía;
                            ticket.Gía = 0;
                            freeTickets--;
                        }
                    }
                    tienve = total - discount;
                    payment = total - discount;
                    LoadBill();
                }
            }
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            // Đường dẫn tới file txt sẽ lưu
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Lưu tệp văn bản";

            // Hiển thị SaveFileDialog và kiểm tra nếu người dùng chọn vị trí lưu
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Đường dẫn được chọn bởi người dùng
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Mở file để ghi
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Lấy tất cả các Label trong GroupBox và sắp xếp theo TabIndex
                        var labels = groupBox2.Controls.OfType<Label>().OrderBy(l => l.TabIndex);

                        // Ghi text của từng Label vào file
                        foreach (var label in labels)
                        {
                            writer.WriteLine(label.Text);
                        }
                    }

                    // Thông báo khi ghi file thành công
                    MessageBox.Show("In Vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInVe.Enabled = false;
                }
                catch (Exception ex)
                {
                    // Thông báo nếu có lỗi xảy ra
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RestoreVe();
            }
        }
    }
}