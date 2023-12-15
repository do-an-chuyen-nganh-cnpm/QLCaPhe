using BLL.DB;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
        XuLyBan xuLyBan = new XuLyBan();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
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
        public List<ChiTietHoaDon> LayTatCa()
        {
            return ctx.ChiTietHoaDons.ToList();
        }
        public ChiTietHoaDon LayChiTietHoaDon(string maHD, string masp)
        {
            try
            {
                List<ChiTietHoaDon> list = LayTatCa();
                ChiTietHoaDon cthd = list.FirstOrDefault(v => v.MaHD.Trim().Equals(maHD.Trim()) &&
                v.MaSP.Trim().Equals(masp.Trim()));
                return cthd;
            }
            catch { return null; }
        }
        public List<ChiTietHoaDon> LayChiTietHoaDon(string maHD)
        {
            try
            {
                if (!String.IsNullOrEmpty(maHD))
                {
                    return ctx.ChiTietHoaDons.Where(v => v.MaHD.Trim().Equals(maHD.Trim())).ToList();
                }
                return null;

            }
            catch { return null; }
        }
        public bool KT_TrungChiTiet(string mahd, string masp)
        {
            List<ChiTietHoaDon> list = LayTatCa();
            ChiTietHoaDon ct = list.FirstOrDefault(
                v => v.MaHD.Trim().Equals(mahd.Trim()) &&
            v.MaSP.Trim().Equals(masp.Trim())
            );
            if (ct == null) { return false; }
            return true;
        }
        public int Them_CTHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                ctx.ChiTietHoaDons.InsertOnSubmit(chiTietHoaDon);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Xoa_CTHoaDon(string maHD, string masp)
        {
            try
            {
                ChiTietHoaDon cthd = ctx.ChiTietHoaDons.FirstOrDefault
                    (
                    v => v.MaHD.Trim().Equals(maHD.Trim()) &&
                    v.MaSP.Trim().Equals(masp.Trim())
                    );
                ctx.ChiTietHoaDons.DeleteOnSubmit(cthd);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Xoa_AllCTHoaDon(string maHD)
        {
            try
            {
                List<ChiTietHoaDon> cthds = ctx.ChiTietHoaDons.Where(v => v.MaHD.Trim().Equals(maHD.Trim())).ToList();
                if(cthds != null && cthds.Count > 0)
                {
                    ctx.ChiTietHoaDons.DeleteAllOnSubmit(cthds);
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public int Sua_CTHoaDon(ChiTietHoaDon cthd)
        {
            try
            {
                ChiTietHoaDon c = ctx.ChiTietHoaDons.FirstOrDefault
                    (
                    v => v.MaHD.Trim().Equals(cthd.MaHD.Trim()) &&
                    v.MaSP.Trim().Equals(cthd.MaSP.Trim())
                    );
                c.MaHD = cthd.MaHD;
                c.DonGia = cthd.DonGia;
                c.MaSP = cthd.MaSP;
                c.SoLuong = cthd.SoLuong;
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int GopBan(List<string> DSMaHD, List<string> DS_MaBan, string maHoaDonChinh, string MaBanChinh)
        {
            try
            {
                List<ChiTietHoaDon> listHoaDonBanChinh = new List<ChiTietHoaDon>();
                // lấy những chi tiết hóa đơn không phải của hóa đơn chính
                foreach (string mahd in DSMaHD)
                {
                    if (!maHoaDonChinh.Trim().Equals(mahd.Trim()))
                    {
                        // thực hiện chuyển về hóa đơn chính
                        List<ChiTietHoaDon> listChiTietHoaDon = LayChiTietHoaDon(mahd);
                        if (listChiTietHoaDon.Count > 0)
                        {
                            foreach (ChiTietHoaDon cthd in listChiTietHoaDon)
                            {
                                ChiTietHoaDon c = new ChiTietHoaDon();
                                c = cthd;
                                listHoaDonBanChinh.Add(c);
                            }
                        }
                    }
                }
                //thềm vào hóa đơn chính
                if (listHoaDonBanChinh != null && listHoaDonBanChinh.Count > 0)
                {
                    foreach (ChiTietHoaDon cthd in listHoaDonBanChinh)
                    {
                        ChiTietHoaDon ct = LayChiTietHoaDon(maHoaDonChinh, cthd.MaSP);
                        if (ct != null)
                        {
                            //trùng tăng số lượng
                         int sl =   ct.SoLuong.Value + cthd.SoLuong.Value;
                          int kq=  xuLyChiTietHoaDon.capNhatSL(ct.MaSP,maHoaDonChinh, sl);
                        }
                        else
                        {
                            ChiTietHoaDon _cthd = new ChiTietHoaDon();
                            _cthd.MaHD = maHoaDonChinh;
                            _cthd.MaSP = cthd.MaSP;
                            _cthd.DonGia = cthd.DonGia;
                            _cthd.SoLuong = cthd.SoLuong;
                            themChiTietHoaDon(_cthd);
                            //thêm mới
                        }
                    }
                }
                foreach(string mahd in DSMaHD)
                {
                    if (!mahd.Equals(maHoaDonChinh))
                    {
                        Xoa_AllCTHoaDon(mahd);
                    }
                }
                // cập nhật lại trạng thái cho bàn không phải bàn chính thành trạng thái trống
                foreach (string maban in DS_MaBan)
                {
                    if (!maban.Trim().Equals(MaBanChinh.Trim()))
                    {
                        xuLyBan.capNhatTrangThaiBan(maban, xuLyBan.maTrangThaiTrong);
                    }
                }
                return 1;
            }
            catch { return 0; }
           
        }
        public int themChiTietHoaDon(ChiTietHoaDon ct_HD) 
        {
            try
            {
                if (ct_HD != null)
                {
                    ctx.ChiTietHoaDons.InsertOnSubmit(ct_HD);
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
    }
}
