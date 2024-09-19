namespace DACS1
{
    partial class PhongChieu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPhongChieu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhongChieu = new System.Windows.Forms.TextBox();
            this.txtTenPhongChieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChoNgoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoHangGhe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSeatInRow = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbManHinh = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbManHinh);
            this.panel1.Controls.Add(this.txtSeatInRow);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSoHangGhe);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTinhTrang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtChoNgoi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTenPhongChieu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMaPhongChieu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 663);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(290, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 100);
            this.panel2.TabIndex = 1;
            // 
            // dgvPhongChieu
            // 
            this.dgvPhongChieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongChieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhongChieu.Location = new System.Drawing.Point(290, 100);
            this.dgvPhongChieu.Name = "dgvPhongChieu";
            this.dgvPhongChieu.RowHeadersWidth = 62;
            this.dgvPhongChieu.RowTemplate.Height = 28;
            this.dgvPhongChieu.Size = new System.Drawing.Size(864, 563);
            this.dgvPhongChieu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phòng Chiếu :";
            // 
            // txtMaPhongChieu
            // 
            this.txtMaPhongChieu.Location = new System.Drawing.Point(16, 49);
            this.txtMaPhongChieu.Name = "txtMaPhongChieu";
            this.txtMaPhongChieu.Size = new System.Drawing.Size(239, 26);
            this.txtMaPhongChieu.TabIndex = 1;
            this.txtMaPhongChieu.TextChanged += new System.EventHandler(this.txtMaPhongChieu_TextChanged);
            // 
            // txtTenPhongChieu
            // 
            this.txtTenPhongChieu.Location = new System.Drawing.Point(17, 125);
            this.txtTenPhongChieu.Name = "txtTenPhongChieu";
            this.txtTenPhongChieu.Size = new System.Drawing.Size(239, 26);
            this.txtTenPhongChieu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Phòng Chiếu :";
            // 
            // txtChoNgoi
            // 
            this.txtChoNgoi.Location = new System.Drawing.Point(19, 291);
            this.txtChoNgoi.Name = "txtChoNgoi";
            this.txtChoNgoi.Size = new System.Drawing.Size(239, 26);
            this.txtChoNgoi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số Chỗ Ngồi :";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(17, 377);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(239, 26);
            this.txtTinhTrang.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tình Trạng :";
            // 
            // txtSoHangGhe
            // 
            this.txtSoHangGhe.Location = new System.Drawing.Point(18, 463);
            this.txtSoHangGhe.Name = "txtSoHangGhe";
            this.txtSoHangGhe.Size = new System.Drawing.Size(239, 26);
            this.txtSoHangGhe.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số Hàng Ghế :";
            // 
            // txtSeatInRow
            // 
            this.txtSeatInRow.Location = new System.Drawing.Point(17, 545);
            this.txtSeatInRow.Name = "txtSeatInRow";
            this.txtSeatInRow.Size = new System.Drawing.Size(239, 26);
            this.txtSeatInRow.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 505);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số Ghế Một Hàng :";
            // 
            // cbManHinh
            // 
            this.cbManHinh.FormattingEnabled = true;
            this.cbManHinh.Location = new System.Drawing.Point(20, 204);
            this.cbManHinh.Name = "cbManHinh";
            this.cbManHinh.Size = new System.Drawing.Size(237, 28);
            this.cbManHinh.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Màn Hình";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(40, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(184, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 32);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(340, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(91, 32);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // PhongChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 663);
            this.Controls.Add(this.dgvPhongChieu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PhongChieu";
            this.Text = "PhongChieu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPhongChieu;
        private System.Windows.Forms.TextBox txtMaPhongChieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbManHinh;
        private System.Windows.Forms.TextBox txtSeatInRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoHangGhe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChoNgoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenPhongChieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}