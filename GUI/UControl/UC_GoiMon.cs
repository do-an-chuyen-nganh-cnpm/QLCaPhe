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
        private string maNV = "NV001";
        public UC_GoiMon()
        {
            InitializeComponent();
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
            TaoDSban();
            LoadLoaiNuoc();
        }
        private void LoadLoaiNuoc()
        {
            List<LoaiSP> listLoaiSP = xuLyLoaiSanPham.getAll();
            if(listLoaiSP == null) { return; }
            cbxLoaiNuoc.DataSource = listLoaiSP;
            cbxLoaiNuoc.DisplayMember = "TenLoaiSP";
            cbxLoaiNuoc.ValueMember = "MaLoaiSP";
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
            switch (p.Tag)
            {
                case var x when x.Equals(trangThaiBanCoKhach):
                    {
                        //hiển thị hóa đơn bàn đó lên
                        HoaDon hd = xuLyHoaDon.LayHoaDon(maBan,trangThaiHD_chuaTT);
                        if(hd!= null)
                        {
                            txtMaHD.Text = hd.MaHD;
                            List<ChiTietHoaDon> list = xuLyChiTietHoaDon.LayChiTietHoaDon(hd.MaHD);
                            LoadDGV_CTHoaDon(list);
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
            frm_ThanhToan f = new frm_ThanhToan();
            f.ShowDialog();
        }

        private void cbxLoaiNuoc_TextChanged(object sender, EventArgs e)
        {
            string maLoai = cbxLoaiNuoc.SelectedValue.ToString();
            if(maLoai != "" || !String.IsNullOrEmpty(maLoai))
            {
                List<SanPham> result = xuLySanPham.laySanPhamByMaLoai(maLoai);
                if (result == null)
                {
                    return;
                }
                LoadDGVSanPham(result);
            }
        }
        private void LoadDGVSanPham()
        {           
            List<SanPham> listSanPham =  xuLySanPham.laySanPham();
            if (listSanPham == null) { return; }
            LoadDGVSanPham(listSanPham);
        }
        private void khoiTaoTBLDSSanPham()
        {
            dataTableSanPham = new DataTable();
            //tạo column
            dataTableSanPham.Columns.Add(SPclTenSanPham, typeof(string));
            dataTableSanPham.Columns.Add(SPclDonGia, typeof(string));
            dataTableSanPham.Columns.Add(SPclMaSp, typeof(string));
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
                row[SPclMaSp] = sp.MaSP;
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
            //thêm mới khách hàng
            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = Librari.CreateMaKhachHang();
             kq = xuLyKhachHang.ThemKH(kh);
            //thêm mới hóa đơn
            HoaDon hd = new HoaDon();
            hd.MaHD = Librari.CreateMaHoaDon();
            hd.MaNV = maNV;
            hd.MaKH = kh.MaKH;
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
                row[CTHDclMaHoaDon] = cthd.MaHD;
                row[CTHDclTenSP] = xuLySanPham.layTenSP(cthd.MaSP);
                row[CTHDclSoLuong] = cthd.SoLuong.Value;
                row[CTHDclDonGia] = cthd.DonGia;
                row[CTHDclThanhTien] = cthd.SoLuong * cthd.DonGia; 
                row[CTHDclMaSP] = cthd.MaSP; 
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
                List<ChiTietHoaDon> listCTHD = xuLyChiTietHoaDon.LayChiTietHoaDon(mahd);
                LoadDGV_CTHoaDon(listCTHD);
            }
        }
        public SanPham layTT_DGV_SanPham(int rowclick)
        {
            if(dgvDSSanPham.CurrentCell != null)
            {
                SanPham sp = new SanPham();
                sp = xuLySanPham.laySanPham(dgvDSSanPham.Rows[rowclick].Cells[SPclMaSp].Value.ToString());
                return sp;
            }return null;           
        }
        public ChiTietHoaDon layTT_DGV_HoaDon(int rowclick)
        {
            if (DGV_CTHoaDon.CurrentCell != null)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon();
                chitiethoadon = xuLyChiTietHoaDon.LayChiTietHoaDon(
                    DGV_CTHoaDon.Rows[rowclick].Cells[CTHDclMaHoaDon].Value.ToString(),
                    DGV_CTHoaDon.Rows[rowclick].Cells[CTHDclMaSP].Value.ToString());
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
                    if(chitietHoaDon == null) { MessageBox.Show("Lỗi btnBoChon_Click ");return; }
                    //nếu sl ít hơn sl đang chọn thì giảm sl
                    if(chitietHoaDon.SoLuong> slchon)
                    {
                        chitietHoaDon.SoLuong -= slchon;
                    }
                    //nết sl == thì xóa
                    else if(slchon == chitietHoaDon.SoLuong || slchon<chitietHoaDon.SoLuong)
                    {
                        xuLyChiTietHoaDon.Xoa_CTHoaDon(chitietHoaDon.MaHD,chitietHoaDon.MaSP);
                    }
                    else { MessageBox.Show("Kiểm tra lại số lượng"); }
                    List<ChiTietHoaDon> list = xuLyChiTietHoaDon.LayChiTietHoaDon(chitietHoaDon.MaHD);
                    LoadDGV_CTHoaDon(list);
                        
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
            //cập nhật mã trạng thái bàn
            if (txtTenBan.Text != "" || !String.IsNullOrEmpty(txtTenBan.Text))
            {
                string maTrangThai = xuLyTrangThaiBan.layMaTrangThai(trangThaiBanDaDat);
                string maBan = xuLyBan.LayMaBan(txtTenBan.Text).Trim();
                if(!String.IsNullOrEmpty( maBan) && !String.IsNullOrEmpty(maTrangThai))
                {
                    xuLyBan.capNhatTrangThaiBan(maBan, maTrangThai);
                    TaoDSban();
                }
            }
        }
        private void khoiTaoDTBL_CTHoaDon()
        {
            dataTableCTHoaDon = new DataTable();
            dataTableCTHoaDon.Columns.Add(CTHDclTenSP);
            dataTableCTHoaDon.Columns.Add(CTHDclSoLuong);
            dataTableCTHoaDon.Columns.Add(CTHDclDonGia);
            dataTableCTHoaDon.Columns.Add(CTHDclThanhTien);
            dataTableCTHoaDon.Columns.Add(CTHDclMaHoaDon);           
            dataTableCTHoaDon.Columns.Add(CTHDclMaSP);
            DGV_CTHoaDon.DataSource = dataTableCTHoaDon;
            txtTongSanPham.Text = "0";
            txtTrangThaiHD.Text = "null";
            txtTongTien.Text = "0";
            txtTongSL.Text = "0";
        }
    }
}
