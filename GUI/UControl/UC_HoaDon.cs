using BLL;
using BLL.Core;
using BLL.DB;
using GUI.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UControl
{
    public partial class UC_HoaDon : UserControl
    {
        XuLySanPham xuLySanPham = new XuLySanPham();
        XuLyNhanVien xuLyNhanVien = new XuLyNhanVien();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        XuLyBan xuLyBan = new XuLyBan();
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        //
        private DataTable tableHoaDon, tableCTHoaDon;
        List<HoaDon> hoaDonsChinh;
        List<ChiTietHoaDon> chiTietHoaDonChinh;
        //
        #region column name 
        private const string nameMaHoaDon = "Mã Hóa Đơn";
        private const string nameTenBan = "Tên bàn";
        private const string nameTenNhanVien = "Tên nhân viên";
        private const string nameTenKhachHang = "Tên khách hàng";
        private const string nameNgayLap = "Ngày lập";
        private const string nameGiamGia="Giảm giá";
        private const string nameTrangThai = "Giảm giá";
        private const string nameTongTien = "Tổng tiền";
        private const string nameTenSP = "Tên sản phẩm";
        private const string nameSoLuong = "Số lượng";
        private const string nameDonGia = "Đơn giá";
        private const string nameThanhTien = "Thành tiền";
        #endregion
        //
        public UC_HoaDon()
        {
            IniT();
        }
        private void IniT()
        {
            InitializeComponent();
            KhoiTaoTableHoaDon();
            KhoiTaoTableCTHoaDon();
            ThemDuLieu_HoaDon();
            List<BAN> bans = xuLyBan.getAllBan();
            if(bans!= null)
            {
                cbx_Ban.DataSource= bans;
                cbx_Ban.DisplayMember = "TenBan";
                cbx_Ban.ValueMember = "MaBan";
            }
        }
        private void ThemDuLieu_HoaDon()
        {
            hoaDonsChinh = new List<HoaDon>();
            hoaDonsChinh = xuLyHoaDon.LayTatCaHoaDon();
            if(hoaDonsChinh != null)
            {
                ThemDuLieu_HoaDon(hoaDonsChinh);
            }
            else
            {
                KhoiTaoTableHoaDon();
            }
        }
        private void ThemDuLieu_HoaDon(List<HoaDon> list)
        {
            KhoiTaoTableHoaDon();
            if(list != null)
            {
                foreach(HoaDon hoadon in list)
                {
                    DataRow row = tableHoaDon.NewRow();
                    row[nameMaHoaDon] = hoadon.MaHD.ToString();
                    row[nameTenBan] =xuLyBan.layTenBanByMaBan( hoadon.MaBan.ToString());
                    row[nameTenNhanVien] =xuLyNhanVien.layTenNhanVien(hoadon.MaNV) ;
                    row[nameTenKhachHang] = xuLyKhachHang.layTenKH( hoadon.MaKH.ToString());
                    row[nameNgayLap] = hoadon.NgayLap.Value.ToString("dd/MM/yyyy");
                    row[nameGiamGia] = hoadon.Giamgia.ToString();
                    row[nameTrangThai] = hoadon.TrangThai.ToString();
                    row[nameTongTien] =Librari.ConvertFormatTien( hoadon.TongTien.Value);
                    tableHoaDon.Rows.Add(row);
                }
                DGVHoaDon.DataSource = tableHoaDon;
            }
            else { KhoiTaoTableHoaDon(); }
        }
        private void ThemDuLieu_ChiTietHoaDon()
        {
            chiTietHoaDonChinh = new List<ChiTietHoaDon>();
            chiTietHoaDonChinh = xuLyChiTietHoaDon.LayTatCa();
            if (chiTietHoaDonChinh != null)
            {
                ThemDuLieu_ChiTietHoaDon(chiTietHoaDonChinh);
            }
            else { KhoiTaoTableCTHoaDon(); }
        }
        private void ThemDuLieu_ChiTietHoaDon(List<ChiTietHoaDon> list)
        {
            KhoiTaoTableCTHoaDon();
            if (list != null)
            {
                foreach (ChiTietHoaDon cthd in list)
                {
                    DataRow row = tableCTHoaDon.NewRow();
                    row[nameTenSP] = xuLySanPham.layTenSP(cthd.MaSP);
                    row[nameSoLuong] = cthd.SoLuong.Value.ToString();
                    row[nameDonGia] = Librari.ConvertFormatTien(cthd.DonGia.Value);
                    row[nameThanhTien] = Librari.ConvertFormatTien(cthd.TongTien.Value);
                    tableCTHoaDon.Rows.Add(row);
                }
                DGVCTHoaDon.DataSource = tableCTHoaDon;
            }
        }
        private void KhoiTaoTableCTHoaDon()
        {
            tableCTHoaDon = new DataTable();
            tableCTHoaDon.Columns.Add(nameTenSP, typeof(string));
            tableCTHoaDon.Columns.Add(nameSoLuong, typeof(string));
            tableCTHoaDon.Columns.Add(nameDonGia, typeof(string));
            tableCTHoaDon.Columns.Add(nameThanhTien, typeof(string));
            DGVCTHoaDon.DataSource = tableCTHoaDon;
        }

        private void DGVHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexchon = e.RowIndex;
            if (indexchon != -1 && hoaDonsChinh.Count > indexchon)
            {
                txtMaHoaDon.Text = hoaDonsChinh[indexchon].MaHD;
                datetimeNgayLap.Value = hoaDonsChinh[indexchon].NgayLap.Value.Date;
                cbx_Ban.Text = xuLyBan.layTenBanByMaBan(hoaDonsChinh[indexchon].MaBan);
                chiTietHoaDonChinh = new List<ChiTietHoaDon>();
                chiTietHoaDonChinh = xuLyHoaDon.LayChiTietHoaDon(hoaDonsChinh[indexchon].MaHD.ToString());
                ThemDuLieu_ChiTietHoaDon(chiTietHoaDonChinh);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "") { MessageBox.Show("Bạn chưa chọn hóa đơn"); return; }
            frmHoaDon f = new frmHoaDon(txtMaHoaDon.Text);
            f.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DateTime ngayLapHoadon = datetimeNgayLap.Value;
            hoaDonsChinh = new List<HoaDon>();
            hoaDonsChinh = xuLyHoaDon.TimKiemHoaDonByNgayLap(ngayLapHoadon);
            if (hoaDonsChinh == null) { KhoiTaoTableHoaDon(); KhoiTaoTableCTHoaDon(); }
            else { ThemDuLieu_HoaDon(hoaDonsChinh); }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            hoaDonsChinh = new List<HoaDon>();
            hoaDonsChinh = xuLyHoaDon.LayTatCaHoaDon();
            ThemDuLieu_HoaDon(hoaDonsChinh);
        }

        private void rdo_DaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_DaThanhToan.Checked == true)
            {
                string trangthaiDaThanhToan = xuLyHoaDon.trangthaiDaThanhToan;
                List<HoaDon> newResult = hoaDonsChinh.Where(v => v.TrangThai.Trim().Equals(trangthaiDaThanhToan.Trim())).ToList();
                ThemDuLieu_HoaDon(newResult);
            }
        }

        private void rdo_ChuaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_ChuaThanhToan.Checked == true)
            {
                string trangthaiChuaThanhToan = xuLyHoaDon.trangthaiChuaThanhToan;
                List<HoaDon> newResult = hoaDonsChinh.Where(v => v.TrangThai.Trim().Equals(trangthaiChuaThanhToan.Trim())).ToList();
                ThemDuLieu_HoaDon(newResult);
            }
        }

        private void rdo_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_TatCa.Checked == true)
            {
                ThemDuLieu_HoaDon(hoaDonsChinh);
            }
        }

        private void KhoiTaoTableHoaDon()
        {
            tableHoaDon = new DataTable();
            tableHoaDon.Columns.Add(nameMaHoaDon,typeof(string));
            tableHoaDon.Columns.Add(nameTenBan, typeof(string));
            tableHoaDon.Columns.Add(nameTenNhanVien, typeof(string));
            tableHoaDon.Columns.Add(nameTenKhachHang, typeof(string));
            tableHoaDon.Columns.Add(nameNgayLap, typeof(string));
            tableHoaDon.Columns.Add(nameGiamGia, typeof(string));
            tableHoaDon.Columns.Add(nameTongTien, typeof(string));
            DGVHoaDon.DataSource = tableHoaDon;
        }
    }
}
