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
            }
        }
    }
}
