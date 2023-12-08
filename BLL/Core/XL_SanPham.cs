using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public  class XL_SanPham:BaseXuLy
    {
        public List<SanPham> getAllSP()
        {
            return ctx.SanPhams.ToList();
        }

        public bool KT_MaSP(string ma)
        {
            try
            {
               SanPham  sp = ctx.SanPhams.Where(u => u.MaSP.Equals(ma)).FirstOrDefault();
                if (sp!= null) { return true; }
                return false;
            }
            catch { return false; }
        }
        public int SuaSanPham(SanPham sanPham)
        {
            try
            {
                SanPham sp = ctx.SanPhams.Where(m => m.MaSP.Equals(sanPham.MaSP)).FirstOrDefault();
                if (sp != null)
                {
                    // Kiểm tra xem có sự thay đổi không trước khi cập nhật
                    if (sp.TenSP != sanPham.TenSP || sp.GiaSP != sanPham.GiaSP || sp.HinhAnh != sanPham.HinhAnh || sp.MaLoaiSP != sanPham.MaLoaiSP)
                    {
                        sp.TenSP = sanPham.TenSP;
                        sp.GiaSP = sanPham.GiaSP;
                        sp.HinhAnh = sanPham.HinhAnh;
                        sp.MaLoaiSP = sanPham.MaLoaiSP;
                        ctx.SubmitChanges();
                        return 1;
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int ThemSanPham(SanPham sp)
        {
            try
            {
                ctx.SanPhams.InsertOnSubmit(sp);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int XoaSanPham(string masp)
        {
            try
            {
                SanPham sp = ctx.SanPhams.Where(u => u.MaSP.Equals(masp)).FirstOrDefault();
                if (sp == null) { return 0; }
                ctx.SanPhams.DeleteOnSubmit(sp);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
