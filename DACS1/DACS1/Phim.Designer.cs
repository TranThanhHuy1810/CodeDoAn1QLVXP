namespace DACS1
{
    partial class Phim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clbTheLoai = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dptNgayKhoiChieu = new System.Windows.Forms.DateTimePicker();
            this.dptNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.txtNamSanXuat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenPhim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThoiLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSanXuat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDaoDien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaPhim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnThemHinhAnh = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnThemHinhAnh);
            this.groupBox1.Controls.Add(this.picAnh);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.clbTheLoai);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dptNgayKhoiChieu);
            this.groupBox1.Controls.Add(this.dptNgayKetThuc);
            this.groupBox1.Controls.Add(this.txtNamSanXuat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTenPhim);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtThoiLuong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSanXuat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDaoDien);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaPhim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1299, 342);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Phim";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Thể Loại :";
            // 
            // clbTheLoai
            // 
            this.clbTheLoai.FormattingEnabled = true;
            this.clbTheLoai.Location = new System.Drawing.Point(129, 159);
            this.clbTheLoai.Name = "clbTheLoai";
            this.clbTheLoai.Size = new System.Drawing.Size(358, 142);
            this.clbTheLoai.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(594, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ngày Kết Thúc : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(594, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ngày Khởi Chiếu : ";
            // 
            // dptNgayKhoiChieu
            // 
            this.dptNgayKhoiChieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptNgayKhoiChieu.Location = new System.Drawing.Point(776, 160);
            this.dptNgayKhoiChieu.Name = "dptNgayKhoiChieu";
            this.dptNgayKhoiChieu.Size = new System.Drawing.Size(138, 26);
            this.dptNgayKhoiChieu.TabIndex = 13;
            // 
            // dptNgayKetThuc
            // 
            this.dptNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptNgayKetThuc.Location = new System.Drawing.Point(776, 239);
            this.dptNgayKetThuc.Name = "dptNgayKetThuc";
            this.dptNgayKetThuc.Size = new System.Drawing.Size(138, 26);
            this.dptNgayKetThuc.TabIndex = 12;
            // 
            // txtNamSanXuat
            // 
            this.txtNamSanXuat.Location = new System.Drawing.Point(776, 91);
            this.txtNamSanXuat.Name = "txtNamSanXuat";
            this.txtNamSanXuat.Size = new System.Drawing.Size(125, 26);
            this.txtNamSanXuat.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(619, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Năm Sản Xuất :";
            // 
            // txtTenPhim
            // 
            this.txtTenPhim.Location = new System.Drawing.Point(129, 97);
            this.txtTenPhim.Name = "txtTenPhim";
            this.txtTenPhim.Size = new System.Drawing.Size(172, 26);
            this.txtTenPhim.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(622, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đạo Diễn :";
            // 
            // txtThoiLuong
            // 
            this.txtThoiLuong.Location = new System.Drawing.Point(451, 33);
            this.txtThoiLuong.Name = "txtThoiLuong";
            this.txtThoiLuong.Size = new System.Drawing.Size(89, 26);
            this.txtThoiLuong.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sản Xuất :";
            // 
            // txtSanXuat
            // 
            this.txtSanXuat.Location = new System.Drawing.Point(451, 95);
            this.txtSanXuat.Name = "txtSanXuat";
            this.txtSanXuat.Size = new System.Drawing.Size(89, 26);
            this.txtSanXuat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời Lượng:";
            // 
            // txtDaoDien
            // 
            this.txtDaoDien.Location = new System.Drawing.Point(776, 34);
            this.txtDaoDien.Name = "txtDaoDien";
            this.txtDaoDien.Size = new System.Drawing.Size(125, 26);
            this.txtDaoDien.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Phim :";
            // 
            // txtMaPhim
            // 
            this.txtMaPhim.Location = new System.Drawing.Point(129, 33);
            this.txtMaPhim.Name = "txtMaPhim";
            this.txtMaPhim.Size = new System.Drawing.Size(76, 26);
            this.txtMaPhim.TabIndex = 1;
            this.txtMaPhim.TextChanged += new System.EventHandler(this.txtMaPhim_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phim :";
            // 
            // dgvPhim
            // 
            this.dgvPhim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPhim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhim.Location = new System.Drawing.Point(12, 435);
            this.dgvPhim.Name = "dgvPhim";
            this.dgvPhim.RowHeadersWidth = 62;
            this.dgvPhim.RowTemplate.Height = 28;
            this.dgvPhim.Size = new System.Drawing.Size(1305, 258);
            this.dgvPhim.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.Location = new System.Drawing.Point(81, 373);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(93, 36);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.Location = new System.Drawing.Point(225, 373);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(93, 36);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSua.Location = new System.Drawing.Point(381, 373);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(93, 36);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // picAnh
            // 
            this.picAnh.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.picAnh.Location = new System.Drawing.Point(981, 25);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(237, 257);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 18;
            this.picAnh.TabStop = false;
            // 
            // btnThemHinhAnh
            // 
            this.btnThemHinhAnh.Location = new System.Drawing.Point(1043, 288);
            this.btnThemHinhAnh.Name = "btnThemHinhAnh";
            this.btnThemHinhAnh.Size = new System.Drawing.Size(116, 38);
            this.btnThemHinhAnh.TabIndex = 19;
            this.btnThemHinhAnh.Text = "Thêm Ảnh";
            this.btnThemHinhAnh.UseVisualStyleBackColor = true;
            this.btnThemHinhAnh.Click += new System.EventHandler(this.btnThemHinhAnh_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTaoMoi.Location = new System.Drawing.Point(525, 373);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(93, 36);
            this.btnTaoMoi.TabIndex = 5;
            this.btnTaoMoi.Text = "Tạo Mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // Phim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 725);
            this.Controls.Add(this.btnTaoMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvPhim);
            this.Controls.Add(this.groupBox1);
            this.Name = "Phim";
            this.Text = "Phim";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaPhim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamSanXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenPhim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThoiLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSanXuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDaoDien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbTheLoai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dptNgayKhoiChieu;
        private System.Windows.Forms.DateTimePicker dptNgayKetThuc;
        private System.Windows.Forms.DataGridView dgvPhim;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThemHinhAnh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnTaoMoi;
    }
}