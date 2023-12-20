using BLL;
using BLL.Core;
using BLL.DB;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.Frm
{
    public partial class frm_TachBan : Form
    {
        XuLyBan xuLyBan = new XuLyBan();
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        XuLySanPham xuLySanPham = new XuLySanPham();
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        private List<Panel> danhSachPanelDaChon = new List<Panel>();
        //
        List<ChiTietHoaDon> chiTietHoaDonChinh = new List<ChiTietHoaDon>();
        List<ChiTietHoaDon> chiTietHoaDonDangChon = new List<ChiTietHoaDon>();
        //
        DataTable tableChinh, tableDangChon;
        private string maBanDangChon, maHDDangChon;
        //các column trong datatable CTHD
        private string nameTenSP = "Tên sản phẩm";
        private string nameSoLuong = "Số lượng";
        private string nameDonGia = "Đơn giá";
        private string nameThanhTien = "Thành tiền";
        private string hostMaBan, hostMaHD;
        //
        public frm_TachBan()
        {
            Init();
        }
        public frm_TachBan(string maBan, string maHD)
        {
            hostMaBan = maBan;
            hostMaHD = maHD;
            Init();
        }
        private void Init()
        {
            InitializeComponent();
            TaoDSban();
        }
        public Panel taoBan(string maBan, string TenBan, string trangthai)
        {
            Panel panel = new Panel
            {
                Width = 65,
                Height = 65,
                // Set the border style
                BorderStyle = BorderStyle.FixedSingle,
                Name = TenBan,
                BackgroundImage = Properties.Resources.chair,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            //màu theo trạng thái và TAG
            switch (trangthai)
            {
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaCoKhach)://trangThaiBanCoKhach
                    {
                        panel.BackColor = xuLyBan.mauCoKhach;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiDaCoKhach;
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaDat)://trangThaiBanDaDat
                    {
                        panel.BackColor = xuLyBan.mauBanDaDat; 
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiDaDat;
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiBanTrong): //trangThaiBanTrong
                    {
                        panel.BackColor = xuLyBan.mauBanTrong; 
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiBanTrong;
                        break;
                    }
                default:
                    break;
            }
            panel.Click += Panel_Click;
            //Label label = new Label
            //{
            //    Text = TenBan,
            //    Location = new Point(0, 0),
            //    Name = maBan,
            //    Font = new Font("Arial", 12), // Set the font with size 12
            //};
            //panel.Controls.Add(label);
            return panel;
        }
        private void khoiTaoDTBL_CTHoaDonChinh()
        {
            tableChinh = new DataTable();
            tableChinh.Columns.Add(nameTenSP);
            tableChinh.Columns.Add(nameSoLuong);
            tableChinh.Columns.Add(nameDonGia);
            tableChinh.Columns.Add(nameThanhTien);
            DGVChinh.DataSource = tableChinh;
        }
        private void khoiTaoDTBL_CTHoaDonDangChon()
        {
            tableDangChon = new DataTable();
            tableDangChon.Columns.Add(nameTenSP);
            tableDangChon.Columns.Add(nameSoLuong);
            tableDangChon.Columns.Add(nameDonGia);
            tableDangChon.Columns.Add(nameThanhTien);
            DGVDangChon.DataSource = tableDangChon;
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
            maBanDangChon = maBan;
            khoiTaoDTBL_CTHoaDonDangChon();
            HoaDon hd = xuLyHoaDon.LayHoaDon(maBan, xuLyHoaDon.trangthaiChuaThanhToan);
            if(hd != null) { maHDDangChon = hd.MaHD; }
            if (maBan.Trim().Equals(hostMaBan.Trim()))
            {
                MessageBox.Show("Chọn trùng bàn hiện tại");
                return;
            }
            switch (p.Tag)
            {
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaCoKhach)://trangThaiBanCoKhach
                    {
                        //hiển thị hóa đơn bàn đó lên
                        if (hd != null)
                        {
                            btnChonSP.Enabled = true;
                            btnTaoHoaDon.Enabled = false;
                            txtMaHD.Text = hd.MaHD;
                            chiTietHoaDonDangChon = new List<ChiTietHoaDon>();
                            chiTietHoaDonDangChon = xuLyChiTietHoaDon.LayChiTietHoaDon(hd.MaHD);
                            LoadDGV_CTHoaDonDangChon(chiTietHoaDonDangChon);
                        }
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiBanTrong)://trangThaiBanCoKhach
                    {
                        khoiTaoDTBL_CTHoaDonDangChon();
                        btnChonSP.Enabled = false;
                        btnTaoHoaDon.Enabled = true;
                        break;
                    }
                default:
                    {
                        khoiTaoDTBL_CTHoaDonDangChon();
                    }
                    break;
            }
        }
        private void LoadDGV_CTHoaDonDangChon()
        {
            chiTietHoaDonDangChon = new List<ChiTietHoaDon>();
            chiTietHoaDonDangChon = xuLyChiTietHoaDon.LayChiTietHoaDon(maHDDangChon);
            LoadDGV_CTHoaDonDangChon(chiTietHoaDonDangChon);
        }
        private void LoadDGV_CTHoaDonDangChon(List<ChiTietHoaDon> cthoadons)
        {
            khoiTaoDTBL_CTHoaDonDangChon();
            if (cthoadons != null)
            {
                foreach (ChiTietHoaDon cthd in cthoadons)
                {
                    LoadDGV_CTHoaDonDangChon(cthd);
                }
            }
        }
        private void LoadDGV_CTHoaDonChinh()
        {
            chiTietHoaDonChinh = new List<ChiTietHoaDon>();
            chiTietHoaDonChinh = xuLyChiTietHoaDon.LayChiTietHoaDon(hostMaHD);
            LoadDGV_CTHoaDonChinh(chiTietHoaDonChinh);
        }
        private void LoadDGV_CTHoaDonChinh(List<ChiTietHoaDon> cthoadons)
        {
            khoiTaoDTBL_CTHoaDonChinh();
            if (cthoadons != null)
            {
                foreach (ChiTietHoaDon cthd in cthoadons)
                {
                    LoadDGV_CTHoaDonChinh(cthd);
                }
            }
        }
        private void LoadDGV_CTHoaDonDangChon(ChiTietHoaDon cthd)
        {
            if (cthd != null)
            {
                DataRow row = tableDangChon.NewRow();
                row[nameTenSP] = xuLySanPham.layTenSP(cthd.MaSP);
                row[nameSoLuong] = cthd.SoLuong.Value;
                row[nameDonGia] = cthd.DonGia;
                row[nameThanhTien] = cthd.SoLuong * cthd.DonGia;
                tableDangChon.Rows.Add(row);
                DGVDangChon.DataSource = tableDangChon;
            }
        }
        private void LoadDGV_CTHoaDonChinh(ChiTietHoaDon cthd)
        {
            if (cthd != null)
            {
                DataRow row = tableChinh.NewRow();
                row[nameTenSP] = xuLySanPham.layTenSP(cthd.MaSP);
                row[nameSoLuong] = cthd.SoLuong.Value;
                row[nameDonGia] = cthd.DonGia;
                row[nameThanhTien] = cthd.SoLuong * cthd.DonGia;
                tableChinh.Rows.Add(row);
                DGVChinh.DataSource = tableChinh;
            }
        }
        private void btnChonSP_Click(object sender, EventArgs e)
        {
            if (indexChinh == -1)
            {
                MessageBox.Show("bạn quên chọn sản phẩm"); return;
            }
            int slchon = int.Parse(txtSoLuong.Value.ToString());
            if (indexChinh != -1)
            {
                //tách từ hóa đơn chính ra hóa đơn phụ 
                //kiểm tra số lượng cân tách
                if(slchon >= chiTietHoaDonChinh[indexChinh].SoLuong) //chuyển qua hết
                {
                    //lấy sản phẩm hóa đơn chính
                    ChiTietHoaDon CTHD_Chinh = new ChiTietHoaDon(); //hóa đưa chuyển 
                    CTHD_Chinh.MaHD = maHDDangChon;
                    CTHD_Chinh.MaSP = chiTietHoaDonChinh[indexChinh].MaSP;
                    CTHD_Chinh.DonGia = chiTietHoaDonChinh[indexChinh].DonGia;
                    CTHD_Chinh.SoLuong = chiTietHoaDonChinh[indexChinh].SoLuong;
                    //xóa bên cái chính
                    xuLyChiTietHoaDon.Xoa_CTHoaDon(chiTietHoaDonChinh[indexChinh].MaHD, chiTietHoaDonChinh[indexChinh].MaSP);
                    //cập nhật cho đang chọn
                    bool checktontai = xuLyChiTietHoaDon.KT_TrungChiTiet(CTHD_Chinh.MaHD, CTHD_Chinh.MaSP);
                    if (checktontai == true)
                    {
                        //tăng số lượng
                        xuLyChiTietHoaDon.congThemSL(CTHD_Chinh.MaSP,CTHD_Chinh.MaHD, CTHD_Chinh.SoLuong.Value);
                    }
                    else
                    {
                        //thêm mới
                        xuLyChiTietHoaDon.Them_CTHoaDon(CTHD_Chinh);
                    }
                }
                else
                {
                    //chuyển theo số lượng cần
                    ChiTietHoaDon CTHD_Chinh = new ChiTietHoaDon();  //hóa đưa chuyển 
                    CTHD_Chinh.MaHD = maHDDangChon;
                    CTHD_Chinh.MaSP = chiTietHoaDonChinh[indexChinh].MaSP;
                    CTHD_Chinh.DonGia = chiTietHoaDonChinh[indexChinh].DonGia;
                    CTHD_Chinh.SoLuong = slchon;
                    //thêm mới
                    // kiểm tra trung 
                    bool checkTrung = xuLyChiTietHoaDon.KT_TrungChiTiet(CTHD_Chinh.MaHD, CTHD_Chinh.MaSP);
                    if(checkTrung == true)
                    {
                        //tăng số lượng
                        xuLyChiTietHoaDon.congThemSL(CTHD_Chinh.MaHD,CTHD_Chinh.MaSP,slchon);
                    }
                    else
                    {
                        xuLyChiTietHoaDon.Them_CTHoaDon(CTHD_Chinh);
                    }
                    //cập nhật lại số lượng cho hóa đơn chính
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.MaHD = chiTietHoaDonChinh[indexChinh].MaHD;
                    ct.MaSP = chiTietHoaDonChinh[indexChinh].MaSP;
                    ct.DonGia = chiTietHoaDonChinh[indexChinh].DonGia;
                    ct.SoLuong = slchon;
                    xuLyChiTietHoaDon.capNhatSL(ct.MaSP,ct.MaHD, ct.SoLuong.Value);
                }
                LoadDGV_CTHoaDonDangChon();
                LoadDGV_CTHoaDonChinh();
            }
        }
        private void frm_TachBan_Load(object sender, EventArgs e)
        {
            //load chi tiết hóa đơn chính
            chiTietHoaDonChinh = new List<ChiTietHoaDon>();
            chiTietHoaDonChinh = xuLyChiTietHoaDon.LayChiTietHoaDon(hostMaHD);
            LoadDGV_CTHoaDonChinh(chiTietHoaDonChinh);
        }
        int indexChinh = -1;
        private void DGVChinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexChinh = e.RowIndex;
        }
        int indexDGVDangChonClick = -1;
        private void DGVDangChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDGVDangChonClick = e.RowIndex;
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {

            string maban = maBanDangChon;
            //cập nhật trạng thái bàn 
            string matrangthai = xuLyTrangThaiBan.maTrangThaiDaCoKhach; //trangThaiBanCoKhach
            int kq = xuLyBan.capNhatTrangThaiBan(maban, matrangthai);
            //thêm mới hóa đơn
            HoaDon hd = new HoaDon();
            hd.MaHD = Librari.CreateMaHoaDon();
            hd.MaNV = frm_DangNhap.nvDangSuDung.MaNV ;
            hd.MaKH = null;
            hd.MaBan = maban;
            hd.Giamgia = 0;
            hd.DiemTL = 0;
            hd.NgayLap = DateTime.Today;
            hd.TrangThai = xuLyHoaDon.trangthaiChuaThanhToan;//trangThaiHD_chuaTT
            kq = xuLyHoaDon.Them(hd);
            txtMaHD.Text = hd.MaHD;
            //reload lại bàn
            if (kq == 1)
            {
                MessageBox.Show("Tạo thành công");
                groupBox1.Controls.Clear();
                TaoDSban();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSoLuong_ValueChanged(object sender, EventArgs e)
        {
            int sl =int.Parse (txtSoLuong.Value.ToString());
            if(sl < 1)
            {
                MessageBox.Show("Bạn không được nhập số lượng nhỏ hơn 1");
            }
        }

        private void DGVDangChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDGVDangChonClick = e.RowIndex;
        }

        private void DGVChinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexChinh = e.RowIndex;
        }

        private void btnBoChonSP_Click(object sender, EventArgs e)
        {
            if (indexDGVDangChonClick == -1) { MessageBox.Show("Bạn quên chọn"); return; }
            int slchuyen =int.Parse( txtSoLuong.Value.ToString());
            if(indexDGVDangChonClick != -1)
            {
                if (slchuyen >= chiTietHoaDonDangChon[indexDGVDangChonClick].SoLuong) //chuyển hết
                {
                    ChiTietHoaDon ctnew = new ChiTietHoaDon(); //tạo chi tiết mới cho DGV chính
                    ctnew.MaHD = hostMaHD;
                    ctnew.MaSP = chiTietHoaDonDangChon[indexDGVDangChonClick].MaSP;
                    ctnew.DonGia = chiTietHoaDonDangChon[indexDGVDangChonClick].DonGia;
                    ctnew.SoLuong = chiTietHoaDonDangChon[indexDGVDangChonClick].SoLuong;
                    //xóa bên đang chọn
                    xuLyChiTietHoaDon.Xoa_CTHoaDon(chiTietHoaDonDangChon[indexDGVDangChonClick].MaHD, chiTietHoaDonDangChon[indexDGVDangChonClick].MaSP);
                    //thêm mới cho hóa đơn chính
                    bool checktongtai = xuLyChiTietHoaDon.KT_TrungChiTiet(ctnew.MaHD,ctnew.MaSP);
                    if (checktongtai)
                    {
                        //tăng số lượng
                        xuLyChiTietHoaDon.congThemSL(ctnew.MaHD,ctnew.MaSP,ctnew.SoLuong.Value);
                    }
                    else
                    {
                        //thêm mơi
                        xuLyChiTietHoaDon.Them_CTHoaDon(ctnew);
                    }
                }
                else
                {
                    //chuyển theo số lượng
                    ChiTietHoaDon ctnew = new ChiTietHoaDon(); //tạo chi tiết mới cho DGV chính
                    ctnew.MaHD = hostMaHD;
                    ctnew.MaSP = chiTietHoaDonDangChon[indexDGVDangChonClick].MaSP;
                    ctnew.DonGia = chiTietHoaDonDangChon[indexDGVDangChonClick].DonGia;
                    ctnew.SoLuong = slchuyen;
                    bool checktongtai = xuLyChiTietHoaDon.KT_TrungChiTiet(ctnew.MaHD, ctnew.MaSP);
                    if (checktongtai)
                    {
                        //tăng số lượng
                        xuLyChiTietHoaDon.congThemSL(ctnew.MaHD, ctnew.MaSP, ctnew.SoLuong.Value);
                    }
                    else
                    {
                        //thêm mơi
                        xuLyChiTietHoaDon.Them_CTHoaDon(ctnew);
                    }
                    //cập nhật lại số lượng bên cũ
                    xuLyChiTietHoaDon.capNhatSL(
                        chiTietHoaDonDangChon[indexDGVDangChonClick].MaHD,
                        chiTietHoaDonDangChon[indexDGVDangChonClick].MaSP,
                        (chiTietHoaDonDangChon[indexDGVDangChonClick].SoLuong.Value-slchuyen));
                }
            }
            LoadDGV_CTHoaDonChinh();
            LoadDGV_CTHoaDonDangChon();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //string maHD = txtMaHD.Text;
            //string tenBan = txtTenBan.Text;
            //string maban = xuLyBan.LayMaBan(tenBan);
            //List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();
            //if (danhSachPanelDaChon.Count != 1)
            //{
            //    MessageBox.Show("Vui lòng chọn một bàn để tách hoá đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            ////cập nhật trạng thái bàn 
            //string matrangthai = xuLyTrangThaiBan.layMaTrangThai(trangThaiBanCoKhach);
            //int kq = xuLyBan.capNhatTrangThaiBan(maban, matrangthai);
            ////Lấy hoá đơn
            //HoaDon hd = new HoaDon();
            //hd.MaBan = maban;
            //hd.NgayLap = DateTime.Now;
            //hd.TrangThai = trangThaiHD_chuaTT;
            //hd.TongTien = cthd.Sum(x => x.DonGia * x.SoLuong);
            //kq = xuLyHoaDon.Them(hd);
            //txtMaHD.Text = hd.MaHD;
            
            //xuLyBan.capNhatTrangThaiBan(maban, trangThaiBanTrong);

            //TaoDSban();
            //danhSachPanelDaChon.Clear();
            ////LoadDGV_CTHoaDon(gopHD);
            ////reload lại bàn
            //if (kq == 1)
            //{
            //    MessageBox.Show("Tách thành công");
            //    TaoDSban();
            //    //CoHieuLucControl(btnChon);
            //}
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
                    y += 90;
                }
            }
            catch { }
        }
    }
}
