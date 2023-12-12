using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Core;
using BLL.DB;

namespace GUI.UControl
{
   
    public partial class UC_TinhLuongNhanVien : UserControl
    {
        XuLyChiTietCaLamViec xuLy = new XuLyChiTietCaLamViec();
        XuLyCaLamViec ca = new XuLyCaLamViec();
        XuLyNhanVien nv = new XuLyNhanVien();
        BaseXuLy xl = new BaseXuLy();
        DataTable dataTable;
        private string MaCLV = "Ca Làm Việc";
        private string MaNV = "Nhân Viên";
        private string NgayVaoLam = "Ngày Vào Làm";
        private string NgayTanLam = "Ngày Tan Làm";
        private string ThanhTien = "Thành Tiền";
        public UC_TinhLuongNhanVien()
        {
            InitializeComponent();
            hienThi();
            LoadCBNhanVien();
            LoadCBCaLam();
        }

        private void khoiTaoDTBL_CTHoaDon()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(MaCLV);
            dataTable.Columns.Add(MaNV);
            dataTable.Columns.Add(NgayVaoLam);
            dataTable.Columns.Add(NgayTanLam);
            dataTable.Columns.Add(ThanhTien);
            dtgv_BangLuong.DataSource = dataTable;
        }
        private void LoadDataGridView(List<ChiTietCaLamNhanvien> ds)
        {
            dtgv_BangLuong.DataSource = null;
            // Clear existing data
            dtgv_BangLuong.Rows.Clear();
            foreach (ChiTietCaLamNhanvien item in ds)
            {
                int indexRow = dtgv_BangLuong.Rows.Add();
                dtgv_BangLuong.Rows[indexRow].Cells["MaCLV"].Value = item.MaCLV;
                dtgv_BangLuong.Rows[indexRow].Cells["MaNV"].Value = item.MaNV;
                dtgv_BangLuong.Rows[indexRow].Cells["NgayVaoLam"].Value = item.NgayVaoLam;
                dtgv_BangLuong.Rows[indexRow].Cells["NgayTanLam"].Value = item.NgayTanLam;
                dtgv_BangLuong.Rows[indexRow].Cells["ThanhTien"].Value = item.Thanhtien;
            }

        }
        private void LoadCBNhanVien()
        {
            cb_NhanVien.DataSource = nv.getAllNhanVien();
            cb_NhanVien.ValueMember = "MaNV";
            cb_NhanVien.DisplayMember = "TenNV";
        }
        private void LoadCBCaLam()
        {
            cb_CaLamViec.DataSource = ca.getAllCaLamViec();
            cb_CaLamViec.ValueMember = "MaCLV";
            cb_CaLamViec.DisplayMember = "TenCLV";
        }
        private void ThemDuLieuDataGridView(ChiTietCaLamNhanvien tk)
        {
            DataRow row = dataTable.NewRow();
            
            row[MaCLV] = tk.MaCLV;
            row[MaNV] = tk.MaNV;
            row[NgayVaoLam] = tk.NgayVaoLam.ToString("dd/MM/yyyy");
            row[NgayTanLam] = tk.NgayTanLam.Value.ToString("dd/MM/yyyy");
            row[ThanhTien] = tk.Thanhtien;
            dataTable.Rows.Add(row);
        }
        private void ThemDuLieuDataGridView(List<ChiTietCaLamNhanvien> lst)
        {
            khoiTaoDTBL_CTHoaDon();
            foreach (ChiTietCaLamNhanvien item in lst)
            {
                ThemDuLieuDataGridView(item);
            }
            dtgv_BangLuong.DataSource = dataTable;
        }
        public void hienThi()
        {
            List<ChiTietCaLamNhanvien> list = xuLy.getAllChiTietCaLam();
            if (list != null)
            {
                khoiTaoDTBL_CTHoaDon();
                ThemDuLieuDataGridView(list);
                //dtgv_BangLuong.DataSource = list;
                //dtgv_BangLuong.Columns["CaLamViec"].Visible = false;
                //dtgv_BangLuong.Columns["NHANVIEN"].Visible = false;
            }
        }

        private ChiTietCaLamNhanvien getDataControls()
        {
            try
            {
                ChiTietCaLamNhanvien c = new ChiTietCaLamNhanvien();
                c.MaCLV = cb_CaLamViec.SelectedValue.ToString();
                c.MaNV = cb_NhanVien.SelectedValue.ToString();
                c.NgayVaoLam = dtp_NgayVaoLam.Value;
                c.NgayTanLam = dtp_NgayTanLam.Value;
                
                return c;
            }
            catch { return null; }
        }

        public void voHieuHoatxt()
        {
            cb_CaLamViec.Enabled = false;
            cb_NhanVien.Enabled = false;
            dtp_NgayVaoLam.Enabled = false;
            dtp_NgayTanLam.Enabled = false;
            //txtThanhTien.Enabled = false;

        }

        public void coHieuLuctxt()
        {
            cb_CaLamViec.Enabled = true;
            cb_NhanVien.Enabled = true;
            dtp_NgayVaoLam.Enabled = true;
            dtp_NgayTanLam.Enabled = true;
            //txtThanhTien.Enabled = true;

        }

       
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChiTietCaLamNhanvien c = getDataControls();
            try
            {
                int kq = xuLy.Them(c);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                    hienThi();
                    
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
                
            }
            catch { }
        }

       

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show( "Xác nhân xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xuLy.Xoa(cb_NhanVien.Text);
                if (kq == 1) { MessageBox.Show("Thành Công"); hienThi(); return; }
                MessageBox.Show("Thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChiTietCaLamNhanvien c = getDataControls();
            try
            {
                int kq = xuLy.Sua(c);
                if (kq == 1)
                {
                    MessageBox.Show("Sửa thành công ");
                    hienThi();
                    
                    return;
                }
                MessageBox.Show("Sửa thất bại ");
                
            }
            catch { }
        }

        

        private void dtgv_BangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (dtgv_BangLuong.CurrentCell.Value != null)
                {
                    cb_CaLamViec.Text = dtgv_BangLuong.Rows[index].Cells[MaCLV].Value.ToString();
                    cb_NhanVien.Text = dtgv_BangLuong.Rows[index].Cells[MaNV].Value.ToString();
                    //dtp_NgayVaoLam.Value = DateTime.Parse(dtgv_BangLuong.Rows[index].Cells[NgayVaoLam].Value.ToString());
                    //dtp_NgayTanLam.Value = DateTime.Parse(dtgv_BangLuong.Rows[index].Cells["NgayTanLam"].Value.ToString());
                }
            }
            catch { }
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
        private void dtp_NgayTanLam_ValueChanged(object sender, EventArgs e)
        {
            DateTime endDate = dtp_NgayTanLam.Value.Date;

            var query = from chiTiet in xl.ctx.ChiTietCaLamNhanviens
                        where chiTiet.NgayTanLam.Value.Date== endDate.Date
                        //where DateTime.Equals(chiTiet.NgayTanLam, endDate.Date)
                        select chiTiet;

            // Bind the result to the DataGridView
            dtgv_BangLuong.DataSource = query.ToList();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            hienThi();
        }
    }
}
