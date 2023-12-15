using BLL;
using BLL.Core;
using BLL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UControl
{
    public partial class UC_KhuyenMai : UserControl
    {
        DataGridView dataGrid;
        XuLyKhuyenMai xuLyKM = new XuLyKhuyenMai();
        //các cốt 
        private const string nameMaKM = "Mã khuyến mãi";
        private const string nameTenKM = "Tên khuyến mãi";
        private const string nameMota = "Mô tả";
        private const string nameNgayBD = "Ngày bắt đầu";
        private const string nameNgayKT = "Ngày kết thúc";
        private const string namePhanTramGiamGia = "Phần trăm giảm giá";
        private const string nameTrangThai = "Trang Thái";
        DataTable tblKhuyenMai;
        public UC_KhuyenMai()
        {
            InitializeComponent();
            Init();

        }
        private void Init()
        {
            TaoDataGridView();
            //vô hiệu hóa
            VoHieuHoa(txtMaKM);
            VoHieuHoa(txtTenKM);
            VoHieuHoa(txtMoTa);
            VoHieuHoa(txtNgayBD);
            VoHieuHoa(txtNgayKT);
            VoHieuHoa(txtTriGia);
            List<KHUYEN_MAI> list = xuLyKM.getAllKhuyenMai();
            if (list != null)
            {
                ThemDDuLieuVafoDataaGridView(list);
            }
        }
        private void reloadDataGridView()
        {
            TaoDataGridView();
            List<KHUYEN_MAI> list = xuLyKM.getAllKhuyenMai();
            if(list != null)
            {
                ThemDDuLieuVafoDataaGridView(list);
            }
        }
        private void ThemDDuLieuVafoDataaGridView(List<KHUYEN_MAI> listKM)
        {
            TaoDataGridView();
            foreach(KHUYEN_MAI item in listKM)
            {
                DataRow row = tblKhuyenMai.NewRow();
                row[nameMaKM] = item.MaKhuyenMai;
                row[nameTenKM] = item.TenKhuyenMai;
                row[nameMota] = item.MoTa;
                row[nameNgayBD] = item.NgayBD.Value.ToString("dd/MM/yyyy");
                row[nameNgayKT] = item.NgayKT.Value.ToString("dd/MM/yyyy");
                row[namePhanTramGiamGia] = item.phanTramGiamGia;             
                tblKhuyenMai.Rows.Add(row); 
            }
            DGV_KhuyenMai.DataSource = tblKhuyenMai;
        }
         private void TaoDataGridView()
        {
            tblKhuyenMai = new DataTable();
            tblKhuyenMai.Columns.Add(nameMaKM, typeof(string));
            tblKhuyenMai.Columns.Add(nameTenKM, typeof(string));
            tblKhuyenMai.Columns.Add(nameMota, typeof(string));
            tblKhuyenMai.Columns.Add(nameNgayBD, typeof(string));
            tblKhuyenMai.Columns.Add(nameNgayKT, typeof(string));
            tblKhuyenMai.Columns.Add(namePhanTramGiamGia, typeof(string));
        }
        static DateTime ConvertToDateTime(string dateString)
        {
            string format = "dd/MM/yyyy";
            DateTime dateTime;

            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else
            {
                // Return DateTime.MinValue to indicate failure
                return DateTime.MinValue;
            }
        }
        private KHUYEN_MAI layDataControls()
        {
            try
            {
                KHUYEN_MAI khuyenMai = new KHUYEN_MAI();
                khuyenMai.MaKhuyenMai = txtMaKM.Text;
                khuyenMai.TenKhuyenMai = txtTenKM.Text;
                khuyenMai.MoTa = txtMoTa.Text;
                khuyenMai.NgayBD = txtNgayBD.Value;
                khuyenMai.NgayKT = txtNgayKT.Value;
                khuyenMai.phanTramGiamGia = int.Parse(txtTriGia.Text);
                return khuyenMai;
            }
            catch { return null; }
        }
        private void LoadDataControls(KHUYEN_MAI k)
        {
            try
            {
                if(k != null)
                {
                    //txtMaKM.Text = k.MAKHUYENMAI;
                    //txtTenKM.Text = k.TENKHUYENMAI;
                    //txtMoTa.Text = k.MOTA;
                    //txtNgayBD.Value = k.NGAYBD.Value;
                    //txtNgayKT.Value = k.NGAYKT.Value;
                    //txtTriGia.Text = k.TRIGIA.ToString();
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMaKM.Text = Librari.TaoMaKhuyenMai();
            txtTenKM.Clear();
            txtMoTa.Clear();
            txtTriGia.Clear();
            //có hiệu lực
            CoHieuLuc(txtTenKM);
            CoHieuLuc(txtMoTa);
            CoHieuLuc(txtNgayBD);
            CoHieuLuc(txtNgayKT);
            CoHieuLuc(txtTriGia);
            //KHUYEN_MAI k =  layDataControls();
            //if (k == null) { MessageBox.Show("Thông tin không hợp lệ !"); }
            //bool KTTrungMa = xuLyKM.KT_TonTai(k.MAKHUYENMAI);
            //if (KTTrungMa == true)
            //{
            //    MessageBox.Show("Không thể thêm vì trùng mã khuyến mãi");
            //}
            //xuLyKM.ThemKhuyenMai(k);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //kiểm tra trùng
            bool kqKT = xuLyKM.KT_TonTai(txtMaKM.Text.ToString());
            KHUYEN_MAI k = layDataControls();
            //khồng trùng thêm mới 
            if (kqKT == false)
            {
                int kq = xuLyKM.ThemKhuyenMai(k);
                if (kq == 1) {
                    MessageBox.Show("Thêm thành công ");
                    reloadDataGridView();
                    VoHieuHoa(txtTenKM);
                    VoHieuHoa(txtMoTa);
                    VoHieuHoa(txtNgayBD);
                    VoHieuHoa(txtNgayKT);
                    VoHieuHoa(txtTriGia);
                    return; }
                MessageBox.Show("Thêm thất bại ");
            }
            //trùng thì cập nhật
            if (kqKT == true)
            {
                int kq = xuLyKM.SuaKhuyeMai(k);
                if (kq == 1) { 
                    MessageBox.Show("Thêm thành công ");
                    reloadDataGridView();
                    VoHieuHoa(txtTenKM);
                    VoHieuHoa(txtMoTa);
                    VoHieuHoa(txtNgayBD);
                    VoHieuHoa(txtNgayKT);
                    VoHieuHoa(txtTriGia);
                    return; }
                MessageBox.Show("Thêm thất bại ");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CoHieuLuc(txtTenKM);
            CoHieuLuc(txtMoTa);
            CoHieuLuc(txtNgayBD);
            CoHieuLuc(txtNgayKT);
            CoHieuLuc(txtTriGia);
        }
        private void VoHieuHoa (Control ctr)
        {
            if(ctr is TextBox)
            {
                TextBox t = (TextBox)ctr;
                t.ReadOnly = true;
            }
            if(ctr is DateTimePicker)
            {
                DateTimePicker t = (DateTimePicker)ctr;
                t.Enabled = false;
            }
            if(ctr is Button)
            {
                Button t = (Button)ctr;
                t.Enabled = false;
            }
        }
        private void CoHieuLuc(Control ctr)
        {
            if (ctr is TextBox)
            {
                TextBox t = (TextBox)ctr;
                t.ReadOnly = false;
            }
            if (ctr is DateTimePicker)
            {
                DateTimePicker t = (DateTimePicker)ctr;
                t.Enabled = true;
            }
            if (ctr is Button)
            {
                Button t = (Button)ctr;
                t.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Thông báo", "Xác nhân xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                int kq = xuLyKM.XoaKhuyenMai(txtMaKM.Text);
                if(kq == 1) { MessageBox.Show("Thành Công"); reloadDataGridView(); return; }
                MessageBox.Show("Thất bại");
            }
        }

        private void txtTriGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                //không phải số
                e.Handled = true;
                return;
            }
        }
        int indexClick = -1;
        private void DGV_KhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexClick = e.RowIndex;
            if(DGV_KhuyenMai.CurrentCell != null)
            {
                txtMaKM.Text = DGV_KhuyenMai.Rows[indexClick].Cells[nameMaKM].Value.ToString();
                txtTenKM.Text = DGV_KhuyenMai.Rows[indexClick].Cells[nameTenKM].Value.ToString();
                txtMoTa.Text = DGV_KhuyenMai.Rows[indexClick].Cells[nameMota].Value.ToString();
                txtNgayBD.Value = ConvertToDateTime(DGV_KhuyenMai.Rows[indexClick].Cells[nameNgayBD].Value.ToString());
                txtNgayKT.Value = ConvertToDateTime(DGV_KhuyenMai.Rows[indexClick].Cells[nameNgayKT].Value.ToString());
                txtTriGia.Text = DGV_KhuyenMai.Rows[indexClick].Cells[namePhanTramGiamGia].Value.ToString();
            }
        }
    }
}
