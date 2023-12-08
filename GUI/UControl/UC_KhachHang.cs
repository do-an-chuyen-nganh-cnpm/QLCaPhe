using BLL.Core;
using BLL.DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.UControl
{
    public partial class UC_KhachHang : UserControl
    {
     
        public UC_KhachHang()
        {
            InitializeComponent();
            loadCBMaLoaiKH();
            Init();
        }
        XuLyKhachHang xuLyKhachHang = new XuLyKhachHang();
        XuLyLoaiKhachHang xuLyLoaiKhachHang = new XuLyLoaiKhachHang();
        public void Init() {
            dtgv_KhachHang.DataSource = xuLyKhachHang.getAllKhachHang();
            voHieuHoatxt();
        }
        public void hienThi()
        {
            List<KHACHHANG> liskh = xuLyKhachHang.getAllKhachHang();
            if (liskh != null)
            {
                dtgv_KhachHang.DataSource = liskh;
            }
        }
        public void loadCBMaLoaiKH()
        {
            cb_MaLoaiKH.DataSource = xuLyLoaiKhachHang.getAll();
            cb_MaLoaiKH.ValueMember = "MaLoaiKH";
            cb_MaLoaiKH.DisplayMember = "TenLoaiKH";
        }
        private KHACHHANG getDataControls()
        {
            try
            {
                KHACHHANG kh = new KHACHHANG();
                kh.MaKH = txt_MaKH.Text;
                kh.TenKH = txt_TenKH.Text;
                kh.MaLoaiKH = cb_MaLoaiKH.SelectedValue.ToString();
                kh.DiaChi = txt_DiaChi.Text;
                kh.SoDT = txt_SDT.Text;
                kh.DiemTL = double.Parse(txt_DiemTL.Text);
                return kh;
            }
            catch { return null; }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //kiểm tra trùng
            bool kqKT =xuLyKhachHang.KT_TonTai(txt_MaKH.Text.ToString());
            KHACHHANG kh = getDataControls();
            //không trùng thêm mới 
            if (kqKT == false)
            {
                int kq = xuLyKhachHang. ThemKH(kh);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                   
                    voHieuHoatxt();
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
                voHieuHoatxt();

            }
            //trùng thì cập nhật
            if (kqKT == true)
            {
                int kq =xuLyKhachHang. SuaKH(kh);
                if (kq == 1)
                {
                    MessageBox.Show("Sửa thành công ");
                    hienThi();
                    voHieuHoatxt();
                    return;
                }
                MessageBox.Show("Sửa thất bại ");
                voHieuHoatxt();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearData();
            coHieuLuctxt();
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Thông báo", "Xác nhân xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xuLyKhachHang. XoaKH(txt_MaKH.Text);
                if (kq == 1) { MessageBox.Show("Thành Công"); hienThi(); return; }
                MessageBox.Show("Thất bại");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            coHieuLuctxt();
        }
        private void dtgv_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (dtgv_KhachHang.CurrentCell.Value != null)
                {
                    txt_MaKH.Text = dtgv_KhachHang.Rows[index].Cells["MaKH"].Value.ToString();
                    txt_TenKH.Text = dtgv_KhachHang.Rows[index].Cells["TenKH"].Value.ToString();
                    txt_DiaChi.Text = dtgv_KhachHang.Rows[index].Cells["DiaChi"].Value.ToString();
                    cb_MaLoaiKH.SelectedValue = dtgv_KhachHang.Rows[index].Cells["MaLoaiKH"].Value.ToString();
                    txt_SDT.Text = dtgv_KhachHang.Rows[index].Cells["SoDT"].Value.ToString();
                    txt_DiemTL.Text = dtgv_KhachHang.Rows[index].Cells["DiemTL"].Value.ToString();
                }
            }
            catch { }
        }

        public void voHieuHoatxt()
        {
            txt_MaKH.Enabled = false;
            txt_TenKH.Enabled = false;
            txt_DiaChi.Enabled = false;
            txt_DiemTL.Enabled = false;
            txt_SDT.Enabled = false;
            cb_MaLoaiKH.Enabled = false;
        }

        public void coHieuLuctxt()
        {
            txt_MaKH.Enabled = true;
            txt_TenKH.Enabled = true;
            txt_DiaChi.Enabled = true;
            txt_DiemTL.Enabled = true;
            txt_SDT.Enabled = true;
            cb_MaLoaiKH.Enabled = true;
        }

        public void ClearData()
        {
            txt_MaKH.Clear();
            txt_DiaChi.Clear();
            txt_TenKH.Clear();
            txt_DiemTL.Clear();
            txt_SDT.Clear();
        }
    }
}
