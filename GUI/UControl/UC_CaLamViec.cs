using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BLL.Core;
using BLL.DB;

namespace GUI.UControl
{
    public partial class UC_CaLamViec : UserControl
    {
        XuLyCaLamViec xuLy = new XuLyCaLamViec();
        DataTable dataTable;
        private string MaCLV = "Mã Ca Làm";
        private string TenCLV = "Tên Ca Làm";
        private string GioBD = "Giờ Bắt Đầu";
        private string GioKT = "Giờ Kết Thúc";
        private string SoTien = "Số Tiền / Giờ";
        public UC_CaLamViec()
        {
            InitializeComponent();
            hienThi();
            //Init();
            voHieuHoatxt();
            
        }
        //public void Init()
        //{
        //    List<CaLamViec> list = xuLy.getAllCaLamViec();
        //    if (list != null)
        //    {
        //        LoadDataGridView(list);
        //    }
        //}
        //private void LoadDataGridView(List<CaLamViec> dsCaLam)
        //{
        //    dtgvCaLamViec.DataSource = null;
        //    // Clear existing data
        //    dtgvCaLamViec.Rows.Clear();
        //    foreach (CaLamViec item in dsCaLam)
        //    {
        //        int indexRow = dtgvCaLamViec.Rows.Add();
        //        dtgvCaLamViec.Rows[indexRow].Cells["MaCLV"].Value = item.MaCLV;
        //        dtgvCaLamViec.Rows[indexRow].Cells["TenCLV"].Value = item.TenCLV;
        //        dtgvCaLamViec.Rows[indexRow].Cells["GioBD"].Value = item.GioBD;
        //        dtgvCaLamViec.Rows[indexRow].Cells["GioKT"].Value = item.GioKT;
        //        dtgvCaLamViec.Rows[indexRow].Cells["SoTien"].Value = item.SoTien;
        //    }

        //}
        private void khoiTaoDTBL_CTHoaDon()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(MaCLV);
            dataTable.Columns.Add(TenCLV);
            dataTable.Columns.Add(GioBD);
            dataTable.Columns.Add(GioKT);
            dataTable.Columns.Add(SoTien);
            dtgvCaLamViec.DataSource = dataTable;
        }
        private void ThemDuLieuDataGridView(CaLamViec tk)
        {
            DataRow row = dataTable.NewRow();

            row[MaCLV] = tk.MaCLV;
            row[TenCLV] = tk.TenCLV;
            row[GioBD] = tk.GioBD.Value.ToString();
            row[GioKT] = tk.GioKT.Value.ToString();
            row[SoTien] = tk.SoTien;
            dataTable.Rows.Add(row);
        }
        private void ThemDuLieuDataGridView(List<CaLamViec> lst)
        {
            khoiTaoDTBL_CTHoaDon();
            foreach (CaLamViec item in lst)
            {
                ThemDuLieuDataGridView(item);
            }
            dtgvCaLamViec.DataSource = dataTable;
        }
        public void hienThi()
        {
            List<CaLamViec> listCaLamViec = xuLy.getAllCaLamViec();
            if(listCaLamViec != null)
            {
                khoiTaoDTBL_CTHoaDon();
                ThemDuLieuDataGridView(listCaLamViec);
            }
        }
       
        private CaLamViec getDataControls()
        {
            try
            {
                CaLamViec c = new CaLamViec();
                c.MaCLV = txtMaCaLam.Text;
                c.TenCLV = txtTenCaLam.Text;
                c.GioBD = TimeSpan.Parse(txtTGBatDau.Text);
                c.GioKT = TimeSpan.Parse(txtTGKetThuc.Text);
                c.SoTien = double.Parse(txtTien.Text);
                return c;
            }
            catch { return null; }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ClearData();
            coHieuLuctxt();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Thông báo", "Xác nhân xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int kq = xuLy.XoaCaLamViec(txtMaCaLam.Text);
                if (kq == 1) { MessageBox.Show("Thành Công"); hienThi(); return; }
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            coHieuLuctxt();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //kiểm tra trùng
            bool kqKT = xuLy.KT_TonTai(txtMaCaLam.Text.ToString());
            CaLamViec c = getDataControls();
            //không trùng thêm mới 
            if (kqKT == false)
            {
                int kq = xuLy.ThemCaLamViec(c);
                if (kq == 1)
                {
                    MessageBox.Show("Thêm thành công ");
                    hienThi();
                    voHieuHoatxt();
                    return;
                }
                MessageBox.Show("Thêm thất bại ");
                voHieuHoatxt();

            }
            //trùng thì cập nhật
            if (kqKT == true)
            {
                int kq = xuLy.SuaCaLamViec(c);
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
        public void voHieuHoatxt()
        {
            txtMaCaLam.Enabled = false;
            txtTenCaLam.Enabled = false;
            txtTGBatDau.Enabled = false;
            txtTGKetThuc.Enabled = false;
            txtTien.Enabled = false;
           
        }

        public void coHieuLuctxt()
        {
            txtMaCaLam.Enabled = true;
            txtTenCaLam.Enabled = true;
            txtTGBatDau.Enabled = true;
            txtTGKetThuc.Enabled = true;
            txtTien.Enabled = true;
            
        }

        public void ClearData()
        {
            txtMaCaLam.Clear();
            txtTenCaLam.Clear();
            txtTGBatDau.Clear();
            txtTGKetThuc.Clear();
            txtTien.Clear();
        }

        private void dtgvCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (dtgvCaLamViec.CurrentCell.Value != null)
                {
                    txtMaCaLam.Text = dtgvCaLamViec.Rows[index].Cells["MaCLV"].Value.ToString();
                    txtTenCaLam.Text = dtgvCaLamViec.Rows[index].Cells["TenCLV"].Value.ToString();
                    txtTGBatDau.Text = dtgvCaLamViec.Rows[index].Cells["GioBD"].Value.ToString();
                    txtTGKetThuc.Text = dtgvCaLamViec.Rows[index].Cells["GioKT"].Value.ToString();
                    txtTien.Text = dtgvCaLamViec.Rows[index].Cells["SoTien"].Value.ToString();
                }
            }
            catch { }
        }
    }
}
