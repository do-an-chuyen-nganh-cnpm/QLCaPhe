namespace GUI.UControl
{
    partial class UC_ThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ThongKe));
            this.groupBThongTin = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLocTheoNgay = new System.Windows.Forms.Button();
            this.txtNgayBD = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNgayKT = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxDieuKien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTongKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongSanPham = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongGiamGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.DGV_ThongKe = new System.Windows.Forms.DataGridView();
            this.grpDanhSachTK = new System.Windows.Forms.GroupBox();
            this.groupBThongTin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ThongKe)).BeginInit();
            this.grpDanhSachTK.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBThongTin
            // 
            this.groupBThongTin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBThongTin.Controls.Add(this.groupBox2);
            this.groupBThongTin.Controls.Add(this.groupBox1);
            this.groupBThongTin.Controls.Add(this.button1);
            this.groupBThongTin.Controls.Add(this.txtTongKH);
            this.groupBThongTin.Controls.Add(this.label5);
            this.groupBThongTin.Controls.Add(this.txtTongSanPham);
            this.groupBThongTin.Controls.Add(this.label4);
            this.groupBThongTin.Controls.Add(this.txtTongGiamGia);
            this.groupBThongTin.Controls.Add(this.label3);
            this.groupBThongTin.Controls.Add(this.txtTongDoanhThu);
            this.groupBThongTin.Controls.Add(this.label2);
            this.groupBThongTin.Location = new System.Drawing.Point(6, 8);
            this.groupBThongTin.Name = "groupBThongTin";
            this.groupBThongTin.Size = new System.Drawing.Size(1332, 140);
            this.groupBThongTin.TabIndex = 0;
            this.groupBThongTin.TabStop = false;
            this.groupBThongTin.Text = "Thông Tin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLocTheoNgay);
            this.groupBox2.Controls.Add(this.txtNgayBD);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtNgayKT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(410, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 65);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc theo ngày bất kỳ";
            // 
            // btnLocTheoNgay
            // 
            this.btnLocTheoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocTheoNgay.Image = ((System.Drawing.Image)(resources.GetObject("btnLocTheoNgay.Image")));
            this.btnLocTheoNgay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocTheoNgay.Location = new System.Drawing.Point(729, 15);
            this.btnLocTheoNgay.Name = "btnLocTheoNgay";
            this.btnLocTheoNgay.Size = new System.Drawing.Size(87, 31);
            this.btnLocTheoNgay.TabIndex = 16;
            this.btnLocTheoNgay.Text = "Lọc";
            this.btnLocTheoNgay.UseVisualStyleBackColor = true;
            this.btnLocTheoNgay.Click += new System.EventHandler(this.btnLocTheoNgay_Click);
            // 
            // txtNgayBD
            // 
            this.txtNgayBD.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayBD.Location = new System.Drawing.Point(154, 20);
            this.txtNgayBD.Name = "txtNgayBD";
            this.txtNgayBD.Size = new System.Drawing.Size(200, 24);
            this.txtNgayBD.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(374, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ngày kết thúc";
            // 
            // txtNgayKT
            // 
            this.txtNgayKT.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayKT.Location = new System.Drawing.Point(500, 19);
            this.txtNgayKT.Name = "txtNgayKT";
            this.txtNgayKT.Size = new System.Drawing.Size(200, 24);
            this.txtNgayKT.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ngày bắt đầu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxDieuKien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 65);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc nhanh";
            // 
            // cbxDieuKien
            // 
            this.cbxDieuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDieuKien.FormattingEnabled = true;
            this.cbxDieuKien.Location = new System.Drawing.Point(85, 19);
            this.cbxDieuKien.Name = "cbxDieuKien";
            this.cbxDieuKien.Size = new System.Drawing.Size(121, 28);
            this.cbxDieuKien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Điều kiện";
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoc.Location = new System.Drawing.Point(233, 19);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(79, 31);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1155, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 40);
            this.button1.TabIndex = 13;
            this.button1.Text = "Xuất file excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTongKH
            // 
            this.txtTongKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongKH.Location = new System.Drawing.Point(967, 100);
            this.txtTongKH.Name = "txtTongKH";
            this.txtTongKH.Size = new System.Drawing.Size(121, 26);
            this.txtTongKH.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(807, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số lượng khách hàng";
            // 
            // txtTongSanPham
            // 
            this.txtTongSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSanPham.Location = new System.Drawing.Point(127, 97);
            this.txtTongSanPham.Name = "txtTongSanPham";
            this.txtTongSanPham.Size = new System.Drawing.Size(121, 26);
            this.txtTongSanPham.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng sản phẩm";
            // 
            // txtTongGiamGia
            // 
            this.txtTongGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiamGia.Location = new System.Drawing.Point(662, 100);
            this.txtTongGiamGia.Name = "txtTongGiamGia";
            this.txtTongGiamGia.Size = new System.Drawing.Size(121, 26);
            this.txtTongGiamGia.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng giảm giá";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.Location = new System.Drawing.Point(399, 98);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(121, 26);
            this.txtTongDoanhThu.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng Doanh Thu";
            // 
            // DGV_ThongKe
            // 
            this.DGV_ThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ThongKe.Location = new System.Drawing.Point(6, 19);
            this.DGV_ThongKe.Name = "DGV_ThongKe";
            this.DGV_ThongKe.Size = new System.Drawing.Size(1370, 549);
            this.DGV_ThongKe.TabIndex = 0;
            // 
            // grpDanhSachTK
            // 
            this.grpDanhSachTK.Controls.Add(this.DGV_ThongKe);
            this.grpDanhSachTK.Location = new System.Drawing.Point(3, 154);
            this.grpDanhSachTK.Name = "grpDanhSachTK";
            this.grpDanhSachTK.Size = new System.Drawing.Size(1332, 543);
            this.grpDanhSachTK.TabIndex = 1;
            this.grpDanhSachTK.TabStop = false;
            this.grpDanhSachTK.Text = "Danh Sách";
            // 
            // UC_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDanhSachTK);
            this.Controls.Add(this.groupBThongTin);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(1338, 700);
            this.Load += new System.EventHandler(this.UC_ThongKe_Load);
            this.groupBThongTin.ResumeLayout(false);
            this.groupBThongTin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ThongKe)).EndInit();
            this.grpDanhSachTK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBThongTin;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbxDieuKien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongGiamGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongSanPham;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLocTheoNgay;
        private System.Windows.Forms.DateTimePicker txtNgayKT;
        private System.Windows.Forms.DateTimePicker txtNgayBD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGV_ThongKe;
        private System.Windows.Forms.GroupBox grpDanhSachTK;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
