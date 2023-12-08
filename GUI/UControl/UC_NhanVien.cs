using BLL.Core;
using BLL.DB;
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

namespace GUI.UControl
{
    public partial class UC_NhanVien : UserControl
    {
        XuLyNhanVien xl = new XuLyNhanVien();
        public UC_NhanVien()
        {
            InitializeComponent();
            Init();
            LoadCombb_Quyen();
            txtMaNV.Enabled = txtTenNV.Enabled = txtSoDT.Enabled = txtChucVu.Enabled = txtDiaChi.Enabled = txtTenDN.Enabled = txtMatKhau.Enabled = cbb_Quyen.Enabled = false;
            btn_Sua.Enabled = btn_Xoa.Enabled = btn_Luu.Enabled = false;
        }
        public void Init()
        {
            List<NHANVIEN> list = xl.getAllNhanVien();
            if (list != null)
            {
                LoadDataGView(list);
            }
        }
        public void LoadCombb_Quyen()
        {
            cbb_Quyen.DataSource = xl.getAllQuyen();
            cbb_Quyen.DisplayMember = "TenQuyen";
            cbb_Quyen.ValueMember = "MaQuyen";
        }
        public void LoadDataGView(List<NHANVIEN> dsnv)
        {

            dgv_NhanVien.DataSource = dsnv;
            dgv_NhanVien.Columns["QUYEN"].Visible = false;
        }
        public NHANVIEN getDataControls()
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MaNV = txtMaNV.Text;
                nv.TenNV = txtTenNV.Text;
                nv.ChucVu = txtChucVu.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.SoDT = txtSoDT.Text;
                nv.TenDangNhap = txtTenDN.Text;
                nv.Matkhau = txtMatKhau.Text;
                nv.MaQuyen = cbb_Quyen.SelectedValue?.ToString();

                // Sử dụng Value thay vì Text nếu dateTime_NVL là DateTimePicker
                nv.NgayVaoLam = dateTime_NVL.Value;

                // Kiểm tra giới tính
                if (rdo_Nam.Checked)
                {
                    nv.GioiTinh = "Nam";
                }
                else if (rdo_Nu.Checked)
                {
                    nv.GioiTinh = "Nữ";
                }
                else
                {

                    nv.GioiTinh = "Không xác định";
                }

                return nv;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Lỗi trong getDataControls: {ex.Message}");
                return null;
            }
        }



        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhân xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xl.XoaNhanVien(txtMaNV.Text);
                if (kq == 1)
                {
                    MessageBox.Show("Thành Công");
                    Init();
                    return;
                }
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
            txtTenNV.Enabled = true;
            txtChucVu.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDT.Enabled = true;
            txtTenDN.Enabled = true;
            txtMatKhau.Enabled = true;
            cbb_Quyen.Enabled = true;
            string gioitinh;
            if (rdo_Nam.Checked)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            DateTime dateTime_NVL = DateTime.Now;
            btn_Luu.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

            txtTenNV.Enabled = true;
            txtChucVu.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDT.Enabled = true;
            txtTenDN.Enabled = true;
            txtMatKhau.Enabled = true;
            cbb_Quyen.Enabled = true;
            rdo_Nam.Enabled = true;
            rdo_Nu.Enabled = true;
            dateTime_NVL.Enabled = true;
            btn_Luu.Enabled = true;

        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            bool kqKT = xl.KT_MaNhanVien(txtMaNV.Text.ToString());
            NHANVIEN nhanvien = getDataControls();
            if (kqKT == false)
            {
                int kq = xl.ThemNhanVien(nhanvien);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                    Init();
                    txtMaNV.Enabled = false;
                    txtTenNV.Enabled = false;
                    txtChucVu.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtTenDN.Enabled = false;
                    txtMatKhau.Enabled = false;
                    cbb_Quyen.Enabled = false;
                    txtSoDT.Enabled = false;
                    dateTime_NVL.Enabled = false;
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
                txtMaNV.Enabled = false;
                txtTenNV.Enabled = false;
                txtChucVu.Enabled = false;
                txtDiaChi.Enabled = false;
                txtTenDN.Enabled = false;
                txtMatKhau.Enabled = false;
                cbb_Quyen.Enabled = false;
                txtSoDT.Enabled = false;
                dateTime_NVL.Enabled = false;

            }

            if (kqKT == true)
            {
                int kq = xl.SuaNhanVien(nhanvien);
                if (kq == 1)
                {
                    MessageBox.Show("Sửa thành công ");
                    Init();
                    txtMaNV.Enabled = false;
                    txtTenNV.Enabled = false;
                    txtChucVu.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtTenDN.Enabled = false;
                    txtMatKhau.Enabled = false;
                    cbb_Quyen.Enabled = false;
                    txtSoDT.Enabled = false;
                    dateTime_NVL.Enabled = false;
                    return;
                }
                MessageBox.Show("Sửa thất bại ");
                txtMaNV.Enabled = false;
                txtTenNV.Enabled = false;
                txtChucVu.Enabled = false;
                txtDiaChi.Enabled = false;
                txtTenDN.Enabled = false;
                txtMatKhau.Enabled = false;
                cbb_Quyen.Enabled = false;
                txtSoDT.Enabled = false;
                dateTime_NVL.Enabled = false;
            }
        }

        private void dgv_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgv_NhanVien.Rows[e.RowIndex];
                // Hiển thị thông tin trên TextBox khi chọn một dòng
                txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["TenNV"].Value.ToString();
                txtSoDT.Text = selectedRow.Cells["SoDT"].Value.ToString();
                txtChucVu.Text = selectedRow.Cells["ChucVu"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtTenDN.Text = selectedRow.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = selectedRow.Cells["MatKhau"].Value.ToString();
                cbb_Quyen.SelectedValue = selectedRow.Cells["MaQuyen"].Value.ToString();
                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdo_Nam.Checked = true;
                    rdo_Nu.Checked = false;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdo_Nam.Checked = false;
                    rdo_Nu.Checked = true;
                }
                else
                {
                    rdo_Nam.Checked = false;
                    rdo_Nu.Checked = false;
                }
            }
        }

        private void dgv_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            btn_Xoa.Enabled = btn_Sua.Enabled = true;
        }
    }
}
