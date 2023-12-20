using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Core
{
    public class XuLyKhuyenMai
    {
        QLCapheDataContext ctx = new QLCapheDataContext();
        public int themKhuyenMaiChoKH(string maKH)
        {
            //thêm khuyến mãi giảm 15% cho những hóa đơn trên 150k
            try
            {
                string maKM = "giam15pt";
                //kiểm tra mã tồn tai chưa
                bool kqKT = KT_TonTai(maKM);
                if (kqKT == false)
                {
                    KHUYEN_MAI km = new KHUYEN_MAI();
                    km.MaKhuyenMai = maKH;
                    km.TenKhuyenMai = "Giảm 15 phần trăm";
                    km.MoTa = "giảm 15 % cho khách hàng có hóa đơn trên 150k";
                    km.NgayBD = DateTime.Parse("10/10/2023");
                    km.NgayKT = DateTime.Parse("1/2/2023");
                    km.phanTramGiamGia = 15;
                    km.TrangThai = "nomal";
                    ThemKhuyenMai(km);
                }
                if (kqKT == true)
                {
                    KhachHang_KhuyenMai kh_km = new KhachHang_KhuyenMai();
                    KhachHang_KhuyenMai check = ctx.KhachHang_KhuyenMais.FirstOrDefault(
                        v => v.MaKhuyenMai.Trim().Equals(maKH.Trim()) &&
                        v.MaKH.Trim().Equals(maKH.Trim())
                        );
                    if(check.MaKhuyenMai!= null) { return 0; }
                    kh_km.MaKhuyenMai = maKH;
                    kh_km.MaKH = maKH;
                    ctx.KhachHang_KhuyenMais.InsertOnSubmit(kh_km);
                    ctx.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
          
        }
        public List<KHUYEN_MAI> getKhuyenMaiByKhachHang(string maKH)
        {
            if (String.IsNullOrEmpty(maKH)) { return null; }
            KHACHHANG kh = ctx.KHACHHANGs.FirstOrDefault(v => v.MaKH.Trim().Equals(maKH.Trim()));
            List<KHUYEN_MAI> khuyenMais = ctx.KHUYEN_MAIs.ToList();
            if (kh == null || kh.MaKH == null)
            {
                return null;
            }
            List<KHUYEN_MAI> result = new List<KHUYEN_MAI>();
            List<KhachHang_KhuyenMai> khachHang_KhuyenMai = new List<KhachHang_KhuyenMai>();
            khachHang_KhuyenMai = ctx.KhachHang_KhuyenMais.Where(v => v.MaKH.Trim().Equals(maKH.Trim())).ToList();
            if (khachHang_KhuyenMai != null && khachHang_KhuyenMai.Count > 0)
            {
                foreach (KHUYEN_MAI khuyenmai in khuyenMais)
                {
                    foreach (KhachHang_KhuyenMai kh_km in khachHang_KhuyenMai)
                    {

                        if (khuyenmai.MaKhuyenMai.Trim().Equals(kh_km.MaKhuyenMai.Trim()))
                        {
                            result.Add(khuyenmai);
                        }
                    }
                }
            }
            return result;
        }
        public KHUYEN_MAI layKhuyenMai (string maKhuyenMai)
        {
            return ctx.KHUYEN_MAIs.FirstOrDefault(v => maKhuyenMai.Trim().Equals(maKhuyenMai.Trim()));
        }
        public List<KHUYEN_MAI> getAllKhuyenMai()
        {
            return ctx.KHUYEN_MAIs.ToList();
        }
        public int SuaKhuyeMai (KHUYEN_MAI k)
        {
            try
            {
                KHUYEN_MAI temp = ctx.KHUYEN_MAIs.Where(m => m.MaKhuyenMai.Trim().Equals(k.MaKhuyenMai.Trim())).FirstOrDefault();
                if (temp != null)
                {
                    temp.MaKhuyenMai = k.MaKhuyenMai;
                    temp.TenKhuyenMai = k.TenKhuyenMai;
                    temp.MoTa = k.MoTa;
                    temp.NgayBD = k.NgayBD;
                    temp.NgayKT = k.NgayKT;
                    temp.phanTramGiamGia = k.phanTramGiamGia;
                    ctx.SubmitChanges();
                    return 1;
                }
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
        public int layPhanTramKhuyenMai(string maKH)
        {
            try
            {
                KHUYEN_MAI kh = ctx.KHUYEN_MAIs.FirstOrDefault(v => v.MaKhuyenMai.Trim().Equals(maKH.Trim()));
                return kh.phanTramGiamGia.Value;
            }
            catch { return 0; }
        }
        public int XoaKhuyenMai(string MaKhuyenMai)
        {
            try
            {
                KHUYEN_MAI khuyenMai = ctx.KHUYEN_MAIs.Where(m => m.MaKhuyenMai.Trim().Equals(MaKhuyenMai.Trim())).FirstOrDefault();
                if (khuyenMai == null) { return 0; }
                ctx.KHUYEN_MAIs.DeleteOnSubmit(khuyenMai);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool check_HSD(string maKM)
        {
            // true -> còn hạn ; false -> hết hạn
            try
            {
                KHUYEN_MAI k = ctx.KHUYEN_MAIs.Where(m => m.MaKhuyenMai.Trim().Equals(maKM.Trim())).FirstOrDefault();
                if (k != null && k.NgayBD.Value != null && k.NgayKT.Value != null)
                {
                    DateTime currentdate = DateTime.Today;
                    if (k.NgayBD.Value.Date < currentdate.Date && currentdate.Date < k.NgayKT.Value.Date)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
           
        }
        public bool KT_TonTai(string maKhuyenMai)
        {
            try {
                KHUYEN_MAI k = ctx.KHUYEN_MAIs.Where(m => m.MaKhuyenMai.Trim().Equals(maKhuyenMai.Trim())).FirstOrDefault();
                if (k != null) { return true; }
                return false;
            }
            catch { return false; }
        }
    }
}
