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
    public partial class FrmGopBan : Form
    {
        private List<Panel> danhSachPanelDaChon = new List<Panel>();
        private Color mauBanSauGop = Color.Gray;
        //
        XuLyBan xuLyBan = new XuLyBan();
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        XuLySanPham xuLySanPham = new XuLySanPham();
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        //
        private string trangThaiBanTrong;// = "bàn trống";
        private string trangThaiBanDaDat;//= "bàn đã đặt";
        private string trangThaiBanCoKhach;// = "đã có khách";
        private string trangThaiHD_DaTT;//= "đã thanh toán";
        private string trangThaiHD_chuaTT;// = "chưa thanh toán";
        //các column trong datatable CTHD
        private string CTHDclThanhTien = "Thành tiền";
        private string CTHDclTenSP = "Tên sản phẩm";
        private string CTHDclSoLuong = "Số lượng";
        private string CTHDclDonGia = "Đơn giá";
        DataTable dataTableCTHoaDon = new DataTable();
        private string maHoaDonCanGop;
        List<ChiTietHoaDon> chiTietHoaDons;
        List<string> DS_MaBanCanGop = new List<string>();
        List<string> DS_MaHoaDon = new List<string>();
        public FrmGopBan()
        {
            InitializeComponent();
            Init();
        }
        public FrmGopBan(string maHD)
        {
            maHoaDonCanGop = maHD;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            trangThaiBanTrong = xuLyTrangThaiBan.tenTrangThaiBanTrong;//bàn trống
            trangThaiBanDaDat = xuLyTrangThaiBan.tenTrangThaiDaDat;//"bàn đã đặt";
            trangThaiBanCoKhach = xuLyTrangThaiBan.tenTrangThaiDaCoKhach;//"đã có khách";
            trangThaiHD_DaTT = xuLyHoaDon.trangthaiDaThanhToan;// "đã thanh toán";
            trangThaiHD_chuaTT = xuLyHoaDon.trangthaiChuaThanhToan;// "chưa thanh toán";
        }
        private void FrmGopBan_Load(object sender, EventArgs e)
        {
            TaoDSban();
            InitializeDataTable();
            //hiên thị chi tiết hóa đơn bàn cần gọp
        }
        private void InitializeDataTable()
        {
            dataTableCTHoaDon.Columns.Add(CTHDclTenSP, typeof(string));
            dataTableCTHoaDon.Columns.Add(CTHDclSoLuong, typeof(int));
            dataTableCTHoaDon.Columns.Add(CTHDclDonGia, typeof(decimal));
            dataTableCTHoaDon.Columns.Add(CTHDclThanhTien, typeof(decimal));
        }
        private void ClearPanelHienThiBan()
        {
            panelDSBan.Controls.Clear();
        }
        public void TaoDSban()
        {
            try
            {
                panelDSBan.Controls.Clear();
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
                        panelDSBan.Controls.Add(p);
                        x += p.Width + 10;
                        indexBan++;
                    }
                    x = 10;
                    y += 70;
                }
            }
            catch { }

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
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaCoKhach): //trangThaiBanCoKhach
                    {
                        panel.BackColor = Color.LightCoral;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiDaCoKhach;
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaDat): //trangThaiBanDaDat
                    {
                        panel.BackColor = Color.LightYellow;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiDaDat;
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiBanTrong): //trangThaiBanTrong
                    {
                        panel.BackColor = Color.LimeGreen;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiBanTrong;
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


        private void Panel_Click(object sender, EventArgs e)
        {
            //có 3 trạng thái : đã có khách, bàn trống, và đã đặt
            //đã có khách thì hiển thị hóa đơn bàn đó lên
            //bàn trống khỏi hiển thị
            //đặt bàn thì hiên thị nhận bàn
            Panel p = (Panel)sender;
            string tenBan = p.Name;
            string maBan = xuLyBan.LayMaBan(tenBan);
            switch (p.Tag)
            {
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaCoKhach): //trangThaiBanCoKhach
                    {
                        //hiển thị hóa đơn bàn đó lên
                        HoaDon hd = xuLyHoaDon.LayHoaDon(maBan, trangThaiHD_chuaTT);
                        string _maHD = hd.MaHD;
                        if (hd != null)
                        {
                            chiTietHoaDons = new List<ChiTietHoaDon>();
                            chiTietHoaDons = xuLyChiTietHoaDon.LayChiTietHoaDon(_maHD);
                            LoadDGV_CTHoaDon(chiTietHoaDons);
                        }
                        danhSachPanelDaChon.Add(p);
                        if (p.BackColor == mauBanSauGop)
                        {
                            //xóa ra khỏi ds bàn cần gộp
                            if (DS_MaBanCanGop.Count >= 0)
                            {
                                string item = DS_MaBanCanGop.FirstOrDefault(v => v.Equals(maBan));
                                if (item != null)
                                {
                                    DS_MaBanCanGop.Remove(item);
                                }
                                string itemHD  = DS_MaHoaDon.FirstOrDefault(v => v.Equals(_maHD));
                                if (itemHD != null)
                                {
                                    DS_MaHoaDon.Remove(itemHD);
                                }
                                p.BackColor = Color.LightCoral;
                            }
                        }
                        else
                        {
                            //thêm vào sd bàn cần gọp
                            DS_MaBanCanGop.Add(maBan);
                            DS_MaHoaDon.Add(_maHD);
                            p.BackColor = mauBanSauGop;
                        }
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiBanTrong): //trangThaiBanTrong
                    {
                        MessageBox.Show("Không được chọn bàn trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Bàn không được chọn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }

        private void LoadDGV_CTHoaDon(List<ChiTietHoaDon> list)
        {
            dataTableCTHoaDon.Rows.Clear();
            if (list != null)
            {
                foreach (ChiTietHoaDon cthd in list)
                {
                    DataRow row = dataTableCTHoaDon.NewRow();;
                    row[CTHDclTenSP] = xuLySanPham.layTenSP(cthd.MaSP);
                    row[CTHDclSoLuong] = cthd.SoLuong.Value;
                    row[CTHDclDonGia] = cthd.DonGia;
                    row[CTHDclThanhTien] = cthd.SoLuong * cthd.DonGia;
                    dataTableCTHoaDon.Rows.Add(row);
                }
                // Bind the DataTable to the DataGridView
                dgv_HoaDon.DataSource = dataTableCTHoaDon;
                dgv_HoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btn_GopBan_Click(object sender, EventArgs e)
        {
          //  xuLyHoaDon 
          if(DS_MaBanCanGop.Count <2 || DS_MaHoaDon.Count < 2)
            {
                MessageBox.Show("Chọn ít nhất hai bàn để gọp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            HoaDon hd = xuLyHoaDon.LayHoaDon(DS_MaHoaDon[0]);
            int kq = xuLyHoaDon.GopBan(DS_MaHoaDon, DS_MaBanCanGop, hd.MaHD, hd.MaBan);
            if(kq == 1)
            {
                MessageBox.Show("Gọp bàn thành công");
                ClearPanelHienThiBan();
                TaoDSban();
            }
            else
            {
                MessageBox.Show("Gọp bàn thất bại");
            }
        }
    }
}
