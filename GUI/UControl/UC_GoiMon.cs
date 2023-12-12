using BLL;
using BLL.Core;
using BLL.DB;
using GUI.Frm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietQRPaymentAPI;

namespace GUI.UControl
{
    public partial class UC_GoiMon : UserControl
    {
        XuLyLoaiSanPham  xuLyLoaiSanPham = new XuLyLoaiSanPham();
        XuLySanPham      xuLySanPham = new XuLySanPham();
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        XuLyBan          xuLyBan = new XuLyBan();
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        DataTable        dataTableSanPham, dataTableCTHoaDon;
        //
        private string trangThaiBanTrong = "bàn trống";
        private string trangThaiBanDaDat = "bàn đã đặt";
        private string trangThaiBanCoKhach = "đã có khách";
        private string trangThaiHD_DaTT = "đã thanh toán";
        private string trangThaiHD_chuaTT = "chưa thanh toán";
        private int huyDatban;
        //các column trong datatable CTHD
        private string CTHDclThanhTien = "Thành tiền";
        private string CTHDclMaHoaDon = "Mã hóa đơn";
        private string CTHDclTenSP = "Tên sản phẩm";
        private string CTHDclSoLuong = "Số lượng";
        private string CTHDclDonGia = "Đơn giá";
        private string CTHDclMaSP = "Mã sản phẩm";
        //Column trong table SanPham 
        private string SPclTenSanPham = "Tên sản phẩm";
        private string SPclDonGia = "Đơn giá";
        private string SPclMaSp = "Mã sản phẩm";
        private string maNV;
        List<SanPham> sanPhams = new List<SanPham>();
        List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();
        public UC_GoiMon()
        {
            maNV = frm_DangNhap.nvDangSuDung.MaNV;
            InIt();
        }
        //private void LoadDGVHoaDon(ChiTietHoaDon chitietHD)
        //{
        //    DataRow row = dataTableCTHoaDon.NewRow();
        //    row[CTHDclDonGia] = chitietHD.DonGia;
        //    row[CTHDclTenSP] = xuLySanPham.layTenSP(chitietHD.MaSP);
        //    row[CTHDclMaHoaDon] = chitietHD.MaHD;
        //    row[CTHDclMaSP]= chitietHD.MaSP;
        //    row[CTHDclSoLuong] = chitietHD.SoLuong;
        //    row[CTHDclThanhTien]= chitietHD.DonGia * chitietHD.SoLuong;
        //    dataTableCTHoaDon.Rows.Add(row);
        //    DGV_CTHoaDon.DataSource = dataTableCTHoaDon;
        //}
        private void InIt()
        {
            InitializeComponent();
            TaoDSban();
            LoadLoaiNuoc();
            sanPhams = new List<SanPham>();
            sanPhams = xuLySanPham.laySanPham();
            LoadDGVSanPham(sanPhams);
        }
        private void LoadLoaiNuoc()
        {
            List<LoaiSP> listLoaiSP = xuLyLoaiSanPham.getAll();
            if(listLoaiSP == null) { return; }
            cbxLoaiNuoc.DataSource = listLoaiSP;
            cbxLoaiNuoc.DisplayMember = "TenLoaiSP";
            cbxLoaiNuoc.ValueMember = "MaLoaiSP";
        }
        public  void TaoDSban()
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
        private void Panel_Click(object sender, EventArgs e)
        {
            //có 3 trạng thái : đã có khách, bàn trống, và đã đặt
            //đã có khách thì hiển thị hóa đơn bàn đó lên
            //bàn trống khỏi hiển thị
            //đặt bàn thì hiên thị nhận bàn
            Panel p = (Panel)sender;
            txtTenBan.Text = p.Name;
            string tenBan=p.Name;
            string maBan = xuLyBan.LayMaBan(tenBan);
            khoiTaoDTBL_CTHoaDon();
            btn_DatBan.Text = "Đặt bàn";
            btn_DatBan.Tag = 1;
            switch (p.Tag)
            {
                case var x when x.Equals(trangThaiBanCoKhach):
                    {
                        //hiển thị hóa đơn bàn đó lên
                        HoaDon hd = xuLyHoaDon.LayHoaDon(maBan,trangThaiHD_chuaTT);
                        if(hd!= null)
                        {
                            txtMaHD.Text = hd.MaHD;
                            chiTietHoaDons = new List<ChiTietHoaDon>();
                            chiTietHoaDons = xuLyChiTietHoaDon.LayChiTietHoaDon(hd.MaHD);
                            LoadDGV_CTHoaDon(chiTietHoaDons);
                        }
                        VoHieuHoaControl(btnTaoMoiHD);
                        CoHieuLucControl(btnChon);
                        break;
                    }
                case var x when x.Equals(trangThaiBanDaDat):
                    {
                        //hiển thị nhận bàn
                        khoiTaoDTBL_CTHoaDon();
                        CoHieuLucControl(btnTaoMoiHD);
                        VoHieuHoaControl(btnChon);
                        btn_DatBan.Text = "Hủy đặt bàn";
                        btn_DatBan.Tag = huyDatban;
                        break;
                    }
                case var x when x.Equals(trangThaiBanTrong):
                    {
                        //cho phép oder
                        khoiTaoDTBL_CTHoaDon();
                        CoHieuLucControl(btnTaoMoiHD);
                        VoHieuHoaControl(btnChon);
                        break;
                    }
                default:
                    break;
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if(txtMaHD.Text==null || txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn quên chọn bàn");
                return;
            }
            frm_ThanhToan f = new frm_ThanhToan(txtMaHD.Text);
            f.ShowDialog();
        }

        private void cbxLoaiNuoc_TextChanged(object sender, EventArgs e)
        {
            string maLoai = cbxLoaiNuoc.SelectedValue.ToString();
            if(maLoai != "" || !String.IsNullOrEmpty(maLoai))
            {
                sanPhams = new List<SanPham>();
                sanPhams = xuLySanPham.laySanPhamByMaLoai(maLoai);
                if (sanPhams == null)
                {
                    return;
                }
                LoadDGVSanPham(sanPhams);
            }
        }
        private void LoadDGVSanPham()
        {           
            sanPhams=  xuLySanPham.laySanPham();
            if (sanPhams == null) { return; }
            LoadDGVSanPham(sanPhams);
        }
        private void khoiTaoTBLDSSanPham()
        {
            dataTableSanPham = new DataTable();
            //tạo column
            dataTableSanPham.Columns.Add(SPclTenSanPham, typeof(string));
            dataTableSanPham.Columns.Add(SPclDonGia, typeof(string));
        }
        private void LoadDGVSanPham(List<SanPham> listSP)
        {
            khoiTaoTBLDSSanPham();
            foreach(SanPham item in listSP)
            {
                LoadDGVSanPham(item);
            }
        }
        private void LoadDGVSanPham(SanPham sp)
        {
            if (sp != null)
            {
                DataRow row = dataTableSanPham.NewRow();
                row[SPclTenSanPham] = sp.TenSP;
                row[SPclDonGia] = sp.GiaSP;
                dataTableSanPham.Rows.Add(row);
                dgvDSSanPham.DataSource = dataTableSanPham;
            }
        }
        private void VoHieuHoaControl(Control ctr)
        {
            ctr.Enabled = false;
        }

        private void btnTaoMoiHD_Click(object sender, EventArgs e)
        {
            string tenBan = txtTenBan.Text;
            string maban = xuLyBan.LayMaBan(tenBan);
            //cập nhật trạng thái bàn 
            string matrangthai = xuLyTrangThaiBan.layMaTrangThai(trangThaiBanCoKhach);
            int kq = xuLyBan.capNhatTrangThaiBan(maban, matrangthai);
            //thêm mới hóa đơn
            HoaDon hd = new HoaDon();
            hd.MaHD = Librari.CreateMaHoaDon();
            hd.MaNV = maNV;
            hd.MaKH = null;
            hd.MaBan = maban;
            hd.NgayLap = DateTime.Today;
            hd.TrangThai = trangThaiHD_chuaTT;
            kq = xuLyHoaDon.Them(hd);
            txtMaHD.Text = hd.MaHD;
            //reload lại bàn
            if(kq ==1)
            {
                MessageBox.Show("Tạo thành công");
                TaoDSban();
                CoHieuLucControl(btnChon);
            }
        }

        private void CoHieuLucControl(Control ctr)
        {
            ctr.Enabled = true;
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
                txtTongSanPham.Text = tongSP.ToString();
                txtTrangThaiHD.Text = trangthaiHD;
                txtTongSL.Text = tongsl.ToString();
                txtTongTien.Text = Librari.ConvertFormatTien(tongTien);
            }
        }
        private void LoadDGV_CTHoaDon()
        {
            List<ChiTietHoaDon> cthoadon = new List<ChiTietHoaDon>();
            LoadDGV_CTHoaDon(cthoadon);
        }
        private void LoadDGV_CTHoaDon(ChiTietHoaDon cthd)
        {
            if(cthd != null)
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
        int indexClickDGVSP = -1;
        private void dgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvDSSanPham.CurrentCell != null)
            {
                indexClickDGVSP = index;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (indexClickDGVSP == -1) { return; }
            SanPham sp = layTT_DGV_SanPham(indexClickDGVSP); 
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            if (sp != null)
            {
                string mahd = txtMaHD.Text;
                bool checkTonTai = xuLyChiTietHoaDon.KT_TrungChiTiet(mahd, sp.MaSP);
                if (checkTonTai)
                {
                    //tăng sl
                    ChiTietHoaDon _cthd = xuLyChiTietHoaDon.LayChiTietHoaDon(mahd, sp.MaSP);
                    _cthd.SoLuong += int.Parse(txtSoLuongChon.Value.ToString());
                    xuLyChiTietHoaDon.Sua_CTHoaDon(_cthd);
                }
                else
                {
                    //nếu không thì thêm mới
                    //thêm vào chi tiết hóa đơn
                   
                    cthd.MaHD = mahd;
                    cthd.MaSP = sp.MaSP;
                    cthd.SoLuong = int.Parse(txtSoLuongChon.Value.ToString());
                    cthd.DonGia = sp.GiaSP;
                    xuLyChiTietHoaDon.Them_CTHoaDon(cthd);
                }
                //nếu trong hóa đơn tồn tại thì tăng lên sl
                chiTietHoaDons = new List<ChiTietHoaDon>();
                chiTietHoaDons= xuLyChiTietHoaDon.LayChiTietHoaDon(mahd);
                LoadDGV_CTHoaDon(chiTietHoaDons);
            }
        }
        public SanPham layTT_DGV_SanPham(int rowclick)
        {
            if(dgvDSSanPham.CurrentCell != null)
            {
                if(sanPhams == null) { return null; }
                SanPham sp = new SanPham();
                string masp = sanPhams[rowclick].MaSP.ToString();
                sp = xuLySanPham.laySanPham(masp);
                return sp;
            }return null;           
        }
        public ChiTietHoaDon layTT_DGV_HoaDon(int rowclick)
        {
            if (DGV_CTHoaDon.CurrentCell != null)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon();
                chitiethoadon = xuLyChiTietHoaDon.LayChiTietHoaDon(
                   chiTietHoaDons[rowclick].MaHD,
                      chiTietHoaDons[rowclick].MaSP);
                return chitiethoadon;
            }
            return null;           
        }
        private void btnBoChon_Click(object sender, EventArgs e)
        {
            if (indexClickDGV_HoaDon != -1)
            {
                int slchon = int.Parse(txtSoLuongChon.Value.ToString());
                if (indexClickDGV_HoaDon != -1)
                {
                    ChiTietHoaDon chitietHoaDon = layTT_DGV_HoaDon(indexClickDGV_HoaDon);
                    string codeHD = chitietHoaDon.MaHD;
                    string codeSP = chitietHoaDon.MaSP;
                    if(chitietHoaDon == null) { MessageBox.Show("Lỗi btnBoChon_Click ");return; }
                    //nếu sl ít hơn sl đang chọn thì giảm sl
                    if(chitietHoaDon.SoLuong> slchon)
                    {
                        chitietHoaDon.SoLuong -= slchon;
                        int checkCapNhat=  xuLyChiTietHoaDon.capNhatLai_SL(chitietHoaDon);
                    }
                    //nết sl == thì xóa
                    else if(slchon == chitietHoaDon.SoLuong || slchon<chitietHoaDon.SoLuong)
                    {
                        xuLyChiTietHoaDon.Xoa_CTHoaDon(codeHD, codeSP);
                    }
                    else { MessageBox.Show("Kiểm tra lại số lượng"); }
                    chiTietHoaDons = new List<ChiTietHoaDon>();
                    chiTietHoaDons = xuLyChiTietHoaDon.LayChiTietHoaDon(codeHD);
                    LoadDGV_CTHoaDon(chiTietHoaDons);
                    indexClickDGV_HoaDon = -1;
                }
            }
        }
        int indexClickDGV_HoaDon = -1;
        private void DGV_CTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexClickDGV_HoaDon = e.RowIndex;
        }

        private void btnTatCaMon_Click(object sender, EventArgs e)
        {
            LoadDGVSanPham();
        }

        private void btn_DatBan_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btn_DatBan.Tag) == huyDatban)
            {
                string ten = txtTenBan.Text;
                bool kqhuy = xuLyBan.HuyDatBan(ten);
                if (kqhuy == true) { MessageBox.Show("Hủy đặt bàn thành công"); TaoDSban(); return;  }
                else { MessageBox.Show("Huy đặt bàn thấy bại"); TaoDSban(); return; }
            }
            if (txtTenBan.Text == "" || txtTenBan.Text == null) { MessageBox.Show("Đặt bàn không thành công!"); }
            string tenban = txtTenBan.Text;
            if (String.IsNullOrEmpty(tenban)) { MessageBox.Show("Đặt bàn không thành công!"); TaoDSban(); return;  }
            string maban = xuLyBan.LayMaBan(tenban);
            if(maban == null) { MessageBox.Show("Không thành công"); TaoDSban(); return;  }
            bool kq =xuLyBan.DatBan(maban);
            if(kq == true) { MessageBox.Show("Đặt bàn thành công"); }
            else { MessageBox.Show("Đặt bàn thất bại"); }
            TaoDSban();
        }

        private void UC_GoiMon_Load(object sender, EventArgs e)
        {
            List<SanPham> listSanPham = xuLySanPham.getAllSP();
            LoadDGVSanPham(listSanPham);
        }

        private void btn_TachBan_Click(object sender, EventArgs e)
        {
            frm_TachBan f = new frm_TachBan();
            f.ShowDialog();
        }

        private void khoiTaoDTBL_CTHoaDon()
        {
            dataTableCTHoaDon = new DataTable();
            dataTableCTHoaDon.Columns.Add(CTHDclTenSP);
            dataTableCTHoaDon.Columns.Add(CTHDclSoLuong);
            dataTableCTHoaDon.Columns.Add(CTHDclDonGia);
            dataTableCTHoaDon.Columns.Add(CTHDclThanhTien);
            DGV_CTHoaDon.DataSource = dataTableCTHoaDon;
            txtTongSanPham.Text = "0";
            txtTrangThaiHD.Text = "null";
            txtTongTien.Text = "0";
            txtTongSL.Text = "0";
        }
    }
}
