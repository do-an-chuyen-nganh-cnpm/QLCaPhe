namespace GUI.UControl
{
    partial class UC_HoaDon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo_TatCa = new System.Windows.Forms.RadioButton();
            this.rdo_ChuaThanhToan = new System.Windows.Forms.RadioButton();
            this.rdo_DaThanhToan = new System.Windows.Forms.RadioButton();
            this.datetimeNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_Ban = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVHoaDon = new System.Windows.Forms.DataGridView();
            this.DGVCTHoaDon = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCTHoaDon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaHoaDon);
            this.groupBox1.Controls.Add(this.btnInHoaDon);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.datetimeNgayLap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbx_Ban);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1316, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdo_TatCa);
            this.panel1.Controls.Add(this.rdo_ChuaThanhToan);
            this.panel1.Controls.Add(this.rdo_DaThanhToan);
            this.panel1.Location = new System.Drawing.Point(43, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 38);
            this.panel1.TabIndex = 7;
            // 
            // rdo_TatCa
            // 
            this.rdo_TatCa.AutoSize = true;
            this.rdo_TatCa.Location = new System.Drawing.Point(293, 10);
            this.rdo_TatCa.Name = "rdo_TatCa";
            this.rdo_TatCa.Size = new System.Drawing.Size(56, 17);
            this.rdo_TatCa.TabIndex = 2;
            this.rdo_TatCa.TabStop = true;
            this.rdo_TatCa.Text = "Tất cả";
            this.rdo_TatCa.UseVisualStyleBackColor = true;
            this.rdo_TatCa.CheckedChanged += new System.EventHandler(this.rdo_TatCa_CheckedChanged);
            // 
            // rdo_ChuaThanhToan
            // 
            this.rdo_ChuaThanhToan.AutoSize = true;
            this.rdo_ChuaThanhToan.Location = new System.Drawing.Point(158, 11);
            this.rdo_ChuaThanhToan.Name = "rdo_ChuaThanhToan";
            this.rdo_ChuaThanhToan.Size = new System.Drawing.Size(104, 17);
            this.rdo_ChuaThanhToan.TabIndex = 1;
            this.rdo_ChuaThanhToan.TabStop = true;
            this.rdo_ChuaThanhToan.Text = "Chưa thanh toán";
            this.rdo_ChuaThanhToan.UseVisualStyleBackColor = true;
            this.rdo_ChuaThanhToan.CheckedChanged += new System.EventHandler(this.rdo_ChuaThanhToan_CheckedChanged);
            // 
            // rdo_DaThanhToan
            // 
            this.rdo_DaThanhToan.AutoSize = true;
            this.rdo_DaThanhToan.Location = new System.Drawing.Point(17, 11);
            this.rdo_DaThanhToan.Name = "rdo_DaThanhToan";
            this.rdo_DaThanhToan.Size = new System.Drawing.Size(93, 17);
            this.rdo_DaThanhToan.TabIndex = 0;
            this.rdo_DaThanhToan.TabStop = true;
            this.rdo_DaThanhToan.Text = "Đã thanh toán";
            this.rdo_DaThanhToan.UseVisualStyleBackColor = true;
            this.rdo_DaThanhToan.CheckedChanged += new System.EventHandler(this.rdo_DaThanhToan_CheckedChanged);
            // 
            // datetimeNgayLap
            // 
            this.datetimeNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimeNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimeNgayLap.Location = new System.Drawing.Point(414, 20);
            this.datetimeNgayLap.Name = "datetimeNgayLap";
            this.datetimeNgayLap.Size = new System.Drawing.Size(200, 24);
            this.datetimeNgayLap.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(340, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày lập";
            // 
            // cbx_Ban
            // 
            this.cbx_Ban.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Ban.FormattingEnabled = true;
            this.cbx_Ban.Location = new System.Drawing.Point(149, 59);
            this.cbx_Ban.Name = "cbx_Ban";
            this.cbx_Ban.Size = new System.Drawing.Size(165, 24);
            this.cbx_Ban.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bàn ";
            // 
            // DGVHoaDon
            // 
            this.DGVHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHoaDon.Location = new System.Drawing.Point(6, 19);
            this.DGVHoaDon.Name = "DGVHoaDon";
            this.DGVHoaDon.Size = new System.Drawing.Size(703, 492);
            this.DGVHoaDon.TabIndex = 1;
            this.DGVHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHoaDon_CellClick);
            // 
            // DGVCTHoaDon
            // 
            this.DGVCTHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCTHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCTHoaDon.Location = new System.Drawing.Point(10, 19);
            this.DGVCTHoaDon.Name = "DGVCTHoaDon";
            this.DGVCTHoaDon.Size = new System.Drawing.Size(585, 507);
            this.DGVCTHoaDon.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVHoaDon);
            this.groupBox2.Location = new System.Drawing.Point(3, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 526);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVCTHoaDon);
            this.groupBox3.Location = new System.Drawing.Point(724, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(601, 532);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết hóa đơn";
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Image = global::GUI.Properties.Resources.printer;
            this.btnInHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInHoaDon.Location = new System.Drawing.Point(721, 18);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(116, 38);
            this.btnInHoaDon.TabIndex = 8;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = global::GUI.Properties.Resources.search;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(513, 51);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(101, 38);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(149, 22);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(165, 24);
            this.txtMaHoaDon.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã Hóa Đơn ";
            // 
            // btnAll
            // 
            this.btnAll.Image = global::GUI.Properties.Resources.all;
            this.btnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.Location = new System.Drawing.Point(363, 51);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(132, 38);
            this.btnAll.TabIndex = 11;
            this.btnAll.Text = "Hiển thị tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // UC_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_HoaDon";
            this.Size = new System.Drawing.Size(1338, 700);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCTHoaDon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVHoaDon;
        private System.Windows.Forms.DataGridView DGVCTHoaDon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Ban;
        private System.Windows.Forms.DateTimePicker datetimeNgayLap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo_DaThanhToan;
        private System.Windows.Forms.RadioButton rdo_ChuaThanhToan;
        private System.Windows.Forms.RadioButton rdo_TatCa;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Button btnAll;
    }
}
