using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using GUI.UControl;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void init()
        {
        }
        private void LoadUC(UserControl u)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(u);
        }
        private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UControl.UC_ThongKe u = new UControl.UC_ThongKe();
            LoadUC(u);
        }
        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_KhuyenMai u = new UC_KhuyenMai();
            LoadUC(u);
        }
        private void PhanQuyen(string taiKhoan)
        {

        }

        private void gọiMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void gọiMónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UC_GoiMon u = new UC_GoiMon();
            LoadUC(u);
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThongKe u = new UC_ThongKe();
            LoadUC(u);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_KhachHang u = new UC_KhachHang();
            LoadUC(u);
        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_Ban u = new UC_Ban();
            LoadUC(u);
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_NhanVien u = new UC_NhanVien();
            LoadUC(u);
        }

        private void sanPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_SanPham u = new UC_SanPham();
            LoadUC(u);
        }

        private void loaiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_LoaiSP u = new UC_LoaiSP();
            LoadUC(u);
        }
    }
}
