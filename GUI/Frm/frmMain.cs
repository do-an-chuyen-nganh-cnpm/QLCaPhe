using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL;
using BLL.Core;
using BLL.DB;
using GUI.UControl;

namespace GUI
{
    public partial class frmMain : Form
    {
        XuLyQuyenManHinh xuLyQuyenManHinh = new XuLyQuyenManHinh();
        //
        static string  _MaQuyen;
        public frmMain()
        {
            init();
        }
        public void LoadDSBan()
        {
            UC_GoiMon u = new UC_GoiMon();
            u.TaoDSban();
        }
        public frmMain(string MaQuyen)
        {
            _MaQuyen = MaQuyen;
            init();
        }
        private void init()
        {
            InitializeComponent();
            if (_MaQuyen != null)
            {
                PhanQuyen(_MaQuyen);
            }
            else { anAllChucNang(menuStrip1.Items); }
        }
        public void PhanQuyen(string maQuyen)
        {
            if (maQuyen == "all") { hienAllChucNang(menuStrip1.Items);return; }
            List<Quyen_ManHinh> DMManHinhs =  xuLyQuyenManHinh.layDMManHinh(maQuyen);
            List<string> maManHinhs = new List<string>();
            foreach (Quyen_ManHinh item in DMManHinhs)
            {
                if (item.MaQuyen.Trim().Equals(maQuyen.Trim()))
                {
                    maManHinhs.Add(item.MaDM);
                }
            }
          
            if (maManHinhs.Count == 0) { anAllChucNang(menuStrip1.Items); }

            ToolStripItemCollection items = menuStrip1.Items;
            // Duyệt qua từng phần tử trong danh sách
            foreach (ToolStripItem item in items)
            {
                // Kiểm tra nếu là ToolStripMenuItem
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;

                    // Lấy danh sách các phần tử con của ToolStripMenuItem
                    ToolStripItemCollection subItems = menuItem.DropDownItems;

                    // Duyệt qua từng phần tử con
                    foreach (ToolStripItem subItem in subItems)
                    {
                        if (subItem.Tag != null)
                        {
                            string nameItem = subItem.Tag.ToString();
                            if (maManHinhs.Contains(nameItem))
                            {
                                subItem.Visible = true;
                            }
                            else
                            {
                                subItem.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        public List<ManHinh> getAllManHinh()
        {
            ToolStripItemCollection items = menuStrip1.Items;
            List<ManHinh> manhinhs = new List<ManHinh>();
            foreach(ToolStripItem item in items)
            {
                if(item is ToolStripItem)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                    ToolStripItemCollection subItems = menuItem.DropDownItems;
                    foreach (ToolStripMenuItem subitem in subItems)
                    {
                        if (subitem.Tag != null)
                        {
                            ManHinh m = new ManHinh();
                            m.maDM = subitem.Tag.ToString();
                            m.tenDM = subitem.Text;
                            manhinhs.Add(m);
                        }
                        else
                        {
                            subitem.Tag = Librari.createMaManHinh();
                            ManHinh m = new ManHinh();
                            m.maDM = subitem.Tag.ToString();
                            m.tenDM = subitem.Text;
                            manhinhs.Add(m);
                        }
                    }
                }
            }
            return manhinhs;
        }
        private void anAllChucNang(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                // Kiểm tra nếu là ToolStripMenuItem
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                    ToolStripItemCollection subitems = menuitem.DropDownItems;
                    foreach(ToolStripItem sunitem in subitems)
                    {
                        sunitem.Visible = false;
                    }
                }
            }
        }
        private void hienAllChucNang(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                // Kiểm tra nếu là ToolStripMenuItem
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                    ToolStripItemCollection subitems = menuitem.DropDownItems;
                    foreach (ToolStripItem subItem in subitems)
                    {
                        subItem.Visible = true;
                    }
                }
            }
        }
        private void onChucNang(ToolStripItem item)
        {
            item.Visible = false;
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

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program._frm_DangNhap.Visible = true;
            this.Visible = false;
        }

        private void quảnLýQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_QuanLyQuyen u = new UC_QuanLyQuyen();
            LoadUC(u);
        }

        private void quyềnHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_Quyen_ManHinh u = new UC_Quyen_ManHinh();
            LoadUC(u);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void caLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ChamCong u = new UC_ChamCong();
            LoadUC(u);
        }

        private void khuyếnMãiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UC_KhuyenMai u = new UC_KhuyenMai();
            LoadUC(u);
        }

        private void tínhLươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_TinhLuongNhanVien u = new UC_TinhLuongNhanVien();
            LoadUC(u);
        }

        private void caLàmViệcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UC_CaLamViec u = new UC_CaLamViec();
            LoadUC(u);
        }
    }
}
