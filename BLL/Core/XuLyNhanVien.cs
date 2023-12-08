using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public  class XuLyNhanVien:BaseXuLy
    {
        public List<NHANVIEN> getAllNhanVien()
        {
            return ctx.NHANVIENs.ToList();
        }
        public List<QUYEN> getAllQuyen()
        {
            return ctx.QUYENs.ToList();
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
    }

    
}
