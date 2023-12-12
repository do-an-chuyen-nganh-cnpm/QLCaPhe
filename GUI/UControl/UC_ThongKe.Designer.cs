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
            this.button1 = new System.Windows.Forms.Button();
            this.txtTongKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongSanPham = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongGiamGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDieuKien = new System.Windows.Forms.ComboBox();
            this.grpDanhSachTK = new System.Windows.Forms.GroupBox();
            this.DGV_ThongKe = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBThongTin.SuspendLayout();
            this.grpDanhSachTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBThongTin
            // 
            this.groupBThongTin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBThongTin.Controls.Add(this.button1);
            this.groupBThongTin.Controls.Add(this.txtTongKH);
            this.groupBThongTin.Controls.Add(this.label5);
            this.groupBThongTin.Controls.Add(this.txtTongSanPham);
            this.groupBThongTin.Controls.Add(this.label4);
            this.groupBThongTin.Controls.Add(this.txtTongGiamGia);
            this.groupBThongTin.Controls.Add(this.label3);
            this.groupBThongTin.Controls.Add(this.txtTongDoanhThu);
            this.groupBThongTin.Controls.Add(this.label2);
            this.groupBThongTin.Controls.Add(this.btnLoc);
            this.groupBThongTin.Controls.Add(this.label1);
            this.groupBThongTin.Controls.Add(this.cbxDieuKien);
            this.groupBThongTin.Location = new System.Drawing.Point(6, 8);
            this.groupBThongTin.Name = "groupBThongTin";
            this.groupBThongTin.Size = new System.Drawing.Size(1332, 109);
            this.groupBThongTin.TabIndex = 0;
            this.groupBThongTin.TabStop = false;
            this.groupBThongTin.Text = "Thông Tin";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1143, 50);
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
            this.txtTongKH.Location = new System.Drawing.Point(967, 62);
            this.txtTongKH.Name = "txtTongKH";
            this.txtTongKH.Size = new System.Drawing.Size(121, 26);
            this.txtTongKH.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(807, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số lượng khách hàng";
            // 
            // txtTongSanPham
            // 
            this.txtTongSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSanPham.Location = new System.Drawing.Point(127, 59);
            this.txtTongSanPham.Name = "txtTongSanPham";
            this.txtTongSanPham.Size = new System.Drawing.Size(121, 26);
            this.txtTongSanPham.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng sản phẩm";
            // 
            // txtTongGiamGia
            // 
            this.txtTongGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiamGia.Location = new System.Drawing.Point(662, 62);
            this.txtTongGiamGia.Name = "txtTongGiamGia";
            this.txtTongGiamGia.Size = new System.Drawing.Size(121, 26);
            this.txtTongGiamGia.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng giảm giá";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.Location = new System.Drawing.Point(399, 60);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(121, 26);
            this.txtTongDoanhThu.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng Doanh Thu";
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoc.Location = new System.Drawing.Point(278, 13);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(79, 31);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Điều kiện";
            // 
            // cbxDieuKien
            // 
            this.cbxDieuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDieuKien.FormattingEnabled = true;
            this.cbxDieuKien.Location = new System.Drawing.Point(127, 13);
            this.cbxDieuKien.Name = "cbxDieuKien";
            this.cbxDieuKien.Size = new System.Drawing.Size(121, 28);
            this.cbxDieuKien.TabIndex = 1;
            // 
            // grpDanhSachTK
            // 
            this.grpDanhSachTK.Controls.Add(this.DGV_ThongKe);
            this.grpDanhSachTK.Location = new System.Drawing.Point(3, 123);
            this.grpDanhSachTK.Name = "grpDanhSachTK";
            this.grpDanhSachTK.Size = new System.Drawing.Size(1332, 574);
            this.grpDanhSachTK.TabIndex = 1;
            this.grpDanhSachTK.TabStop = false;
            this.grpDanhSachTK.Text = "Danh Sách";
            // 
            // DGV_ThongKe
            // 
            this.DGV_ThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ThongKe.Location = new System.Drawing.Point(6, 19);
            this.DGV_ThongKe.Name = "DGV_ThongKe";
            this.DGV_ThongKe.Size = new System.Drawing.Size(1320, 549);
            this.DGV_ThongKe.TabIndex = 0;
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
            this.grpDanhSachTK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBThongTin;
        private System.Windows.Forms.GroupBox grpDanhSachTK;
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
        private System.Windows.Forms.DataGridView DGV_ThongKe;
        private System.Windows.Forms.Button button1;
    }
}
