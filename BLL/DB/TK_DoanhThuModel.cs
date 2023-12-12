using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DB
{
    public class TK_DoanhThuModel
    {
        public DateTime NgayLap { get; set; }
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string MaBan { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double TongTien { get; set; }
        public double DiemTL { get; set; }
        public double Giamgia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
        public double DonGia { get; set; }
    }
}
