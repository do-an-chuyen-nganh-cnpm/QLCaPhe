using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyLoaiSanPham:BaseXuLy
    {
        public List<LoaiSP> getAll()
        {
            try
            {
            return     ctx.LoaiSPs.ToList();
            }
            catch { return null; }
        }
        public List<LoaiSP> getAllLoaiSP()
        {
            return ctx.LoaiSPs.ToList();
        }

        public bool KT_MaLoaiSP(string ma)
        {
            try
            {
                LoaiSP loaisp = ctx.LoaiSPs.Where(u => u.MaLoaiSP.Equals(ma)).FirstOrDefault();
                if (loaisp != null) { return true; }
                return false;
            }
            catch { return false; }
        }
        public int SuaLoaiSP(LoaiSP loaisp)
        {
            try
            {
                LoaiSP loai = ctx.LoaiSPs.Where(m => m.MaLoaiSP.Equals(loaisp.MaLoaiSP)).FirstOrDefault();
                if (loai != null)
                {
                    loai.TenLoaiSP = loaisp.TenLoaiSP;
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public int ThemLoaiSP(LoaiSP loaisp)
        {
            try
            {
                ctx.LoaiSPs.InsertOnSubmit(loaisp);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int XoaLoaiSP(string maloai)
        {
            try
            {
                LoaiSP loaisp = ctx.LoaiSPs.Where(u => u.MaLoaiSP.Equals(maloai)).FirstOrDefault();
                if (loaisp == null) { return 0; }
                ctx.LoaiSPs.DeleteOnSubmit(loaisp);
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
