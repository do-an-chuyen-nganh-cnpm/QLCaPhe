using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLySanPham:BaseXuLy
    {
        public List<SanPham> getAllSP()
        {
            try
            {
                return ctx.SanPhams.ToList();
            }
            catch { return null; }
            
        }
        public List<SanPham> laySanPham()
        {
            try
            {
                return ctx.SanPhams.ToList();
            }
            catch { return null; }
        }
       
        public List<SanPham> laySanPhamByMaLoai(string maLoai)
        {
            try
            {
                return ctx.SanPhams.Where(m =>m.MaLoaiSP.Trim().Equals(maLoai)).ToList();
            }
            catch { return null; }
        }
        public SanPham laySanPham(string maSP)
        {
            try
            {
                return ctx.SanPhams.FirstOrDefault(m => m.MaSP.Trim().Equals(maSP));
            }
            catch { return null; }
        }
        public string layTenSP(string masp)
        {
            List<SanPham> list = getAllSP();
            if(list == null) { return ""; }
            SanPham tensp = list.FirstOrDefault(m => m.MaSP.Trim().Equals(masp.Trim()));
            return tensp.TenSP;
        }
    }
}
