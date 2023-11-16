using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Core;
using BLL.DB;

namespace GUI.UControl
{
    public partial class UC_ThongKe : UserControl
    {
        XuLyThongKe xl_ThongKe = new XuLyThongKe();
        DieuKienThongKeModel.DSDieuKien ds = new DieuKienThongKeModel.DSDieuKien();
        public UC_ThongKe()
        {
            InitializeComponent();
            DateTime time = DateTime.Parse("2023-11-12");
        }
        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            cbxDieuKien.DataSource = ds._danhSachDieuKien;
            cbxDieuKien.DisplayMember = "TenDK";
            cbxDieuKien.ValueMember = "MaDK";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_TK_DanhMuc_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string MaDK = cbxDieuKien.SelectedValue.ToString();
            List<TK_DoanhThuModel> result = xl_ThongKe.getDoanhThuTheo_Ma_DoanhThu(int.Parse(MaDK));
            if (result == null)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            else { dataGridView1.DataSource = result; }
            txtTongSanPham.Text = xl_ThongKe.getTongSlSP(result).ToString();
            txtTongDoanhThu.Text = xl_ThongKe.getTongDoanhThu(result).ToString("N0") + "đ";
            txtTongGiamGia.Text = xl_ThongKe.getTongGiamGia(result).ToString("N0") + "đ";
            txtTongKH.Text = xl_ThongKe.geSLKH(result).ToString();
        }
    }
}
