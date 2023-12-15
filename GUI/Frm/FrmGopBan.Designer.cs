namespace GUI.Frm
{
    partial class FrmGopBan
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
            this.btn_GopBan = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_HoaDon = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelDSBan = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GopBan
            // 
            this.btn_GopBan.Location = new System.Drawing.Point(415, 413);
            this.btn_GopBan.Name = "btn_GopBan";
            this.btn_GopBan.Size = new System.Drawing.Size(120, 36);
            this.btn_GopBan.TabIndex = 1;
            this.btn_GopBan.Text = "Gọp Bàn";
            this.btn_GopBan.UseVisualStyleBackColor = true;
            this.btn_GopBan.Click += new System.EventHandler(this.btn_GopBan_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_HoaDon);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(404, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 390);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hóa Dơn ";
            // 
            // dgv_HoaDon
            // 
            this.dgv_HoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDon.Location = new System.Drawing.Point(5, 18);
            this.dgv_HoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            this.dgv_HoaDon.RowHeadersWidth = 82;
            this.dgv_HoaDon.RowTemplate.Height = 33;
            this.dgv_HoaDon.Size = new System.Drawing.Size(504, 361);
            this.dgv_HoaDon.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(588, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 390);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách bàn ";
            // 
            // panelDSBan
            // 
            this.panelDSBan.Location = new System.Drawing.Point(26, 18);
            this.panelDSBan.Margin = new System.Windows.Forms.Padding(2);
            this.panelDSBan.Name = "panelDSBan";
            this.panelDSBan.Size = new System.Drawing.Size(363, 380);
            this.panelDSBan.TabIndex = 3;
            // 
            // FrmGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 520);
            this.Controls.Add(this.panelDSBan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_GopBan);
            this.Name = "FrmGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGopBan";
            this.Load += new System.EventHandler(this.FrmGopBan_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_GopBan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private System.Windows.Forms.Panel panelDSBan;
    }
}