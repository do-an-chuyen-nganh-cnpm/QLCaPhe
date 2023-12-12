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
    public partial class UC_ChamCong : UserControl
    {
        XuLyCaLamViec xuLyCaLam = new XuLyCaLamViec();
        XuLyNhanVien xuLyNhanVien = new XuLyNhanVien();
        XuLyCaLamViec_NhanVien xuLyCaLamViec_NhanVien = new XuLyCaLamViec_NhanVien();
        DataTable tbleNhanVien;
        // các column 
        private const string name_maNhanVien = "Mã Nhân Viên";
        private const string name_TenNhanVien = "Tên nhân viên";
        private const string name_soDienThoai = "Số điện thoại";
        private const string name_checkBox ="Check";
        public UC_ChamCong()
        {            
            InitializeComponent();
            LoadDGV();
        }

        private void UC_ChamCong_Load(object sender, EventArgs e)
        {
            //load combox ca làm việc 
            List<CaLamViec> listCaLamViec = new List<CaLamViec>();
            listCaLamViec = xuLyCaLam.getAll();
            if(listCaLamViec != null)
            {
                cbxCaLamViec.DataSource = listCaLamViec;
                cbxCaLamViec.DisplayMember = "TenCLV";
                cbxCaLamViec.ValueMember = "MaCLV";
            }
        }

        private void cbxCaLamViec_SelectedValueChanged(object sender, EventArgs e)
        {
            string maCLV = cbxCaLamViec.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(maCLV))
            {
                double tienLam = xuLyCaLam.Lay_Tien_CaLam(maCLV);
                txtTien.Text = tienLam.ToString();
            }
        }
        private void LoadDGV()
        {
            List<NHANVIEN> listNhanVien = new List<NHANVIEN>();
            listNhanVien = xuLyNhanVien.getAllNhanVien();
            if(listNhanVien != null)
            {
                LoadDGV(listNhanVien);
            }
        }
        private void LoadDGV(List<NHANVIEN> listNV)
        {
            //
            KhoiTaoDataTable();
            if(listNV != null)
            {
                foreach (NHANVIEN nv in listNV)
                {
                    LoadDGV(nv);
                }
            }
            // check nhân viên đã làm việc
            DateTime ngayVaoLam = txtNgayVaoLam.Value;
            if (ngayVaoLam.Date < DateTime.Today.Date)
            {
                DGVNhanVien.ReadOnly = true;
            }
            else
            {
                DGVNhanVien.ReadOnly = false;
            }
            DateTime ngayTanLam = txtNgayTanLam.Value;
            List<ChiTietCaLamNhanvien> listResult = xuLyNhanVien.getNhanVien_By_NgayVLNgayTL(ngayVaoLam, ngayTanLam);
            for (int i = 0; i < DGVNhanVien.Rows.Count - 1; i++)
            {
                string maNV = DGVNhanVien.Rows[i].Cells[name_maNhanVien].Value.ToString();
                bool ktmaNV = xuLyNhanVien.checkTonTai(listResult, maNV);
                if (ktmaNV)
                {
                    DGVNhanVien.Rows[i].Cells[name_checkBox].Value = true;
                }
                else
                {
                    DGVNhanVien.Rows[i].Cells[name_checkBox].Value = false;
                }
            }
            DGVNhanVien.DataSource = tbleNhanVien;
        }
        private void LoadDGV(NHANVIEN nv)
        {
            DataRow row = tbleNhanVien.NewRow();
            row[name_maNhanVien] = nv.MaNV;
            row[name_TenNhanVien] = nv.TenNV;
            row[name_soDienThoai] = nv.SoDT;
            row[name_checkBox] = false;
            tbleNhanVien.Rows.Add(row);
        }
        private void KhoiTaoDataTable()
        {
            tbleNhanVien = new DataTable();
            tbleNhanVien.Columns.Add(name_maNhanVien, typeof(string));
            tbleNhanVien.Columns.Add(name_TenNhanVien, typeof(string));
            tbleNhanVien.Columns.Add(name_soDienThoai, typeof(string));
            tbleNhanVien.Columns.Add(name_checkBox, typeof(bool));
            DGVNhanVien.DataSource = tbleNhanVien;
        }
        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            DateTime ngayVaoLam = txtNgayVaoLam.Value;
            if( ngayVaoLam.Date < DateTime.Today.Date)
            {
                DGVNhanVien.ReadOnly = true;
            }
            else
            {
                DGVNhanVien.ReadOnly =false;
            }
            DateTime ngayTanLam = txtNgayTanLam.Value;
            List<ChiTietCaLamNhanvien> listResult = xuLyNhanVien.getNhanVien_By_NgayVLNgayTL(ngayVaoLam, ngayTanLam);
            LoadDGV();
            for(int i =0;i< DGVNhanVien.Rows.Count-1; i++)
            {
                string maNV = DGVNhanVien.Rows[i].Cells[name_maNhanVien].Value.ToString();
                bool ktmaNV = xuLyNhanVien.checkTonTai(listResult, maNV);
                if (ktmaNV)
                {
                    DGVNhanVien.Rows[i].Cells[name_checkBox].Value=true;
                }
                else
                {
                    DGVNhanVien.Rows[i].Cells[name_checkBox].Value = false;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DateTime ngayVaoLam = txtNgayVaoLam.Value;
            DateTime ngayTanLam = txtNgayTanLam.Value;
            double tien = xuLyCaLam.Lay_Tien_CaLam(cbxCaLamViec.SelectedValue.ToString());
            string maCLV = cbxCaLamViec.SelectedValue.ToString();
            int kq = 0;
            for (int i = 0; i < DGVNhanVien.Rows.Count-1; i++)
            {
                bool checkChamCong =Convert.ToBoolean( DGVNhanVien.Rows[i].Cells[name_checkBox].Value);
                if(checkChamCong == true)
                {
                    string maNV = DGVNhanVien.Rows[i].Cells[name_maNhanVien].Value.ToString();

                    ChiTietCaLamNhanvien ctCalam = new ChiTietCaLamNhanvien();
                    ctCalam.MaNV = maNV;
                    ctCalam.MaCLV = maCLV;
                    ctCalam.NgayVaoLam = ngayVaoLam;
                    ctCalam.NgayTanLam = ngayTanLam;
                    ctCalam.Thanhtien = tien;
                    xuLyCaLamViec_NhanVien.Them(ctCalam);
                    //chấm công
                }                
            }
            if(kq == 0) { MessageBox.Show("Không thành công"); }
            if(kq == 1) { MessageBox.Show("Thành công"); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        int indexclick = -1;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(indexclick == -1) { MessageBox.Show("Thất bại"); return; }
            DateTime ngayVL = txtNgayVaoLam.Value;
            DateTime ngayTL = txtNgayTanLam.Value;
            string maCLV = cbxCaLamViec.SelectedValue.ToString();
            double thanhtien = xuLyCaLam.Lay_Tien_CaLam(maCLV);
            string maNV = DGVNhanVien.Rows[indexclick].Cells[name_maNhanVien].Value.ToString();
            ChiTietCaLamNhanvien ctcl = new ChiTietCaLamNhanvien();
            ctcl.MaNV = maNV;
            ctcl.MaCLV = maCLV;
            ctcl.NgayVaoLam = ngayVL;
            ctcl.NgayTanLam = ngayTL;
            ctcl.Thanhtien = thanhtien;
            bool checkcode =Convert.ToBoolean( DGVNhanVien.Rows[indexclick].Cells[name_checkBox].Value);
            int kq = 0;
            if (checkcode == true)
            {
                //thêm mới
                kq = xuLyCaLamViec_NhanVien.Them(ctcl);
            }
            if(checkcode == false)
            {
                //xóa
             kq = xuLyCaLamViec_NhanVien.xoa(ctcl);
            }
          
            if(kq == 1) { MessageBox.Show("Thành công"); }
            else { MessageBox.Show("Thất bại"); }
            indexclick = -1;
        }

        private void DGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexclick = e.RowIndex;
        }
    }
}
