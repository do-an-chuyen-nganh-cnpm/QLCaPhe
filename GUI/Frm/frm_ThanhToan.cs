using BLL;
using BLL.Core;
using BLL.DB;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietQRPaymentAPI;

namespace GUI.Frm
{
    public partial class frm_ThanhToan : Form
    {
        DataTable tblHoaDon;
        private const string cl_TenSP = "Tên sản phẩm";
        private const string cl_SoLuong = "Số lượng";
        private const string cl_DonGia = "Đơn giá";
        private const string cl_ThanhTien = "Thành Tiền";
        private string maHD;
        //
        XuLyChiTietHoaDon xuLyChiTietHoaDon = new XuLyChiTietHoaDon();
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        XuLyHoaDon xulyhoadon = new XuLyHoaDon();
        public frm_ThanhToan()
        {
            Init();
        }
        public frm_ThanhToan(string maHD)
        {
            this.maHD = maHD;
            Init();
        }
        private void Init()
        {
            InitializeComponent();
            LoadDuLieu();
            LoadTT_HoaDon();
        }

        private void LoadTT_HoaDon()
        {
            HoaDon hoaDon = xuLyHoaDon.LayHoaDon(maHD);
            if (hoaDon != null)
            {
                txtMaHoaDon.Text = hoaDon.MaHD.ToString();
                txtTongTien.Text = hoaDon.TongTien.ToString();
                txtGiamGia.Text = "0";
                txtThanhToan.Text = (hoaDon.TongTien - double.Parse(txtGiamGia.Text)).ToString();
            }
        }
        private void frm_ThanhToan_Load(object sender, EventArgs e)
        {
            string maKH = Librari.CreateMaKhachHang();
            txtMaKH.Text = maKH;
            txtTenKH.Text = maHD.Trim() +"-"+ maKH.Trim();
            txtSoDienThoai.Text = "null";
            txtDiemTichLuy.Text = "0";
        }        

        private void KhoiTaoDataTable()
        {
            tblHoaDon = new DataTable();
            tblHoaDon.Columns.Add(cl_TenSP, typeof(string));
            tblHoaDon.Columns.Add(cl_SoLuong, typeof(string));
            tblHoaDon.Columns.Add(cl_DonGia, typeof(string));
            tblHoaDon.Columns.Add(cl_ThanhTien, typeof(string));
        }
        private void LoadDuLieu()
        {
            List<ChiTietHoaDon> listChiTietHoaDon = xuLyChiTietHoaDon.LayChiTietHoaDon(maHD);
            if(listChiTietHoaDon != null)
            {
                LoadDuLieu(listChiTietHoaDon);
            }
        }
        private void LoadDuLieu(List<ChiTietHoaDon> list)
        {
            KhoiTaoDataTable();
            if (list != null)
            {
                foreach (ChiTietHoaDon item in list)
                {
                    LoadDuLieu(item);
                }
            }
            DGVHoaDon.DataSource = tblHoaDon;
        }
        private void LoadDuLieu(ChiTietHoaDon chitiet)
        {
            if (chitiet != null)
            {
                DataRow row = tblHoaDon.NewRow();
                row[cl_TenSP] = chitiet.MaSP;
                row[cl_DonGia] = chitiet.DonGia.ToString();
                row[cl_SoLuong] = chitiet.SoLuong.ToString();
                row[cl_ThanhTien] = chitiet.TongTien.ToString();
                tblHoaDon.Rows.Add(row);
            }         
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtSDT_TimKiem.Text==null || txtSDT_TimKiem.Text == "") {
                MessageBox.Show("Bạn quên nhập số điện thoại");
                return;
            }
            string sdt = txtSDT_TimKiem.Text;
            KHACHHANG kh = xuLyKhachHang.timKhachHangBySDT(sdt);
            if(kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng");
            }
            else
            {
                txtTenKH.Text = kh.TenKH;
                txtSoDienThoai.Text = kh.SoDT;
                txtDiemTichLuy.Text = kh.DiemTL.ToString();     
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string _maHD = maHD;
            string sdt = txtSoDienThoai.Text;
            KHACHHANG kh = xuLyKhachHang.timKhachHangBySDT(sdt);
            if(kh == null)
            {
                //tạo mới khách hàng
                kh = new KHACHHANG();
                kh.MaKH = txtMaKH.Text.ToString();
                kh.TenKH = txtTenKH.Text.ToString();
                kh.SoDT = "0";
            }
            float diemTL =float.Parse( txtDiemTichLuyHD.Text);
            float giamGia = float.Parse(txtGiamGia.Text);
            int kq = xulyhoadon.ThanhToan(kh, maHD, diemTL, giamGia);
            if (kq == 1)
            {
                MessageBox.Show("Thanh toán thành công");
                frmMain f = new frmMain();
                f.LoadDSBan();
            }
            else { MessageBox.Show("Thanh Toán thất bại"); }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            //linl lấy thông tin các ngấn hàng https://api.vietqr.io/v2/banks
            var apiRequest = new ApiRequest();
            apiRequest.acqId = 970436; //id vietcomback
            apiRequest.accountNo = 1016761461;
            apiRequest.accountName = "TRAN VAN HIEN";
            apiRequest.amount =Convert.ToInt32(double.Parse( txtThanhToan.Text.ToString())); //tổng tiền thanh toán
            apiRequest.format = "text";
            apiRequest.template = "compact";
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);


            var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            int newWidth = QRThanhToan.Width;
            int newHeight = QRThanhToan.Height;
            Image resizedImage = new Bitmap(image, new Size(newWidth, newHeight));
            QRThanhToan.Image = resizedImage;
        }
        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maKH = Librari.CreateMaKhachHang();
            txtMaKH.Text = maKH;
            txtTenKH.Text = maHD.Trim() + "-" + maKH.Trim();
            txtSoDienThoai.Text = "null";
            txtDiemTichLuy.Text = "0";
        }

        private void btnTichDiem_Click(object sender, EventArgs e)
        {
            // 1 điểm = 25.000
            double tongTien = double.Parse(txtTongTien.Text);

            int tongdiemtichluy = Convert.ToInt32(tongTien) * 1 / 25000;
            txtDiemTichLuyHD.Text = tongdiemtichluy.ToString();
        }
    }
}
