using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Core;
using BLL.DB;

namespace GUI.UControl
{
    public partial class UC_ThongKe : UserControl
    {
        XuLyThongKe xl_ThongKe = new XuLyThongKe();
        DieuKienThongKeModel.DSDieuKien ds = new DieuKienThongKeModel.DSDieuKien();
        DataTable dataTabletThongKe;
        List<TK_DoanhThuModel> listTKModel;
        private string tk_col_NgayLap="Ngày Lập";
        private string tk_col_MAHD="Mã hóa đơn";
        private string TK_col_MaNV="Mã Nhân viên";
        private string TK_col_MaKH = "Mã Khách Hàng";
        private string TK_col_MaBan = "Mã Bàn";
        private string TK_col_MaSP = "Mã sản phẩm";
        private string TK_col_TenSP = "Tên sản phẩm";
        private string TK_col_TongTien = "Tổng tiền";
        private string TK_col_DiemTL = "Diển tích lũy"; 
        private string TK_col_Giamgia = "Giảm giá";
        private string TK_col_SoLuong = "Số lượng";
        private string TK_col_ThanhTien = "Thành tiền";
        public UC_ThongKe()
        {
            InitializeComponent();
            DateTime time = DateTime.Parse("2023-11-12");
            KhoiTaoDataTable();
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
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string MaDK = cbxDieuKien.SelectedValue.ToString();
            List<TK_DoanhThuModel> result = xl_ThongKe.getDoanhThuTheo_Ma_DoanhThu(int.Parse(MaDK));
            if (result == null)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            else
            {
                listTKModel = result;
                ThemDuLieuDataGridView(result);
            }
            txtTongSanPham.Text = xl_ThongKe.getTongSlSP(result).ToString();
            txtTongDoanhThu.Text = xl_ThongKe.getTongDoanhThu(result).ToString("N0") + "đ";
            txtTongGiamGia.Text = xl_ThongKe.getTongGiamGia(result).ToString("N0") + "đ";
            txtTongKH.Text = xl_ThongKe.geSLKH(result).ToString();
        }
        private void KhoiTaoDataTable()
        {
            dataTabletThongKe = new DataTable();
            dataTabletThongKe.Columns.Add(tk_col_NgayLap, typeof(string));
            dataTabletThongKe.Columns.Add(tk_col_MAHD, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_MaNV, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_MaKH, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_MaBan, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_MaSP, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_TenSP, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_TongTien, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_DiemTL, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_Giamgia, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_SoLuong, typeof(string));
            dataTabletThongKe.Columns.Add(TK_col_ThanhTien, typeof(string));
    }
        private void ThemDuLieuDataGridView (List<TK_DoanhThuModel> lst)
        {
            KhoiTaoDataTable();
            foreach(TK_DoanhThuModel item in lst)
            {
                ThemDuLieuDataGridView(item);
            }
            DGV_ThongKe.DataSource = dataTabletThongKe;
        }
        private void ThemDuLieuDataGridView(TK_DoanhThuModel tk)
        {
            DataRow row = dataTabletThongKe.NewRow();
            row[tk_col_NgayLap] = tk.NgayLap.ToString("dd/MM/yyyy");
            row[tk_col_MAHD] = tk.MaHD;
            row[TK_col_MaNV] = tk.MaNV;
            row[TK_col_MaKH] = tk.MaKH;
            row[TK_col_MaBan] = tk.MaBan;
            row[TK_col_MaSP] = tk.MaSP;
            row[TK_col_TenSP] = tk.TenSP;
            row[TK_col_TongTien] = tk.TongTien;
            row[TK_col_DiemTL] = tk.DiemTL;
            row[TK_col_Giamgia] = tk.Giamgia;
            row[TK_col_SoLuong] = tk.SoLuong;
            row[TK_col_ThanhTien] = tk.ThanhTien;
            dataTabletThongKe.Rows.Add(row);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          bool kq =  xl_ThongKe.XuatFile(listTKModel);
        if(kq == false) { MessageBox.Show("Dữ liệu sai !"); }
        }
    }
}
