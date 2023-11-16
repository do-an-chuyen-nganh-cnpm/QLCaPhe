using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DB
{
    public class DieuKienThongKeModel
    {
        public string MaDK { get; set; }
        public string TenDK { get; set; }
        public class DSDieuKien
        {
            public List<DieuKienThongKeModel> _danhSachDieuKien { get; set; }
            public DSDieuKien()
            {
                _danhSachDieuKien = new List<DieuKienThongKeModel>();
                DieuKienThongKeModel d = new DieuKienThongKeModel();
                d.TenDK = "Hôm nay";
                d.MaDK = "1";
                _danhSachDieuKien.Add(d);
                DieuKienThongKeModel d2 = new DieuKienThongKeModel();
                d2.TenDK = "Hôm qua";
                d2.MaDK = "2";
                _danhSachDieuKien.Add(d2);
                DieuKienThongKeModel d3 = new DieuKienThongKeModel();
                d3.TenDK = "7 ngày trước";
                d3.MaDK = "3";
                _danhSachDieuKien.Add(d3);
                DieuKienThongKeModel d4 = new DieuKienThongKeModel();
                d4.TenDK = "Tuần này";
                d4.MaDK = "4";
                _danhSachDieuKien.Add(d4);
                DieuKienThongKeModel d5 = new DieuKienThongKeModel();
                d5.TenDK = "Tuần Trước";
                d5.MaDK = "5";
                _danhSachDieuKien.Add(d5);
                DieuKienThongKeModel d6 = new DieuKienThongKeModel();
                d6.TenDK = "Tháng này";
                d6.MaDK = "6";
                _danhSachDieuKien.Add(d6);
                DieuKienThongKeModel d7 = new DieuKienThongKeModel();
                d7.TenDK = "Tháng Trước";
                d7.MaDK = "7";
                _danhSachDieuKien.Add(d7);
                DieuKienThongKeModel d8 = new DieuKienThongKeModel();
                d8.TenDK = "28 ngày trước";
                d8.MaDK = "8";
                _danhSachDieuKien.Add(d8);
            }
        }
    }
}
