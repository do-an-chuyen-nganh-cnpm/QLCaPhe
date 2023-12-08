using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyTrangThaiBan:BaseXuLy
    {
        public List<TRANGTHAIBAN> getAllTrangThai()
        {
            return ctx.TRANGTHAIBANs.ToList();
        }
        public string layTenTrangThai(string maTrangThai)
        {
            List<TRANGTHAIBAN> list = getAllTrangThai();
            TRANGTHAIBAN t = list.FirstOrDefault(m => m.MaTrangThai.Trim().Equals(maTrangThai.Trim()));
            return t.TenTrangThai;
        }
        public string layMaTrangThai(string tenTrangThai)
        {
            List<TRANGTHAIBAN> list = getAllTrangThai();
            TRANGTHAIBAN t = list.FirstOrDefault(m => m.TenTrangThai.Trim().Equals(tenTrangThai.Trim()));
            return t.MaTrangThai;
        }
    }
}
