using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DB;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyChiTietCaLamViec:BaseXuLy
    {
       public List<ChiTietCaLamNhanvien> getAllChiTietCaLam()
        {
            return ctx.ChiTietCaLamNhanviens.ToList();
        }
        public int Them(ChiTietCaLamNhanvien c)
        {
            try
            {
                ctx.ChiTietCaLamNhanviens.InsertOnSubmit(c);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }

        public int Xoa(string maNV)
        {
            try
            {
                ChiTietCaLamNhanvien c = ctx.ChiTietCaLamNhanviens.Where(m => m.MaNV.Equals(maNV)).FirstOrDefault();
                if (c == null) { return 0; }
                ctx.ChiTietCaLamNhanviens.DeleteOnSubmit(c);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int Sua(ChiTietCaLamNhanvien k)
        {
            try
            {
                ChiTietCaLamNhanvien temp = ctx.ChiTietCaLamNhanviens.Where(m => m.MaNV.Equals(k.MaNV)).FirstOrDefault();
                if (temp != null)
                {
                    temp.MaCLV = k.MaCLV;
                    temp.MaNV = k.MaNV;
                    temp.NgayVaoLam = k.NgayVaoLam;
                    temp.NgayTanLam = k.NgayTanLam;
                    temp.Thanhtien = k.Thanhtien;
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public bool KT_TonTai(string clv)
        {
            try
            {
                ChiTietCaLamNhanvien kh = ctx.ChiTietCaLamNhanviens.Where(m => m.MaCLV.Equals(clv)).FirstOrDefault();
                if (kh != null) { return true; }
                return false;
            }
            catch { return false; }
        }
    }
}
