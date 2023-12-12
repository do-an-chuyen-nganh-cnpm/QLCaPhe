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
    public partial class UC_QuanLyQuyen : UserControl
    {
        XuLyDMManHinh xuLyDMManHinh = new XuLyDMManHinh();
        XuLyQuyenManHinh xuLyQuyenManHinh = new XuLyQuyenManHinh();
        XuLyQuyen xuLyQuyen = new XuLyQuyen();
        DataTable dataTblQuyen, dataTbleManHinh;
        public UC_QuanLyQuyen()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            List<DM_ManHinh> listDMManHinh = new List<DM_ManHinh>();
            listDMManHinh = xuLyDMManHinh.LayTatCa();
            if(listDMManHinh!= null)
            {
                cbxManHinh.DataSource = listDMManHinh;
                cbxManHinh.DisplayMember = "TenDM";
                cbxManHinh.ValueMember = "MaDM";
            }
            List<QUYEN> listQuyen = xuLyQuyen.LayTatCa();
            if(listQuyen != null)
            {
                LoadDuLieuQuyen(listQuyen);
            }
        }
        private void LoadDuLieuTblQuyen(List<QUYEN> list)
        {
            DGVQuyen.DataSource = null;
            DGVQuyen.Rows.Clear();
            DGVQuyen.DataSource = list;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Quyen_ManHinh quyen = new Quyen_ManHinh();
            quyen.MaDM = cbxManHinh.SelectedValue.ToString();
            quyen.MaQuyen = txtMaQuyen.Text.ToString();
            if (quyen != null && quyen.MaQuyen!=null && quyen.MaDM!= null)
            {
             int kq =   xuLyQuyenManHinh.Them(quyen);
                if(kq != 1)
                {
                    ThongBao("Thông báo", "Thêm thất bại !");
                    return;
                }
                List<ManHinh> result = xuLyDMManHinh.layDMManHinh(quyen.MaQuyen);
                if(result != null)
                {
                    LoadDuLieuDMManHinh(result);
                }               
            }
        }
        private void ThongBao (string title, string mess)
        {
            MessageBox.Show(mess, title);
        }

        private void LoadDuLieuDMManHinh(List<ManHinh> list)
        {
            DGVManHinh.DataSource = null;
            DGVManHinh.Rows.Clear();
            DGVManHinh.DataSource = list;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaMH = cbxManHinh.SelectedValue.ToString();
            string maQuyen = txtMaQuyen.Text;
            if (String.IsNullOrEmpty(MaMH) || String.IsNullOrEmpty(maQuyen)) { return; ThongBao("Thông báo", "Thất bại"); }
            
            int kq = xuLyQuyenManHinh.Xoa(maQuyen,MaMH);
            if (kq == 1)
            {
                ThongBao("Thông báo", "Xóa thành công");
                List<ManHinh> result = xuLyDMManHinh.layDMManHinh(maQuyen);
                if (result != null)
                {
                    LoadDuLieuDMManHinh(result);
                }
            }
        }
        private void DGVQuyen_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVQuyen.CurrentRow != null)
            {
                txtMaQuyen.Text = DGVQuyen.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenQuyen.Text = DGVQuyen.Rows[e.RowIndex].Cells[0].Value.ToString();
                List<ManHinh> listManHinh = xuLyDMManHinh.layDMManHinh(txtMaQuyen.Text);
                if (listManHinh != null)
                {
                    LoadDuLieuDMManHinh(listManHinh);
                }
            }
        }

        private void DGVManHinh_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVManHinh.CurrentCell != null)
            {
                string maMH = DGVManHinh.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (maMH != null)
                {
                    cbxManHinh.SelectedValue = maMH;
                }
            }
        }

        private void LoadDuLieuQuyen(List<QUYEN> list)
        {
            DGVQuyen.DataSource = null;
            DGVQuyen.Rows.Clear();
            DGVQuyen.DataSource = list;
        }
    }
}
