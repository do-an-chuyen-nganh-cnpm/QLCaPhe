using BLL.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Core
{
    public class XuLyBan:BaseXuLy
    {
        public XuLyBan():base() { }
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        public List<BAN> getAllBan()
        {
            return ctx.BANs.ToList();
        }
        public string LayTrangThaiBan(string maBan)
        {
            BAN ban = getAllBan().FirstOrDefault(m => m.MaBan.Trim().Equals(maBan.Trim()));
            string trangthaiban = xuLyTrangThaiBan.layTenTrangThai(ban.MaTrangThai);
            return trangthaiban;
        }
        public string LayMaBan(string tenBan)
        {
            BAN ban = getAllBan().FirstOrDefault(m => m.TenBan.Trim().Equals(tenBan.Trim()));
            string tt = ban.MaBan;
            return tt;
        }
        public int capNhatTrangThaiBan(string maBan, string maTrangThai) {
            try
            {
                BAN ban = getAllBan().FirstOrDefault(m => m.MaBan.Trim().Equals(maBan.Trim()));
                if (ban == null) { return 0; }
                ban.MaTrangThai = maTrangThai;
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public List<BAN> getAllTable()
        {
            return ctx.BANs.ToList();
        }
        public List<TRANGTHAIBAN> getAllTrangThaiBan()
        {
            return ctx.TRANGTHAIBANs.ToList();
        }

        public int ThemBan(BAN b)
        {
            try
            {
                ctx.BANs.InsertOnSubmit(b);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int XoaBan(string MaBan)
        {
            try
            {
                BAN b = ctx.BANs.Where(m => m.MaBan.Equals(MaBan)).FirstOrDefault();
                if (b == null) { return 0; }
                ctx.BANs.DeleteOnSubmit(b);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int SuaBan(BAN b)
        {
            try
            {
                BAN temp = ctx.BANs.Where(m => m.MaBan.Equals(b.MaBan)).FirstOrDefault();
                if (temp != null)
                {
                    temp.MaBan = b.MaBan;
                    temp.MaTrangThai = b.MaTrangThai;
                    temp.TenBan = b.TenBan;
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
        public bool KT_TonTai(string maBan)
        {
            try
            {
                BAN b = ctx.BANs.Where(m => m.MaBan.Equals(maBan)).FirstOrDefault();
                if (b != null) { return true; }
                return false;
            }
            catch { return false; }
        }
    }
}
