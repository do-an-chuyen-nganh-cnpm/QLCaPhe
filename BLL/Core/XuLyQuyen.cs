using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyQuyen:BaseXuLy
    {
        public List<QUYEN> LayTatCa() {
            try
            {
                List<QUYEN> result = ctx.QUYENs.ToList();
                return result;
            }
            catch { return null; }
        }
        public bool KT_TonMa(string ma)
        {
            QUYEN result = ctx.QUYENs.FirstOrDefault(v => v.MaQuyen.Trim().Equals(ma));
            if (result != null)
            {
                return true;
            }
            return false;
        }
        public int Them(QUYEN q)
        {
            try
            {
                if(q == null) { return 0; }
                ctx.QUYENs.InsertOnSubmit(q);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Xoa(string maQuyen)
        {
            try
            {
                if (String.IsNullOrEmpty(maQuyen)) { return 0; }
                QUYEN quyen = ctx.QUYENs.FirstOrDefault(v => v.MaQuyen.Trim().Equals(maQuyen.Trim()));
                if (quyen == null) { return 0; }
                ctx.QUYENs.DeleteOnSubmit(quyen);
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public int Sua(QUYEN quyen)
        {
            try
            {
                if (quyen==null) { return 0; }
                QUYEN temp = ctx.QUYENs.FirstOrDefault(v => v.MaQuyen.Trim().Equals(quyen.MaQuyen.Trim()));
                if (temp == null) { return 0; }
                temp.MaQuyen = quyen.MaQuyen;
                temp.TenQuyen = quyen.TenQuyen;
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
    }
}
