﻿namespace GUI.UControl
{
    partial class UC_GoiMon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelDSBan = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGV_CTHoaDon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLoaiNuoc = new System.Windows.Forms.ComboBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnBoChon = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSSanPham = new System.Windows.Forms.DataGridView();
            this.txtSoLuongChon = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTongSL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrangThaiHD = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongSanPham = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.btnTachBan = new System.Windows.Forms.Button();
            this.btnTaoMoiHD = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btn_DatBan = new System.Windows.Forms.Button();
            this.btnTatCaMon = new System.Windows.Forms.Button();
            this.btn_ThanhToan = new System.Windows.Forms.Button();
            this.btnThongTinDB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CTHoaDon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongChon)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDSBan
            // 
            this.panelDSBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDSBan.Location = new System.Drawing.Point(3, 3);
            this.panelDSBan.Name = "panelDSBan";
            this.panelDSBan.Size = new System.Drawing.Size(398, 694);
            this.panelDSBan.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV_CTHoaDon);
            this.groupBox1.Location = new System.Drawing.Point(411, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 486);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa Đơn";
            // 
            // DGV_CTHoaDon
            // 
            this.DGV_CTHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_CTHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_CTHoaDon.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_CTHoaDon.Location = new System.Drawing.Point(6, 16);
            this.DGV_CTHoaDon.Name = "DGV_CTHoaDon";
            this.DGV_CTHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_CTHoaDon.Size = new System.Drawing.Size(350, 464);
            this.DGV_CTHoaDon.TabIndex = 1;
            this.DGV_CTHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CTHoaDon_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1005, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loại sản phẩm ";
            // 
            // cbxLoaiNuoc
            // 
            this.cbxLoaiNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLoaiNuoc.FormattingEnabled = true;
            this.cbxLoaiNuoc.Location = new System.Drawing.Point(1134, 14);
            this.cbxLoaiNuoc.Name = "cbxLoaiNuoc";
            this.cbxLoaiNuoc.Size = new System.Drawing.Size(190, 26);
            this.cbxLoaiNuoc.TabIndex = 2;
            this.cbxLoaiNuoc.TextChanged += new System.EventHandler(this.cbxLoaiNuoc_TextChanged);
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.Location = new System.Drawing.Point(779, 111);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 33);
            this.btnChon.TabIndex = 7;
            this.btnChon.Text = "<<";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnBoChon
            // 
            this.btnBoChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoChon.Location = new System.Drawing.Point(779, 157);
            this.btnBoChon.Name = "btnBoChon";
            this.btnBoChon.Size = new System.Drawing.Size(75, 33);
            this.btnBoChon.TabIndex = 8;
            this.btnBoChon.Text = ">>";
            this.btnBoChon.UseVisualStyleBackColor = true;
            this.btnBoChon.Click += new System.EventHandler(this.btnBoChon_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSSanPham);
            this.groupBox2.Location = new System.Drawing.Point(860, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 486);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvDSSanPham
            // 
            this.dgvDSSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSSanPham.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSSanPham.Location = new System.Drawing.Point(6, 16);
            this.dgvDSSanPham.Name = "dgvDSSanPham";
            this.dgvDSSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSSanPham.Size = new System.Drawing.Size(452, 464);
            this.dgvDSSanPham.TabIndex = 0;
            this.dgvDSSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSanPham_CellClick);
            // 
            // txtSoLuongChon
            // 
            this.txtSoLuongChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongChon.Location = new System.Drawing.Point(779, 207);
            this.txtSoLuongChon.Name = "txtSoLuongChon";
            this.txtSoLuongChon.Size = new System.Drawing.Size(75, 24);
            this.txtSoLuongChon.TabIndex = 12;
            this.txtSoLuongChon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Tên bàn";
            // 
            // txtTenBan
            // 
            this.txtTenBan.AutoSize = true;
            this.txtTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBan.Location = new System.Drawing.Point(481, 6);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(27, 16);
            this.txtTenBan.TabIndex = 29;
            this.txtTenBan.Text = "null";
            // 
            // txtMaHD
            // 
            this.txtMaHD.AutoSize = true;
            this.txtMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHD.Location = new System.Drawing.Point(733, 6);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(27, 16);
            this.txtMaHD.TabIndex = 33;
            this.txtMaHD.Text = "null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Mã Hóa Đơn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Controls.Add(this.txtTongSL);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtTrangThaiHD);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtTongTien);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtTongSanPham);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(411, 541);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 144);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin hóa đơn";
            // 
            // txtTongSL
            // 
            this.txtTongSL.AutoSize = true;
            this.txtTongSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSL.Location = new System.Drawing.Point(152, 48);
            this.txtTongSL.Name = "txtTongSL";
            this.txtTongSL.Size = new System.Drawing.Size(30, 18);
            this.txtTongSL.TabIndex = 7;
            this.txtTongSL.Text = "null";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tổng số lượng";
            // 
            // txtTrangThaiHD
            // 
            this.txtTrangThaiHD.AutoSize = true;
            this.txtTrangThaiHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThaiHD.Location = new System.Drawing.Point(153, 100);
            this.txtTrangThaiHD.Name = "txtTrangThaiHD";
            this.txtTrangThaiHD.Size = new System.Drawing.Size(30, 18);
            this.txtTrangThaiHD.TabIndex = 5;
            this.txtTrangThaiHD.Text = "null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Trạng thái";
            // 
            // txtTongTien
            // 
            this.txtTongTien.AutoSize = true;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(153, 74);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(30, 18);
            this.txtTongTien.TabIndex = 3;
            this.txtTongTien.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tổng tiền";
            // 
            // txtTongSanPham
            // 
            this.txtTongSanPham.AutoSize = true;
            this.txtTongSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSanPham.Location = new System.Drawing.Point(152, 22);
            this.txtTongSanPham.Name = "txtTongSanPham";
            this.txtTongSanPham.Size = new System.Drawing.Size(30, 18);
            this.txtTongSanPham.TabIndex = 1;
            this.txtTongSanPham.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng sản phẩm";
            // 
            // btnGopBan
            // 
            this.btnGopBan.Image = global::GUI.Properties.Resources.gopban;
            this.btnGopBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGopBan.Location = new System.Drawing.Point(866, 615);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(97, 45);
            this.btnGopBan.TabIndex = 36;
            this.btnGopBan.Text = "Gọp bàn";
            this.btnGopBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // btnTachBan
            // 
            this.btnTachBan.Image = global::GUI.Properties.Resources.tachban;
            this.btnTachBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTachBan.Location = new System.Drawing.Point(866, 563);
            this.btnTachBan.Name = "btnTachBan";
            this.btnTachBan.Size = new System.Drawing.Size(97, 45);
            this.btnTachBan.TabIndex = 35;
            this.btnTachBan.Text = "Tách bàn";
            this.btnTachBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTachBan.UseVisualStyleBackColor = true;
            this.btnTachBan.Click += new System.EventHandler(this.btnTachBan_Click);
            // 
            // btnTaoMoiHD
            // 
            this.btnTaoMoiHD.Image = global::GUI.Properties.Resources._new;
            this.btnTaoMoiHD.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTaoMoiHD.Location = new System.Drawing.Point(779, 293);
            this.btnTaoMoiHD.Name = "btnTaoMoiHD";
            this.btnTaoMoiHD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnTaoMoiHD.Size = new System.Drawing.Size(75, 61);
            this.btnTaoMoiHD.TabIndex = 31;
            this.btnTaoMoiHD.Text = "Tạo Hóa Đơn";
            this.btnTaoMoiHD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTaoMoiHD.UseVisualStyleBackColor = true;
            this.btnTaoMoiHD.Click += new System.EventHandler(this.btnTaoMoiHD_Click);
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Image = global::GUI.Properties.Resources.chuyenban;
            this.btnChuyenBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChuyenBan.Location = new System.Drawing.Point(1098, 563);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(97, 45);
            this.btnChuyenBan.TabIndex = 30;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChuyenBan.UseVisualStyleBackColor = true;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // btn_DatBan
            // 
            this.btn_DatBan.Image = global::GUI.Properties.Resources.datban;
            this.btn_DatBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DatBan.Location = new System.Drawing.Point(990, 563);
            this.btn_DatBan.Name = "btn_DatBan";
            this.btn_DatBan.Size = new System.Drawing.Size(97, 45);
            this.btn_DatBan.TabIndex = 25;
            this.btn_DatBan.Text = "Đặt bàn";
            this.btn_DatBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DatBan.UseVisualStyleBackColor = true;
            this.btn_DatBan.Click += new System.EventHandler(this.btn_DatBan_Click);
            // 
            // btnTatCaMon
            // 
            this.btnTatCaMon.Image = global::GUI.Properties.Resources.all;
            this.btnTatCaMon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTatCaMon.Location = new System.Drawing.Point(779, 53);
            this.btnTatCaMon.Name = "btnTatCaMon";
            this.btnTatCaMon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnTatCaMon.Size = new System.Drawing.Size(75, 45);
            this.btnTatCaMon.TabIndex = 11;
            this.btnTatCaMon.Text = "Tất cả";
            this.btnTatCaMon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTatCaMon.UseVisualStyleBackColor = true;
            this.btnTatCaMon.Click += new System.EventHandler(this.btnTatCaMon_Click);
            // 
            // btn_ThanhToan
            // 
            this.btn_ThanhToan.Image = global::GUI.Properties.Resources.pay;
            this.btn_ThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThanhToan.Location = new System.Drawing.Point(1211, 563);
            this.btn_ThanhToan.Name = "btn_ThanhToan";
            this.btn_ThanhToan.Size = new System.Drawing.Size(97, 45);
            this.btn_ThanhToan.TabIndex = 4;
            this.btn_ThanhToan.Text = "Thanh Toán ";
            this.btn_ThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ThanhToan.UseVisualStyleBackColor = true;
            this.btn_ThanhToan.Click += new System.EventHandler(this.btn_ThanhToan_Click);
            // 
            // btnThongTinDB
            // 
            this.btnThongTinDB.Image = global::GUI.Properties.Resources.gopban;
            this.btnThongTinDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTinDB.Location = new System.Drawing.Point(990, 615);
            this.btnThongTinDB.Name = "btnThongTinDB";
            this.btnThongTinDB.Size = new System.Drawing.Size(138, 45);
            this.btnThongTinDB.TabIndex = 37;
            this.btnThongTinDB.Text = "Thông tin đặt bàn";
            this.btnThongTinDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongTinDB.UseVisualStyleBackColor = true;
            this.btnThongTinDB.Click += new System.EventHandler(this.btnThongTinDB_Click);
            // 
            // button1
            // 
            this.button1.Image = global::GUI.Properties.Resources._new;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(779, 371);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(75, 61);
            this.button1.TabIndex = 38;
            this.button1.Text = "Làm Mới";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UC_GoiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnThongTinDB);
            this.Controls.Add(this.btnGopBan);
            this.Controls.Add(this.btnTachBan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTaoMoiHD);
            this.Controls.Add(this.btnChuyenBan);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_DatBan);
            this.Controls.Add(this.txtSoLuongChon);
            this.Controls.Add(this.btnTatCaMon);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnBoChon);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btn_ThanhToan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxLoaiNuoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelDSBan);
            this.Name = "UC_GoiMon";
            this.Size = new System.Drawing.Size(1338, 700);
            this.Load += new System.EventHandler(this.UC_GoiMon_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CTHoaDon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongChon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDSBan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLoaiNuoc;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnBoChon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTatCaMon;
        private System.Windows.Forms.NumericUpDown txtSoLuongChon;
        private System.Windows.Forms.Button btn_DatBan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtTenBan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.DataGridView dgvDSSanPham;
        private System.Windows.Forms.DataGridView DGV_CTHoaDon;
        private System.Windows.Forms.Button btnTaoMoiHD;
        private System.Windows.Forms.Label txtMaHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtTongTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTongSanPham;
        private System.Windows.Forms.Label txtTrangThaiHD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtTongSL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTachBan;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.Button btnThongTinDB;
        private System.Windows.Forms.Button button1;
    }
}
