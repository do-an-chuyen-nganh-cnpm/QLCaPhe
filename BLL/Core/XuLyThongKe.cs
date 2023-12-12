using BLL.DB;
using BLL.Export;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyThongKe:BaseXuLy
    {
        public List<TK_DoanhThuModel> Get_DoanhThu_ngay (DateTime day)
        {
            var result = from hoaDon in ctx.HoaDons
                         join chiTietHoaDon in ctx.ChiTietHoaDons on hoaDon.MaHD equals chiTietHoaDon.MaHD
                         join sanPham in ctx.SanPhams on chiTietHoaDon.MaSP equals sanPham.MaSP
                         where hoaDon.NgayLap == day
                         select new TK_DoanhThuModel
                         {
                             MaHD = hoaDon.MaHD,
                             MaNV = hoaDon.MaNV,
                             MaKH = hoaDon.MaKH,
                             MaBan = hoaDon.MaBan,
                             NgayLap = hoaDon.NgayLap.Value,
                             TongTien = hoaDon.TongTien.Value,
                             TenSP = sanPham.TenSP,
                             DiemTL = hoaDon.DiemTL.Value,
                             Giamgia = hoaDon.Giamgia.Value,
                             MaSP = chiTietHoaDon.MaSP,
                             SoLuong = chiTietHoaDon.SoLuong.Value,
                             ThanhTien = chiTietHoaDon.TongTien.Value
                         };
            List<TK_DoanhThuModel> tam = result.ToList();
            return result.ToList();
        }
        public List<TK_DoanhThuModel> Get_DoanhThu_khoang_A_B(DateTime ngayBD, DateTime ngayKT)
        {
            string trangThaiHD = "đã thanh toán";
            //trang thái có dấu hong so sánh được
            try
            {
                var result = from hoaDon in ctx.HoaDons
                             join chiTietHoaDon in ctx.ChiTietHoaDons on hoaDon.MaHD equals chiTietHoaDon.MaHD
                             join sanPham in ctx.SanPhams on chiTietHoaDon.MaSP equals sanPham.MaSP
                             where hoaDon.NgayLap >= ngayBD && hoaDon.NgayLap <= ngayKT && hoaDon.TrangThai.Equals(trangThaiHD)
                             select new TK_DoanhThuModel
                             {
                                 MaHD = hoaDon.MaHD,
                                 MaNV = hoaDon.MaNV,
                                 MaKH = hoaDon.MaKH,
                                 TenSP = sanPham.TenSP,
                                 MaBan = hoaDon.MaBan,
                                 NgayLap = hoaDon.NgayLap.Value,
                                 TongTien = chiTietHoaDon.SoLuong.Value * chiTietHoaDon.DonGia.Value,
                                 DiemTL = hoaDon.DiemTL.Value,
                                 Giamgia = hoaDon.Giamgia.Value,
                                 MaSP = chiTietHoaDon.MaSP,
                                 SoLuong = chiTietHoaDon.SoLuong.Value,
                                 ThanhTien = chiTietHoaDon.TongTien.Value,
                                 DonGia = sanPham.GiaSP.Value,
                             };
                List<TK_DoanhThuModel> tam = result.ToList();
                return result.ToList();
            }
            catch { return null; }           
        }
        public List<TK_DoanhThuModel> getDoanhThuTheo_Ma_DoanhThu(int maDK)
        {
            switch (maDK)
            {
                case 1:
                    {
                        // Ngày hôm nay
                        DateTime today = DateTime.Now;
                        List<TK_DoanhThuModel> result = Get_DoanhThu_ngay(today);
                        return result;
                    }
                case 2:
                    {
                        // Ngày hôm qua
                        DateTime yesterday = DateTime.Now.AddDays(-1);
                        List<TK_DoanhThuModel> result = Get_DoanhThu_ngay(yesterday);
                        return result;
                    }
                case 3:
                    {
                        // 7 ngày trước
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
                        DateTime today = DateTime.Now;
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(sevenDaysAgo, today);
                        return result;
                    }
                case 4:
                    {
                        // Tuần này
                        DateTime startOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                        DateTime today = DateTime.Now;
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(startOfWeek, today);
                        return result;
                    }
                case 5:
                    {
                        // Tuần trước
                        DateTime startOfLastWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 7);
                        DateTime startOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(startOfLastWeek, startOfWeek);
                        return result;
                    }
                case 6:
                    {
                        // Tháng này
                        DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        DateTime today = DateTime.Now;
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(startOfMonth, today);
                        return result;
                    }
                case 7:
                    {
                        // Tháng trước
                        DateTime startOfLastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                        DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(startOfMonth, startOfLastMonth);
                        return result;
                    }
                case 8:
                    {
                        // 28 ngày trước
                        DateTime twentyEightDaysAgo = DateTime.Now.AddDays(-28);
                        DateTime today = DateTime.Now;
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(twentyEightDaysAgo, today);
                        return result;
                    }
                default:
                    {
                        // Handle other cases or throw an exception
                        return null;
                    }
            }
        }
        public int getTongSlSP(List<TK_DoanhThuModel> list)
        {
            List<string> result = new List<string>();
            foreach(TK_DoanhThuModel item in list)
            {
                if (!result.Contains(item.MaSP))
                {
                    result.Add(item.MaSP);
                }
            }
            return result.Count;
        }
        public double getTongDoanhThu(List<TK_DoanhThuModel> list)
        {
            return list.Sum(m => m.ThanhTien);
        }
        public double getTongGiamGia(List<TK_DoanhThuModel> list)
        {
            return list.Sum(m => m.Giamgia);
        }
        public int geSLKH(List<TK_DoanhThuModel> list)
        {
            List<string> result = new List<string>();
            foreach (TK_DoanhThuModel item in list)
            {
                if (!result.Contains(item.MaKH))
                {
                    result.Add(item.MaKH);
                }
            }
            return result.Count;
        }
        public bool XuatFile(List<TK_DoanhThuModel> listInput)
        {
            if (listInput == null) { return false; }
            ExcelExport ex = new ExcelExport();
            ExportThongKeModel exportModel = new ExportThongKeModel();
            List<exportSanPham> listSanPham = new List<exportSanPham>();
            var sortedList = listInput.OrderBy(x => x.MaSP).ToList();
            // Remove duplicates based on MaSP
            List<TK_DoanhThuModel> listUnitMaSP= sortedList.GroupBy(x => x.MaSP).Select(g => g.First()).ToList();
            exportModel.ngayThongKe = DateTime.Now.ToString("dd/MM/yyyy");
            exportModel.tongDoanhThu = listInput.Sum(v => v.TongTien).ToString();
            exportModel.tongSP = listUnitMaSP.Count().ToString();
            exportModel.tongSoLuong = listInput.Sum(v => v.SoLuong).ToString();
            List<string> DSMaSP = new List<string>();
            foreach(TK_DoanhThuModel item in listUnitMaSP)
            {
                DSMaSP.Add(item.MaSP);
            }
            foreach (string maSP in DSMaSP)
            {
                exportSanPham sp = new exportSanPham();
                foreach (TK_DoanhThuModel item in listInput)
                {
                    if (maSP.Trim().Equals(item.MaSP.Trim()))
                    {
                        sp.TenSP = item.TenSP;
                        sp.Gia = item.DonGia.ToString();
                        //
                        if (sp.SoLuong == null)
                        {
                            sp.SoLuong = "0";
                        }
                        int sl = int.Parse(sp.SoLuong);
                        sl += item.SoLuong;
                        sp.SoLuong = sl.ToString();
                        //
                        if (sp.ThanhTien == null)
                        {
                            sp.ThanhTien = "0";
                        }
                        double thanhtien = double.Parse(sp.ThanhTien);
                        thanhtien += item.ThanhTien;
                        sp.ThanhTien = thanhtien.ToString();
                    }
                }
                listSanPham.Add(sp);
            }
            //xuất file
            string fileName = "BangThongKe";
            bool kq = ex.ExportPhieuXuat(exportModel, listSanPham, ref fileName, false);
            return kq;
        }
    }
}
