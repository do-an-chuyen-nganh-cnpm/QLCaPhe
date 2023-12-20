namespace GUI.Frm
{
    partial class frm_TachBan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVDangChon = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVChinh = new System.Windows.Forms.DataGridView();
            this.btnChonSP = new System.Windows.Forms.Button();
            this.btnBoChonSP = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.Label();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDangChon)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 502);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Bàn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVDangChon);
            this.groupBox2.Location = new System.Drawing.Point(409, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 467);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bàn đã chọn";
            // 
            // DGVDangChon
            // 
            this.DGVDangChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDangChon.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDangChon.Location = new System.Drawing.Point(6, 19);
            this.DGVDangChon.Name = "DGVDangChon";
            this.DGVDangChon.RowHeadersWidth = 51;
            this.DGVDangChon.Size = new System.Drawing.Size(299, 442);
            this.DGVDangChon.TabIndex = 0;
            this.DGVDangChon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDangChon_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVChinh);
            this.groupBox3.Location = new System.Drawing.Point(801, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 467);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bàn Hiện Tại";
            // 
            // DGVChinh
            // 
            this.DGVChinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVChinh.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVChinh.Location = new System.Drawing.Point(5, 19);
            this.DGVChinh.Name = "DGVChinh";
            this.DGVChinh.RowHeadersWidth = 51;
            this.DGVChinh.Size = new System.Drawing.Size(332, 442);
            this.DGVChinh.TabIndex = 0;
            this.DGVChinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVChinh_CellClick);
            // 
            // btnChonSP
            // 
            this.btnChonSP.Location = new System.Drawing.Point(722, 66);
            this.btnChonSP.Name = "btnChonSP";
            this.btnChonSP.Size = new System.Drawing.Size(75, 31);
            this.btnChonSP.TabIndex = 6;
            this.btnChonSP.Text = "<<";
            this.btnChonSP.UseVisualStyleBackColor = true;
            this.btnChonSP.Click += new System.EventHandler(this.btnChonSP_Click);
            // 
            // btnBoChonSP
            // 
            this.btnBoChonSP.Location = new System.Drawing.Point(722, 115);
            this.btnBoChonSP.Name = "btnBoChonSP";
            this.btnBoChonSP.Size = new System.Drawing.Size(75, 31);
            this.btnBoChonSP.TabIndex = 7;
            this.btnBoChonSP.Text = ">>";
            this.btnBoChonSP.UseVisualStyleBackColor = true;
            this.btnBoChonSP.Click += new System.EventHandler(this.btnBoChonSP_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(722, 161);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(75, 24);
            this.txtSoLuong.TabIndex = 8;
            this.txtSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoLuong.ValueChanged += new System.EventHandler(this.txtSoLuong_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên bàn";
            // 
            // txtTenBan
            // 
            this.txtTenBan.AutoSize = true;
            this.txtTenBan.Location = new System.Drawing.Point(516, 16);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(23, 13);
            this.txtTenBan.TabIndex = 11;
            this.txtTenBan.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mã hóa đơn ";
            // 
            // txtMaHD
            // 
            this.txtMaHD.AutoSize = true;
            this.txtMaHD.Location = new System.Drawing.Point(678, 16);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(49, 13);
            this.txtMaHD.TabIndex = 13;
            this.txtMaHD.Text = "txtMaHD";
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Image = global::GUI.Properties.Resources._new;
            this.btnTaoHoaDon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTaoHoaDon.Location = new System.Drawing.Point(722, 200);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(75, 61);
            this.btnTaoHoaDon.TabIndex = 14;
            this.btnTaoHoaDon.Text = "Tạo HoaDon";
            this.btnTaoHoaDon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // frm_TachBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 556);
            this.Controls.Add(this.btnTaoHoaDon);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnBoChonSP);
            this.Controls.Add(this.btnChonSP);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_TachBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TachBan";
            this.Load += new System.EventHandler(this.frm_TachBan_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDangChon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChonSP;
        private System.Windows.Forms.Button btnBoChonSP;
        private System.Windows.Forms.NumericUpDown txtSoLuong;
        private System.Windows.Forms.DataGridView DGVDangChon;
        private System.Windows.Forms.DataGridView DGVChinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtTenBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtMaHD;
        private System.Windows.Forms.Button btnTaoHoaDon;
    }
}