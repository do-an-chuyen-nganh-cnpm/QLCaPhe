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
    public partial class UC_LoaiSP : UserControl
    {
        XuLyLoaiSanPham xl = new XuLyLoaiSanPham();
        public UC_LoaiSP()
        {
            InitializeComponent();
            Init();
            txtMaLoai.Enabled = txtTenLoai.Enabled = false;
            btn_Sua.Enabled = btn_Xoa.Enabled = btn_Luu.Enabled = false;
           
        }
        public void Init()
        {
            List<LoaiSP> list = xl.getAllLoaiSP();
            if (list != null)
            {
                LoadDataGView(list);
            }
        }
        private void LoadDataGView(List<LoaiSP> dslsp)
        {
            dgv_LoaiSP.DataSource = dslsp;
            // Thiết lập cột tự động điều chỉnh kích thước
          dgv_LoaiSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Các textbox có hiệu lực
            txtMaLoai.Enabled = txtTenLoai.Enabled = true;
            //Dấu nháy xuất hiện ở Mã loại
            txtMaLoai.Focus();
            //Xóa dữ liệu hiện tại trên textbox
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            btn_Luu.Enabled = true;

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xl.XoaLoaiSP(txtMaLoai.Text);
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
            txtTenLoai.Enabled = true;
            txtMaLoai.Enabled = false;
            btn_Luu.Enabled = true;
        }
        private LoaiSP getDataControls()
        {
            try
            {
                LoaiSP lsp = new LoaiSP();
                lsp.MaLoaiSP = txtMaLoai.Text;
                lsp.TenLoaiSP = txtTenLoai.Text;
                return lsp; 
            }
            catch { return null; }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin vừa nhập hoặc sửa có phù hợp
            if(txtMaLoai.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã loại ");
                txtMaLoai.Focus();
                return;
            }
            if(txtTenLoai.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tên loại");
                txtTenLoai.Focus();
                return;
            }
            //kiểm tra trùng
            bool kq = xl.KT_MaLoaiSP(txtMaLoai.Text.ToString());
            LoaiSP lsp = getDataControls();
            //không trùng thêm mới 
            if (kq == false)
            {
                int kq1 = xl.ThemLoaiSP(lsp);
                if (kq1 == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                    Init();
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
           

            }
            //trùng thì cập nhật
            if (kq == true)
            {
                int kq1 = xl.SuaLoaiSP(lsp);
                if (kq1 == 1)
                {
                    MessageBox.Show("Sửa thành công ");
                    Init();
                    return;
                }
                MessageBox.Show("Sửa thất bại ");
               
            }
        }

        private void dgv_LoaiSP_SelectionChanged(object sender, EventArgs e)
        {
            btn_Sua.Enabled = btn_Xoa.Enabled = true;
    
        }

        private void dgv_LoaiSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgv_LoaiSP.Rows[e.RowIndex];
                // Hiển thị thông tin trên TextBox khi chọn một dòng
                txtMaLoai.Text = selectedRow.Cells["MaLoaiSP"].Value.ToString();
                txtTenLoai.Text = selectedRow.Cells["TenLoaiSP"].Value.ToString();
            }
        }
    }
}
        
