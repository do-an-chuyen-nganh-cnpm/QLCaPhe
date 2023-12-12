using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyHoaDon:BaseXuLy
    {
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        public List<HoaDon> LayTatCaHoaDon()
        {
            return ctx.HoaDons.ToList();
        }
        public HoaDon LayHoaDon(string MaHD)
        {
            try
            {
                List<HoaDon> listHD = LayTatCaHoaDon();
                HoaDon hd = listHD.FirstOrDefault(v => v.MaHD.Trim().Equals(MaHD.Trim()));
                return hd;
            }
            catch { return null; }
        }
        public HoaDon LayHoaDon(string maBan, string TrangThai)
        {
            List<HoaDon> listHD = LayTatCaHoaDon();
            HoaDon hd = listHD.FirstOrDefault(v => v.MaBan.Trim().Equals(maBan.Trim()) && v.TrangThai.Equals(TrangThai));
            return hd;
        }
        public HoaDon TimKiem(string maHD)
        {
            if(maHD=="" || String.IsNullOrEmpty(maHD)) { return null; }
            List<HoaDon> hd = ctx.HoaDons.ToList();
            HoaDon result = hd.FirstOrDefault(m => m.MaHD.Trim().Equals(maHD.Trim()));
            return result;
        }
        public HoaDon TimKiem(string maHD, string maBan)
        {
            List<HoaDon> hd = ctx.HoaDons.ToList();
            HoaDon result = hd.FirstOrDefault(m => m.MaHD.Trim().Equals(maHD.Trim()) && m.MaBan.Trim().Equals(maBan.Trim()));
            return result;
        }
        public HoaDon TimKiemTheo_MaBan( string maBan)
        {
            List<HoaDon> hd = ctx.HoaDons.ToList();
            HoaDon result = hd.FirstOrDefault(m => m.MaHD.Trim().Equals(maBan.Trim()));
            return result;
        }
        public int Them(HoaDon hoadon)
        {
            try
            {
                if (hoadon == null) { return 0; }
                ctx.HoaDons.InsertOnSubmit(hoadon);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Xoa(string maHoaDon)
        {
            try
            {
                if (String.IsNullOrEmpty(maHoaDon)) { return 0; }
                HoaDon hd = ctx.HoaDons.FirstOrDefault(m => m.MaHD.Trim().Equals(maHoaDon.Trim()));
                if (hd == null) { return 0; }
                ctx.HoaDons.DeleteOnSubmit(hd);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Sua (HoaDon hoadon)
        {
            try
            {
                if (hoadon == null) { return 0; }
                HoaDon hd = ctx.HoaDons.FirstOrDefault(m => m.MaHD.Trim().Equals(hoadon.MaHD.Trim()));
                hd.MaHD = hoadon.MaHD;
                hd.MaNV = hoadon.MaNV;
                hd.MaKH = hoadon.MaKH;
                hd.MaBan = hoadon.MaBan;
                hd.NgayLap = hoadon.NgayLap;
                hd.TongTien = hoadon.TongTien;
                hd.DiemTL = hoadon.DiemTL;
                hd.Giamgia = hoadon.Giamgia;
                hd.TrangThai = hoadon.TrangThai;
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
     
       
        public int ThanhToan(KHACHHANG kh, string maHD, float diemTL, float giamGia)
        {
            try
            {
                //tạo mới khách hàng 
                bool ktMaKH = xuLyKhachHang.KT_TonTai(kh.MaKH);
                if (ktMaKH == false)
                {
                    int kqThemKH = xuLyKhachHang.ThemKH(kh);
                    if (kqThemKH == 0) { return 0; }
                }
                //cập nhật khách hàng cho hóa đơn
                HoaDon hd = ctx.HoaDons.FirstOrDefault(v => v.MaHD.Trim().Equals(maHD.Trim()));
                if (hd == null)
                {
                    return 0;
                }
                //cập nhật mã khách hàng cho hóa đơn
                hd.MaKH = kh.MaKH;
                hd.DiemTL = diemTL;
                hd.Giamgia = giamGia;
                //cập nhật trạng thái hóa đơn đã thanh toán 
                hd.TrangThai = "đã thanh toán";
                //cập nhật trạng thái bàn
                string maban = hd.MaBan;
                BAN b = ctx.BANs.FirstOrDefault(v => v.MaBan.Trim().Equals(maban.Trim()));
                if (b == null) { return 0; }//không tìm thấy bàn cần cập nhật 
                b.MaTrangThai = "2";
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
    }
}
