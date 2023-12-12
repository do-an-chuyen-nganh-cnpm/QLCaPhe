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

namespace GUI.UControl
{
    public partial class UC_SanPham : UserControl
    {
        XuLySanPham xl = new XuLySanPham();
        XuLyLoaiSanPham xl_lsp = new XuLyLoaiSanPham();
        public UC_SanPham()
        {
            InitializeComponent();
            Init();
            txtMaSP.Enabled = txtTenSP.Enabled = txt_GiaSP.Enabled = txtHinhAnh.Enabled =cbb_LoaiSP.Enabled= false;
            btn_Sua.Enabled = btn_Xoa.Enabled = btn_Luu.Enabled = false;
            loadCBB_MaLoaiSP();
        }
        public void Init()
        {
            List<SanPham> list = xl.getAllSP();
            if (list != null)
            {
                 LoadDataGView(list);
 
            }
        }
        private void LoadDataGView(List<SanPham> dssp)
        {
          
            dgv_SanPham.DataSource = dssp;
            dgv_SanPham.Columns["LoaiSP"].Visible = false;

        }
        public void loadCBB_MaLoaiSP()
        {
            cbb_LoaiSP.DataSource = xl_lsp.getAllLoaiSP();
            cbb_LoaiSP.DisplayMember = "TenLoaiSP";
            cbb_LoaiSP.ValueMember = "MaLoaiSP";
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            txtTenSP .Enabled = true;
            txt_GiaSP .Enabled = true;
            txtHinhAnh.Enabled = true;
            cbb_LoaiSP.Enabled = true;
            txtMaSP.Clear();
            txtTenSP .Clear();
            txt_GiaSP.Clear();
            txtHinhAnh.Clear();
            btn_Luu.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xl.XoaSanPham(txtMaSP.Text);
                if (kq == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    Init();
                    return;
                }
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            txtTenSP.Enabled = true;
            txt_GiaSP.Enabled = true;
            txtHinhAnh.Enabled = true;
            cbb_LoaiSP.Enabled = true;
            btn_Luu.Enabled = true;
        }
        private SanPham getDataControls()
        {
            try
            {
                SanPham sp = new SanPham();
                sp.MaSP = txtMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                float giaSP;
                if (float.TryParse(txt_GiaSP.Text, out giaSP))
                {
                    sp.GiaSP = giaSP;
                }
                else
                {
                    sp.GiaSP = 0;
                }
                sp.HinhAnh = txtHinhAnh.Text;
                sp.MaLoaiSP = cbb_LoaiSP.SelectedValue?.ToString(); // Thêm ? để tránh lỗi nếu SelectedValue là null.

                return sp;
            }
            catch
            {
                return null;
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
           
            bool kqKT = xl.KT_MaSP(txtMaSP.Text.ToString());
            SanPham sp = getDataControls();
            if (kqKT == false)
            {
                int kq = xl.ThemSanPham(sp);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                    Init();
                    txtMaSP.Enabled = false;
                    txtTenSP.Enabled = false;
                    txt_GiaSP.Enabled = false;
                    txtHinhAnh.Enabled= false;
                    cbb_LoaiSP.Enabled = false;
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
                txtMaSP.Enabled = false;
                txtTenSP.Enabled = false;
                txt_GiaSP.Enabled = false;
                txtHinhAnh.Enabled = false;
                cbb_LoaiSP.Enabled = false;

            }
         
            if (kqKT == true)
            {
                int kq = xl.SuaSanPham(sp);
                if (kq == 1)
                {
                    MessageBox.Show("Sửa thành công ");
                    Init();
                    txtMaSP.Enabled = false;
                    txtTenSP.Enabled = false;
                    txt_GiaSP.Enabled = false;
                    txtHinhAnh.Enabled = false;
                    cbb_LoaiSP.Enabled = false;
                    return;
                }
                MessageBox.Show("Sửa thất bại ");
                txtMaSP.Enabled = false;
                txtTenSP.Enabled = false;
                txt_GiaSP.Enabled = false;
                txtHinhAnh.Enabled = false;
                cbb_LoaiSP.Enabled = false;
            }
        }

        private void dgv_SanPham_SelectionChanged(object sender, EventArgs e)
        {
            btn_Sua.Enabled = btn_Xoa.Enabled = true;
        }

        private void dgv_SanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgv_SanPham.Rows[e.RowIndex];
                // Hiển thị thông tin trên TextBox khi chọn một dòng
                txtMaSP.Text = selectedRow.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenSP"].Value.ToString();
                txt_GiaSP.Text = selectedRow.Cells["GiaSP"].Value.ToString();
                txtHinhAnh.Text = selectedRow.Cells["HinhAnh"].Value.ToString();
                cbb_LoaiSP.SelectedValue = selectedRow.Cells["MaLoaiSP"].Value.ToString();

            }
        }
    }
}
