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
    public partial class UC_Ban : UserControl
    {
        XuLyBan xuLy = new XuLyBan();
        public UC_Ban()
        {
            InitializeComponent();
            Init();
            voHieuHoatxt();
            loadCBMaTrangThai();
        }
        private void Init()
        {
            List<BAN> list = xuLy.getAllTable();
            if (list != null)
            {
                LoadDataGridView(list);
            }
        }
        private void LoadDataGridView(List<BAN> dsBan)
        {
            dtgvBan.DataSource = null;
            // Clear existing data
            dtgvBan.Rows.Clear();
            foreach (BAN item in dsBan)
            {
                int indexRow = dtgvBan.Rows.Add();
                dtgvBan.Rows[indexRow].Cells["MaBan"].Value = item.MaBan;
                dtgvBan.Rows[indexRow].Cells["TenBan"].Value = item.TenBan;
                dtgvBan.Rows[indexRow].Cells["MaTrangThai"].Value = item.MaTrangThai;
            }
        }
            public void loadCBMaTrangThai()
        {
            cb_MaTrangThai.DataSource = xuLy.getAllTrangThaiBan();
            cb_MaTrangThai.ValueMember = "MaTrangThai";
            cb_MaTrangThai.DisplayMember = "TenTrangThai";
        }

        private BAN getDataControls()
        {
            try
            {
                BAN b = new BAN();
                b.MaBan = txtMaBan.Text;
                b.TenBan = txtTenBan.Text;
                b.MaTrangThai = cb_MaTrangThai.SelectedValue.ToString();
                return b;
            }
            catch { return null; }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearData();
            coHieuLuctxt();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhân xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xuLy.XoaBan(txtMaBan.Text);
                if (kq == 1) { MessageBox.Show("Thành Công"); Init(); return; }
                MessageBox.Show("Thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            coHieuLuctxt();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //kiểm tra trùng
            bool kqKT = xuLy.KT_TonTai(txtMaBan.Text.ToString());
            BAN b = getDataControls();
            //không trùng thêm mới 
            if (kqKT == false)
            {
                int kq = xuLy.ThemBan(b);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                    Init();
                    voHieuHoatxt();
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
                voHieuHoatxt();

            }
            //trùng thì cập nhật
            if (kqKT == true)
            {
                int kq = xuLy.SuaBan(b);
                if (kq == 1)
                {
                    MessageBox.Show("Sửa thành công ");
                    Init();
                    voHieuHoatxt();
                    return;
                }
                MessageBox.Show("Sửa thất bại ");
                voHieuHoatxt();
            }
        }

        public void voHieuHoatxt()
        {
            txtMaBan.Enabled = false;
            txtTenBan.Enabled = false;
            cb_MaTrangThai.Enabled = false;
        }

        public void coHieuLuctxt()
        {
            txtMaBan.Enabled = true;
            txtTenBan.Enabled = true;
            cb_MaTrangThai.Enabled = true;
        }

        public void ClearData()
        {
            txtMaBan.Clear();
            txtTenBan.Clear();
        }

        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (dtgvBan.CurrentCell.Value != null)
                {
                    txtMaBan.Text = dtgvBan.Rows[index].Cells["MaBan"].Value.ToString();
                    txtTenBan.Text = dtgvBan.Rows[index].Cells["TenBan"].Value.ToString();
                    cb_MaTrangThai.SelectedValue = dtgvBan.Rows[index].Cells["MaTrangThai"].Value.ToString();
                }
            }
            catch { }
        }
    }
}
