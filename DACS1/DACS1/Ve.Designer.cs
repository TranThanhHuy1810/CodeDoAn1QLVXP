namespace DACS1
{
    partial class Ve
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
            this.btnXemLichChieu = new System.Windows.Forms.Button();
            this.btnXemLCCTV = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvLichChieu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.btnXemTatCaVe = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXemTatCaVe);
            this.panel1.Controls.Add(this.btnXemLichChieu);
            this.panel1.Controls.Add(this.btnXemLCCTV);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnXemLichChieu
            // 
            this.btnXemLichChieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemLichChieu.Location = new System.Drawing.Point(1356, 12);
            this.btnXemLichChieu.Name = "btnXemLichChieu";
            this.btnXemLichChieu.Size = new System.Drawing.Size(187, 40);
            this.btnXemLichChieu.TabIndex = 4;
            this.btnXemLichChieu.Text = "Xem Tất Cả Lịch Chiếu";
            this.btnXemLichChieu.UseVisualStyleBackColor = true;
            this.btnXemLichChieu.Click += new System.EventHandler(this.btnXemLichChieu_Click);
            // 
            // btnXemLCCTV
            // 
            this.btnXemLCCTV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemLCCTV.Location = new System.Drawing.Point(1017, 12);
            this.btnXemLCCTV.Name = "btnXemLCCTV";
            this.btnXemLCCTV.Size = new System.Drawing.Size(261, 40);
            this.btnXemLCCTV.TabIndex = 3;
            this.btnXemLCCTV.Text = "Xem Lịch Chiếu Chưa Tạo Vé";
            this.btnXemLCCTV.UseVisualStyleBackColor = true;
            this.btnXemLCCTV.Click += new System.EventHandler(this.btnXemLCCTV_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(219, 23);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(157, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa Vé";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(427, 23);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(157, 40);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "Xem Vé Được Bán";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 23);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(157, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Tự động thêm vé";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvLichChieu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(943, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 603);
            this.panel2.TabIndex = 1;
            // 
            // lvLichChieu
            // 
            this.lvLichChieu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvLichChieu.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvLichChieu.FullRowSelect = true;
            this.lvLichChieu.GridLines = true;
            this.lvLichChieu.HideSelection = false;
            this.lvLichChieu.Location = new System.Drawing.Point(0, 0);
            this.lvLichChieu.Name = "lvLichChieu";
            this.lvLichChieu.Size = new System.Drawing.Size(612, 603);
            this.lvLichChieu.TabIndex = 0;
            this.lvLichChieu.UseCompatibleStateImageBehavior = false;
            this.lvLichChieu.View = System.Windows.Forms.View.Details;
            this.lvLichChieu.Click += new System.EventHandler(this.lvLichChieu_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Phòng Chiếu";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Phim";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thời Gian";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Trạng Thái";
            this.columnHeader4.Width = 100;
            // 
            // dgvVe
            // 
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVe.Location = new System.Drawing.Point(0, 74);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.RowHeadersWidth = 62;
            this.dgvVe.RowTemplate.Height = 28;
            this.dgvVe.Size = new System.Drawing.Size(943, 603);
            this.dgvVe.TabIndex = 2;
            // 
            // btnXemTatCaVe
            // 
            this.btnXemTatCaVe.Location = new System.Drawing.Point(654, 23);
            this.btnXemTatCaVe.Name = "btnXemTatCaVe";
            this.btnXemTatCaVe.Size = new System.Drawing.Size(157, 40);
            this.btnXemTatCaVe.TabIndex = 5;
            this.btnXemTatCaVe.Text = "Xem Tất Cả Vé";
            this.btnXemTatCaVe.UseVisualStyleBackColor = true;
            this.btnXemTatCaVe.Click += new System.EventHandler(this.btnXemTatCaVe_Click);
            // 
            // Ve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 677);
            this.Controls.Add(this.dgvVe);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Ve";
            this.Text = "Ve";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXemLichChieu;
        private System.Windows.Forms.Button btnXemLCCTV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvVe;
        private System.Windows.Forms.ListView lvLichChieu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnXemTatCaVe;
    }
}