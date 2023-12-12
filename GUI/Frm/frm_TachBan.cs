using BLL;
using BLL.Core;
using BLL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Frm
{
    public partial class frm_TachBan : Form
    {
        XuLyBan xuLyBan = new XuLyBan();
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        XuLySanPham xuLySanPham = new XuLySanPham();
        //
        List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();
        //
        //các column trong datatable CTHD
        private string CTHDclThanhTien = "Thành tiền";
        private string CTHDclMaHoaDon = "Mã hóa đơn";
        private string CTHDclTenSP = "Tên sản phẩm";
        private string CTHDclSoLuong = "Số lượng";
        private string CTHDclDonGia = "Đơn giá";
        private string CTHDclMaSP = "Mã sản phẩm";
        //
        DataTable dataTableSanPham, dataTableCTHoaDon;
        //
        private string trangThaiBanTrong = "bàn trống";
        private string trangThaiBanDaDat = "bàn đã đặt";
        private string trangThaiBanCoKhach = "đã có khách";
        private string trangThaiHD_DaTT = "đã thanh toán";
        private string trangThaiHD_chuaTT = "chưa thanh toán";
        public frm_TachBan()
        {
            InitializeComponent();
            Init();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Init()
        {
           TaoDSban();
        }
        public Panel taoBan(string maBan, string TenBan, string trangthai)
        {
            Panel panel = new Panel
            {
                Width = 60,
                Height = 60,
                // Set the border style
                BorderStyle = BorderStyle.FixedSingle,
                Name = TenBan,
            };
            //màu theo trạng thái và TAG
            switch (trangthai)
            {
                case var x when x.Equals(trangThaiBanCoKhach):
                    {
                        panel.BackColor = Color.LightCoral;
                        panel.Tag = trangThaiBanCoKhach;
                        break;
                    }
                case var x when x.Equals(trangThaiBanDaDat):
                    {
                        panel.BackColor = Color.LightYellow;
                        panel.Tag = trangThaiBanDaDat;
                        break;
                    }
                case var x when x.Equals(trangThaiBanTrong):
                    {
                        panel.BackColor = Color.LimeGreen;
                        panel.Tag = trangThaiBanTrong;
                        break;
                    }
                default:
                    break;
            }
            panel.Click += Panel_Click;
            Label label = new Label
            {
                Text = TenBan,
                Location = new Point(0, 0),
                Name = maBan,
                Font = new Font("Arial", 12), // Set the font with size 12
            };
            panel.Controls.Add(label);
            return panel;
        }
        private void khoiTaoDTBL_CTHoaDon()
        {
            dataTableCTHoaDon = new DataTable();
            dataTableCTHoaDon.Columns.Add(CTHDclTenSP);
            dataTableCTHoaDon.Columns.Add(CTHDclSoLuong);
            dataTableCTHoaDon.Columns.Add(CTHDclDonGia);
            dataTableCTHoaDon.Columns.Add(CTHDclThanhTien);
            DGV_CTHoaDon.DataSource = dataTableCTHoaDon;
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            //có 3 trạng thái : đã có khách, bàn trống, và đã đặt
            //đã có khách thì hiển thị hóa đơn bàn đó lên
            //bàn trống khỏi hiển thị
            //đặt bàn thì hiên thị nhận bàn
            Panel p = (Panel)sender;
            txtTenBan.Text = p.Name;
            string tenBan = p.Name;
            string maBan = xuLyBan.LayMaBan(tenBan);
            khoiTaoDTBL_CTHoaDon();
            switch (p.Tag)
            {
                case var x when x.Equals(trangThaiBanCoKhach):
                    {
                        //hiển thị hóa đơn bàn đó lên
                        HoaDon hd = xuLyHoaDon.LayHoaDon(maBan, trangThaiHD_chuaTT);
                        if (hd != null)
                        {
                            txtMaHD.Text = hd.MaHD;
                            chiTietHoaDons = new List<ChiTietHoaDon>();
                            chiTietHoaDons = xuLyChiTietHoaDon.LayChiTietHoaDon(hd.MaHD);
                            LoadDGV_CTHoaDon(chiTietHoaDons);
                        }
                        break;
                    }
                case var x when x.Equals(trangThaiBanDaDat):
                    {
                        //hiển thị nhận bàn
                        khoiTaoDTBL_CTHoaDon();
                        break;
                    }
                case var x when x.Equals(trangThaiBanTrong):
                    {
                        //cho phép oder
                        khoiTaoDTBL_CTHoaDon();
                        break;
                    }
                default:
                    break;
            }
        }
        private void LoadDGV_CTHoaDon(List<ChiTietHoaDon> cthoadons)
        {
            khoiTaoDTBL_CTHoaDon();
            if (cthoadons != null)
            {
                int tongsl = 0;
                int tongSP = 0;
                double tongTien = 0;
                string trangthaiHD = "null";
                string maHD = "";
                foreach (ChiTietHoaDon cthd in cthoadons)
                {
                    maHD = cthd.MaHD;
                    tongsl += cthd.SoLuong.Value;
                    tongTien += cthd.SoLuong.Value * cthd.DonGia.Value;
                    LoadDGV_CTHoaDon(cthd);
                }
                tongSP = cthoadons.Count();
                if (!String.IsNullOrEmpty(maHD) || maHD != "") { trangthaiHD = xuLyHoaDon.TimKiem(maHD).TrangThai; }
                //txtTongSanPham.Text = tongSP.ToString();
                //txtTrangThaiHD.Text = trangthaiHD;
                //txtTongSL.Text = tongsl.ToString();
                //txtTongTien.Text = Librari.ConvertFormatTien(tongTien);
            }
        }
        private void LoadDGV_CTHoaDon()
        {
            List<ChiTietHoaDon> cthoadon = new List<ChiTietHoaDon>();
            LoadDGV_CTHoaDon(cthoadon);
        }
        private void LoadDGV_CTHoaDon(ChiTietHoaDon cthd)
        {
            if (cthd != null)
            {
                DataRow row = dataTableCTHoaDon.NewRow();
                row[CTHDclTenSP] = xuLySanPham.layTenSP(cthd.MaSP);
                row[CTHDclSoLuong] = cthd.SoLuong.Value;
                row[CTHDclDonGia] = cthd.DonGia;
                row[CTHDclThanhTien] = cthd.SoLuong * cthd.DonGia;
                dataTableCTHoaDon.Rows.Add(row);
                DGV_CTHoaDon.DataSource = dataTableCTHoaDon;
            }
        }
        public void TaoDSban()
        {
            try
            {
                groupBox1.Controls.Clear();
                List<BAN> listBan = xuLyBan.getAllBan();
                int x = 10, y = 10;
                int indexBan = 0;
                for (int row = 0; row < listBan.Count; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        string tenTT = xuLyTrangThaiBan.layTenTrangThai(listBan[indexBan].MaTrangThai);
                        Panel p = taoBan(listBan[indexBan].MaBan, listBan[indexBan].TenBan, tenTT);
                        p.Location = new Point(x, y);
                        groupBox1.Controls.Add(p);
                        x += p.Width + 10;
                        indexBan++;
                    }
                    x = 10;
                    y += 70;
                }
            }
            catch { }
        }
    }
}
