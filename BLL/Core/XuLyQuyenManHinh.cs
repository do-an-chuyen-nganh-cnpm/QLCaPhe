using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyQuyenManHinh:BaseXuLy
    {
        public List<Quyen_ManHinh> layDMManHinh(string maQuyen)
        {
            try
            {
                List<Quyen_ManHinh> result = ctx.Quyen_ManHinhs.ToList();
                return result;
            }
            catch { return null; }
        }
        public int Them(Quyen_ManHinh quyenmh)
        {
            try
            {
                if (quyenmh == null|| KT_TonTai(quyenmh.MaQuyen, quyenmh.MaDM)) { return 0; }                
                ctx.Quyen_ManHinhs.InsertOnSubmit(quyenmh);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Xoa(string maQuyen, string maDM)
        {
            try
            {
                if (String.IsNullOrEmpty(maDM) ||String.IsNullOrEmpty(maQuyen)) { return 0; }
                Quyen_ManHinh quyen = ctx.Quyen_ManHinhs.FirstOrDefault(
                    v => v.MaDM.Trim().Equals(maDM)
                    && v.MaQuyen.Trim().Equals(maQuyen));
                if (quyen != null)
                {
                    ctx.Quyen_ManHinhs.DeleteOnSubmit(quyen);
                    ctx.SubmitChanges();
                    return 1;
                }                
                return 0;
            }
            catch { return 0; }
        }
        public bool KT_TonTai(string maQuyen, string maMH)
        {
            Quyen_ManHinh quyen = ctx.Quyen_ManHinhs.FirstOrDefault(v => v.MaQuyen.Trim().Equals(maQuyen.Trim()) && v.MaDM.Trim().Equals(maMH.Trim()));
            if(quyen != null)
            {
                return true;
            }
            return
                 false;
        }
    }
}
