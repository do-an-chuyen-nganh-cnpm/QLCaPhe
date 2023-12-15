using BLL;
using BLL.Core;
using BLL.DB;
using GUI.Frm;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;

namespace GUI.Report
{
    public partial class frmHoaDon : Form
    {
        private string maHD;
        private NHANVIEN nv = frm_DangNhap.nvDangSuDung;
        private string tenNV;
        //
        XuLyHoaDon xulyHoaDon = new XuLyHoaDon();
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        XuLySanPham xuLySanPham = new XuLySanPham();
        public frmHoaDon()
        {
            Init();
        }
        public frmHoaDon(string maHD)
        {
            Init();
            this.maHD = maHD;
        }
        public void Init()
        {
            InitializeComponent();
            tenNV = nv.TenNV;
        }
        private List<rpt_HoaDon> getHoaDon(string maHD)
        {
            HoaDon hd = xulyHoaDon.LayHoaDon(maHD);
            List<rpt_HoaDon> rpthds = new List<rpt_HoaDon>();
            KHACHHANG kh = xuLyKhachHang.layKhachHang(hd.MaKH);
            rpt_HoaDon hoadon = new rpt_HoaDon();
            if (kh != null)
            {
                hoadon.TenKH = xuLyKhachHang.layTenKH(hd.MaKH);
                hoadon.soDienThoai = kh.SoDT;
            }
            hoadon.TenBan = hd.MaBan;
            hoadon.MaHD = hd.MaHD;
            hoadon.ThuNgan = tenNV;
            hoadon.ngayThu = DateTime.Today.ToString("dd/MM/yyyy");
            hoadon.TongTien =Librari.ConvertFormatTien( hd.TongTien.Value);
            hoadon.giamGia =Librari.ConvertFormatTien( hd.Giamgia.Value);
            hoadon.thanhToan =Librari.ConvertFormatTien( (hd.TongTien.Value - hd.Giamgia.Value));
            rpthds.Add(hoadon);
            return rpthds;
        }
        public List<rpt_SanPham> getSanPham(string maHD)
        {
            List<ChiTietHoaDon> cthds = xuLyChiTietHoaDon.LayChiTietHoaDon(maHD);
            List<rpt_SanPham> result = new List<rpt_SanPham>();
            if (cthds.Count > 0)
            {
                foreach (ChiTietHoaDon chitiethoadon in cthds)
                {
                    rpt_SanPham sp = new rpt_SanPham();
                    sp.tenSanPham = xuLySanPham.layTenSP(chitiethoadon.MaSP);
                    sp.donGia =Librari.ConvertFormatTien(chitiethoadon.DonGia.Value);
                    sp.soluong = chitiethoadon.SoLuong.ToString();
                    sp.thanhTien =Librari.ConvertFormatTien( chitiethoadon.TongTien.Value);
                    result.Add(sp);
                }
            }
            return result;
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            List<rpt_HoaDon> hd = new List<rpt_HoaDon>();
            List<rpt_SanPham> sanphams = new List<rpt_SanPham>();
            for(int i =0; i<sanphams.Count; i++)
            {
                sanphams[i].STT = (i + 1).ToString();
            }
            hd = getHoaDon(maHD);
            sanphams = getSanPham(maHD);
            var hoadon = new ReportDataSource("DataSet1", hd);
            var sanpham = new ReportDataSource("DataSet2", sanphams);
            string filepath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + "\\Report\\rpt_HoaDon.rdlc";
            reportViewer1.LocalReport.ReportPath = filepath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(hoadon);
            reportViewer1.LocalReport.DataSources.Add(sanpham);
            this.reportViewer1.RefreshReport();
        }
    }
}
