using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyCaLamViec_NhanVien:BaseXuLy
    {
        public bool KT_Trung(string maCaLam, string maNhanVien, DateTime ngayVaoLam)
        {
            ChiTietCaLamNhanvien ct_cl= ctx.ChiTietCaLamNhanviens.FirstOrDefault(
                v => v.MaCLV.Trim().Equals(maCaLam.Trim()) &&
                v.MaNV.Trim().Equals(maNhanVien.Trim()) &&
                v.NgayVaoLam == ngayVaoLam
                );
            if(ct_cl == null)
            {
                return false;
            }
            return true ;
        }
        public int Them (ChiTietCaLamNhanvien ct_CaLamNV)
        {
            try
            {
                if (ct_CaLamNV == null) { return 0; }
                bool checkTrung = KT_Trung(ct_CaLamNV.MaCLV, ct_CaLamNV.MaNV, ct_CaLamNV.NgayVaoLam);
                if (checkTrung == false)
                {
                    ctx.ChiTietCaLamNhanviens.InsertOnSubmit(ct_CaLamNV);
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public int xoa(ChiTietCaLamNhanvien ctcl)
        {
            try
            {
               ChiTietCaLamNhanvien ct = ctx.ChiTietCaLamNhanviens.FirstOrDefault(
               v => v.MaCLV.Trim().Equals(ctcl.MaCLV.Trim()) &&
               v.MaNV.Trim().Equals(ctcl.MaNV.Trim()) &&
               v.NgayVaoLam.Date == ctcl.NgayVaoLam.Date
               );
                if (ct == null) { return 0; }
                ctx.ChiTietCaLamNhanviens.DeleteOnSubmit(ct);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
    }
}
