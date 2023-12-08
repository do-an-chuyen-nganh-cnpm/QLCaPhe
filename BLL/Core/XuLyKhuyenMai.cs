using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyKhuyenMai
    {
        QLCapheDataContext ctx = new QLCapheDataContext();
        public List<KHUYEN_MAI> getAllKhuyenMai()
        {
            return ctx.KHUYEN_MAIs.ToList();
        }
        public int SuaKhuyeMai (KHUYEN_MAI k)
        {
            try
            {
                //KHUYEN_MAI temp = ctx.KHUYEN_MAIs.Where(m => m.MAKHUYENMAI.Equals(k.MAKHUYENMAI)).FirstOrDefault();
                //if (temp != null)
                //{
                //    temp.MAKHUYENMAI = k.MAKHUYENMAI;
                //    temp.TENKHUYENMAI = k.TENKHUYENMAI;
                //    temp.MOTA = k.MOTA;
                //    temp.NGAYBD = k.NGAYBD;
                //    temp.NGAYKT = k.NGAYKT;
                //    temp.TRIGIA = k.TRIGIA;
                //    ctx.KHUYEN_MAIs.InsertOnSubmit(k);
                //    ctx.SubmitChanges();
                //    return 1;
                //}
                return 0;
            }
            catch { return 0; }          
        }
        public int ThemKhuyenMai (KHUYEN_MAI k)
        {
            try
            {
                ctx.KHUYEN_MAIs.InsertOnSubmit(k);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
           
        }
        public int XoaKhuyenMai(string MaKhuyenMai)
        {
            try
            {
            //    KHUYEN_MAI khuyenMai = ctx.KHUYEN_MAIs.Where(m => m.MAKHUYENMAI.Equals(MaKhuyenMai)).FirstOrDefault();
            //    if (khuyenMai == null) { return 0; }
            //    ctx.KHUYEN_MAIs.DeleteOnSubmit(khuyenMai);
            //    ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool KT_TonTai(string maKhuyenMai)
        {
            try {
                //KHUYEN_MAI k = ctx.KHUYEN_MAIs.Where(m => m.MAKHUYENMAI.Equals(maKhuyenMai)).FirstOrDefault();
                //if(k != null) { return true; }
                return false;
            }
            catch { return false; }
        }
    }
}
