using BLL.DB;
using Syncfusion.XlsIO.Implementation.PivotAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyCaLamViec:BaseXuLy
    {
        public double Lay_Tien_CaLam(string maCaLam)
        {
            CaLamViec clv = ctx.CaLamViecs.FirstOrDefault(v => v.MaCLV.Trim().Equals(maCaLam.Trim()));
            if (clv == null)
            {
                return 0;
            }
          return  clv.SoTien.Value;
        }
        public List<CaLamViec> getAll()
        {
            try
            {
                return ctx.CaLamViecs.ToList();
            }
            catch { return null; }
        }
        public bool KT_TrungCaLam(string maCaLam)
        {
            List<CaLamViec> listCaLam = ctx.CaLamViecs.ToList();
            CaLamViec  clv = listCaLam.FirstOrDefault(v=> v.MaCLV.Trim().Equals(maCaLam.Trim()));
            if(clv == null) { return false; }
            return true;
        }
        public int themCaLam(CaLamViec calam)
        {
            try
            {
                if (calam == null)
                {
                    return 0;
                }
                if (KT_TrungCaLam(calam.MaCLV)) { return 0; }
                ctx.CaLamViecs.InsertOnSubmit(calam);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int XoaCaLamViec(string maCaLam)
        {
            try
            {
                if (String.IsNullOrEmpty(maCaLam))
                {
                    return 0;
                }
                if (KT_TrungCaLam(maCaLam)==false) { return 0; }
                CaLamViec clv = ctx.CaLamViecs.FirstOrDefault(v => v.MaCLV.Trim().Equals(maCaLam.Trim()));
                if(clv == null) { return 0; }
                ctx.CaLamViecs.DeleteOnSubmit(clv);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int CapNhatCaLamViec(CaLamViec clv)
        {
            try
            {
                if (clv == null)
                {
                    return 0;
                }
                CaLamViec calam = ctx.CaLamViecs.FirstOrDefault(v => v.MaCLV.Trim().Equals(clv.MaCLV.Trim()));
                if (calam == null) { return 0; }
                calam.TenCLV = clv.TenCLV;
                calam.SoTien = clv.SoTien;
                calam.MaCLV = clv.MaCLV;
                calam.GioBD = clv.GioBD;
                calam.GioKT = clv.GioKT;
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int ThemCaLamViec(CaLamViec c)
        {
            try
            {
                ctx.CaLamViecs.InsertOnSubmit(c);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public List<CaLamViec> getAllCaLamViec()
        {
            try
            {
                return ctx.CaLamViecs.ToList();
            }
            catch { return null; }

        }
        public int SuaCaLamViec(CaLamViec k)
        {
            try
            {
                CaLamViec temp = ctx.CaLamViecs.Where(m => m.MaCLV.Equals(k.MaCLV)).FirstOrDefault();
                if (temp != null)
                {
                    temp.MaCLV = k.MaCLV;
                    temp.TenCLV = k.TenCLV;
                    temp.GioBD = k.GioBD;
                    temp.GioKT = k.GioKT;
                    temp.SoTien = k.SoTien;
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public bool KT_TonTai(string maCa)
        {
            try
            {
                CaLamViec kh = ctx.CaLamViecs.Where(m => m.MaCLV.Equals(maCa)).FirstOrDefault();
                if (kh != null) { return true; }
                return false;
            }
            catch { return false; }
        }
    }
}
