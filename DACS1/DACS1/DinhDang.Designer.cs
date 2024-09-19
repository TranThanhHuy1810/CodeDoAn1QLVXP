namespace DACS1
{
    partial class DinhDang
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMaManHinh = new System.Windows.Forms.ComboBox();
            this.cbMaPhim = new System.Windows.Forms.ComboBox();
            this.txtTenManHinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenPhim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDinhDang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDinhDangPhim = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhDangPhim)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbMaManHinh);
            this.panel1.Controls.Add(this.cbMaPhim);
            this.panel1.Controls.Add(this.txtTenManHinh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTenPhim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMaDinhDang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 674);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tên Màn Hình :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã Màn Hình :";
            // 
            // cbMaManHinh
            // 
            this.cbMaManHinh.FormattingEnabled = true;
            this.cbMaManHinh.Location = new System.Drawing.Point(165, 204);
            this.cbMaManHinh.Name = "cbMaManHinh";
            this.cbMaManHinh.Size = new System.Drawing.Size(144, 28);
            this.cbMaManHinh.TabIndex = 7;
            this.cbMaManHinh.SelectedIndexChanged += new System.EventHandler(this.cbMaManHinh_SelectedIndexChanged);
            // 
            // cbMaPhim
            // 
            this.cbMaPhim.FormattingEnabled = true;
            this.cbMaPhim.Location = new System.Drawing.Point(165, 84);
            this.cbMaPhim.Name = "cbMaPhim";
            this.cbMaPhim.Size = new System.Drawing.Size(144, 28);
            this.cbMaPhim.TabIndex = 6;
            this.cbMaPhim.SelectedValueChanged += new System.EventHandler(this.cbMaPhim_SelectedValueChanged);
            // 
            // txtTenManHinh
            // 
            this.txtTenManHinh.Location = new System.Drawing.Point(165, 269);
            this.txtTenManHinh.Name = "txtTenManHinh";
            this.txtTenManHinh.Size = new System.Drawing.Size(144, 26);
            this.txtTenManHinh.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên Phim :";
            // 
            // txtTenPhim
            // 
            this.txtTenPhim.Location = new System.Drawing.Point(165, 138);
            this.txtTenPhim.Name = "txtTenPhim";
            this.txtTenPhim.Size = new System.Drawing.Size(144, 26);
            this.txtTenPhim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Phim :";
            // 
            // txtMaDinhDang
            // 
            this.txtMaDinhDang.Location = new System.Drawing.Point(165, 27);
            this.txtMaDinhDang.Name = "txtMaDinhDang";
            this.txtMaDinhDang.Size = new System.Drawing.Size(144, 26);
            this.txtMaDinhDang.TabIndex = 1;
            this.txtMaDinhDang.TextChanged += new System.EventHandler(this.txtMaDinhDang_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Định Dạng :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(340, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(314, 25);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 35);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(184, 25);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 35);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(54, 25);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDinhDangPhim
            // 
            this.dgvDinhDangPhim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDinhDangPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDinhDangPhim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDinhDangPhim.Location = new System.Drawing.Point(340, 100);
            this.dgvDinhDangPhim.Name = "dgvDinhDangPhim";
            this.dgvDinhDangPhim.RowHeadersWidth = 62;
            this.dgvDinhDangPhim.RowTemplate.Height = 28;
            this.dgvDinhDangPhim.Size = new System.Drawing.Size(876, 574);
            this.dgvDinhDangPhim.TabIndex = 2;
            // 
            // DinhDang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 674);
            this.Controls.Add(this.dgvDinhDangPhim);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DinhDang";
            this.Text = "DinhDang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDinhDangPhim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDinhDangPhim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMaManHinh;
        private System.Windows.Forms.ComboBox cbMaPhim;
        private System.Windows.Forms.TextBox txtTenManHinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenPhim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDinhDang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}