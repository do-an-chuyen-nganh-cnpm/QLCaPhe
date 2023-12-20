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
            try
            {
                var result = from hoaDon in ctx.HoaDons
                             join chiTietHoaDon in ctx.ChiTietHoaDons on hoaDon.MaHD equals chiTietHoaDon.MaHD
                             join sanPham in ctx.SanPhams on chiTietHoaDon.MaSP equals sanPham.MaSP
                             where hoaDon.NgayLap.Value.Date == day.Date
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
                                 DonGia = chiTietHoaDon.DonGia.Value,
                                 Giamgia = hoaDon.Giamgia.Value,
                                 MaSP = chiTietHoaDon.MaSP,
                                 SoLuong = chiTietHoaDon.SoLuong.Value,
                                 ThanhTien = chiTietHoaDon.TongTien.Value
                             };
                List<TK_DoanhThuModel> tam = result.ToList();
                return result.ToList();
            }
            catch
            {
                return null;
            }
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
                             where hoaDon.NgayLap.Value.Date >= ngayBD.Date && hoaDon.NgayLap.Value.Date <= ngayKT.Date && hoaDon.TrangThai.Equals(trangThaiHD)
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

        public List<TK_DoanhThuModel> getThongkeTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(ngayBD, ngayKT);
            return result;
        }
        public List<TK_DoanhThuModel> getDoanhThuTheo_Ma_DoanhThu(int maDK)
        {

            /*
              _danhSachDieuKien = new List<DieuKienThongKeModel>();
                DieuKienThongKeModel d = new DieuKienThongKeModel();
                d.TenDK = "Hôm nay";
                d.MaDK = "1";
                _danhSachDieuKien.Add(d);
                DieuKienThongKeModel d2 = new DieuKienThongKeModel();
                d2.TenDK = "Quý 1";
                d2.MaDK = "2";
                _danhSachDieuKien.Add(d2);
                DieuKienThongKeModel d3 = new DieuKienThongKeModel();
                d3.TenDK = "Quý 2";
                d3.MaDK = "3";
                _danhSachDieuKien.Add(d3);
                DieuKienThongKeModel d4 = new DieuKienThongKeModel();
                d4.TenDK = "Quý 3";
                d4.MaDK = "4";
                _danhSachDieuKien.Add(d4);
                DieuKienThongKeModel d5 = new DieuKienThongKeModel();
                d5.TenDK = "Quý 4";
                d5.MaDK = "5";
                _danhSachDieuKien.Add(d5);
             */
            switch (maDK)
            {
                case 1:
                    {
                        // Ngày hôm nay
                        DateTime today = DateTime.Now;
                        //List<TK_DoanhThuModel> result = Get_DoanhThu_ngay(today);
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(today,today);
                        return result;
                    }
                case 2:
                    {
                        //quý 1
                        int nam = DateTime.Today.Year;
                        DateTime BD = new DateTime(nam, 1, 1); // January 1st
                        DateTime KT = new DateTime(nam, 3, 31); // March 31st
                        DateTime yesterday = DateTime.Now.AddDays(-1);
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(BD,KT);
                        return result;
                    }
                case 3:
                    {
                        // Quý 2
                        int nam = DateTime.Today.Year;
                        DateTime BD = new DateTime(nam, 4, 1); // January 1st
                        DateTime KT = new DateTime(nam, 6, 30); // March 31st
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(BD, KT);
                        return result;
                    }
                case 4:
                    {
                        // Quý 3
                        int nam = DateTime.Today.Year;
                        DateTime BD = new DateTime(nam, 7, 1); // January 1st
                        DateTime KT = new DateTime(nam, 9, 30); // March 31st
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(BD, KT);
                        return result;
                    }
                case 5:
                    {
                        // Quy 4
                        int nam = DateTime.Today.Year;
                        DateTime BD = new DateTime(nam, 10, 1); // January 1st
                        DateTime KT = new DateTime(nam, 12, 30); // March 31st
                        List<TK_DoanhThuModel> result = Get_DoanhThu_khoang_A_B(BD, KT);
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
