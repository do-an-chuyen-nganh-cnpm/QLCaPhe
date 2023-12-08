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
    }
}
