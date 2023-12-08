using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyLoaiKhachHang:BaseXuLy
    {
        public List<LoaiKhachHang> getAll()
        {
            try
            {
                return ctx.LoaiKhachHangs.ToList();
            }
            catch { return null; }
        }
    }
}
