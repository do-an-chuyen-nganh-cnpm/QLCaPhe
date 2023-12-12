using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyKhachHang:BaseXuLy
    {
        public KHACHHANG timKhachHangBySDT(string sdt)
        {
            try
            {

                List<KHACHHANG> khachHangs = ctx.KHACHHANGs.ToList();
                if (khachHangs == null) { return null; }
                foreach (KHACHHANG kh in khachHangs)
                {
                    if (!String.IsNullOrEmpty(kh.SoDT))
                    {
                        if (kh.SoDT.Trim().Equals(sdt.Trim()))
                        {
                            return kh;
                        }
                    }
                }
                return null;
            }
            catch { return null; }
        }
        public int ThemKH (KHACHHANG kh)
        {
            try
            {
                ctx.KHACHHANGs.InsertOnSubmit(kh);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public List<KHACHHANG> getAllKhachHang()
        {
            try
            {
                return ctx.KHACHHANGs.ToList();
            }
            catch { return null; }
          
        }
        public List<LoaiKhachHang> getAllLoaiKhachHang()
        {
            return ctx.LoaiKhachHangs.ToList();
        }
        public int XoaKH(string MaKH)
        {
            try
            {
                KHACHHANG kh = ctx.KHACHHANGs.Where(m => m.MaKH.Equals(MaKH)).FirstOrDefault();
                if (kh == null) { return 0; }
                ctx.KHACHHANGs.DeleteOnSubmit(kh);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int SuaKH(KHACHHANG k)
        {
            try
            {
                KHACHHANG temp = ctx.KHACHHANGs.Where(m => m.MaKH.Equals(k.MaKH)).FirstOrDefault();
                if (temp != null)
                {
                    temp.MaKH = k.MaKH;
                    temp.TenKH = k.TenKH;
                    temp.MaLoaiKH = k.MaLoaiKH;
                    temp.DiaChi = k.DiaChi;
                    temp.SoDT = k.SoDT;
                    temp.DiemTL = k.DiemTL;
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public bool KT_TonTai(string maKH)
        {
            try
            {
                KHACHHANG kh = ctx.KHACHHANGs.Where(m => m.MaKH.Equals(maKH)).FirstOrDefault();
                if (kh != null) { return true; }
                return false;
            }
            catch { return false; }
        }
    }
}
