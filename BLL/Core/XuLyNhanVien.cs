using BLL.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyNhanVien : BaseXuLy
    {
        public NHANVIEN DangNhap(string taiKhoan, string matKhau) {
            List<NHANVIEN> list = ctx.NHANVIENs.ToList();
            if (list == null || list.Count == 0) { return null; }
            NHANVIEN nv = list.FirstOrDefault(v => v.TenDangNhap.Trim().Equals(taiKhoan.Trim()) && v.Matkhau.Trim().Equals(matKhau.Trim()));
              if (nv == null) { return null; }
            return nv;
        }
        public List<NHANVIEN> getAllNhanVien()
        {
            return ctx.NHANVIENs.ToList();
        }
        public List<QUYEN> getAllQuyen()
        {
            return ctx.QUYENs.ToList();
        }
        public bool checkTonTai(List<ChiTietCaLamNhanvien> listChech, string maNV)
        {
            ChiTietCaLamNhanvien nv = listChech.FirstOrDefault(v => v.MaNV.Trim().Equals(maNV.Trim()));
            if (nv == null)
            {
                return false;
            }
            else { return true; }
        }
        public bool KT_MaNhanVien(string ma)
        {
            try
            {
               NHANVIEN nhanvien = ctx.NHANVIENs.Where(u => u.MaNV.Equals(ma)).FirstOrDefault();
                if (nhanvien != null) { return true; }
                return false;
            }
            catch { return false; }
        }
        public int SuaNhanVien(NHANVIEN nv)
        {
            try
            {
                NHANVIEN nhanvien = ctx.NHANVIENs.Where(m => m.MaNV.Equals(nv.MaNV)).FirstOrDefault();
                if (nhanvien != null)
                {
                    // Kiểm tra xem có sự thay đổi không trước khi cập nhật
                    if (nhanvien.TenNV != nv.TenNV ||
                        nhanvien.ChucVu != nv.ChucVu ||
                        nhanvien.DiaChi != nv.DiaChi ||
                        nhanvien.NgayVaoLam != nv.NgayVaoLam ||
                        nhanvien.SoDT != nv.SoDT ||
                        nhanvien.GioiTinh != nv.GioiTinh ||
                        nhanvien.TenDangNhap != nv.TenDangNhap ||
                        nhanvien.MaQuyen != nv.MaQuyen ||
                        nhanvien.Matkhau != nv.Matkhau)
                    {
                        nhanvien.TenNV = nv.TenNV;
                        nhanvien.ChucVu = nv.ChucVu;
                        nhanvien.DiaChi = nv.DiaChi;
                        nhanvien.NgayVaoLam = nv.NgayVaoLam;
                        nhanvien.SoDT = nv.SoDT;
                        nhanvien.GioiTinh = nv.GioiTinh;
                        nhanvien.TenDangNhap = nv.TenDangNhap;
                        nhanvien.MaQuyen = nv.MaQuyen;
                        nhanvien.Matkhau = nv.Matkhau;

                        // Không sử dụng InsertOnSubmit để cập nhật đối tượng đã tồn tại
                        ctx.SubmitChanges();
                        return 1;
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int ThemNhanVien(NHANVIEN nhanvien)
        {
            try
            {
                ctx.NHANVIENs.InsertOnSubmit(nhanvien);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int XoaNhanVien(string maNV)
        {
            try
            {
               NHANVIEN nhanvien = ctx.NHANVIENs.Where(u => u.MaNV.Equals(maNV)).FirstOrDefault();
                if (nhanvien == null) { return 0; }
                ctx.NHANVIENs.DeleteOnSubmit(nhanvien);
                ctx.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public List<ChiTietCaLamNhanvien> getNhanVien_By_NgayVLNgayTL(DateTime ngayVL, DateTime ngayTL)
        {
            List<ChiTietCaLamNhanvien> listChiTiet = ctx.ChiTietCaLamNhanviens.ToList();
            List<ChiTietCaLamNhanvien> result = new List<ChiTietCaLamNhanvien>();
            if (listChiTiet != null)
            {
                foreach(ChiTietCaLamNhanvien ctnv in listChiTiet)
                {
                    if(ctnv.NgayVaoLam.Date== ngayVL.Date && ctnv.NgayTanLam.Value.Date == ngayTL.Date)
                    {
                        result.Add(ctnv);
                    }
                }
            }
            return result;
        }
    }
}
