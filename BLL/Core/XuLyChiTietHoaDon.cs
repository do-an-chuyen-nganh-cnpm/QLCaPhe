using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyChiTietHoaDon:BaseXuLy
    {     
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
        public List< ChiTietHoaDon> LayChiTietHoaDon(string maHD)
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
        public int Them_CTHoaDon (ChiTietHoaDon chiTietHoaDon)
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
    }
}
