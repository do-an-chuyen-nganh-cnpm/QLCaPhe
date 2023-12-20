using BLL.Core;
using BLL.DB;
using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GUI.Frm
{
    public partial class frm_TT_DatBanOnline : Form
    {
        XuLyDatBan xuLyDatBan = new XuLyDatBan();
        XuLyBan xuLyBan = new XuLyBan();
        //
        private List<DatBan> listDatBanChinh;
        private const string nameHoTen = "Họ tên";
        private const string nameSDT = "Số điện thoại";
        private const string nameNgayNhan = "Ngày nhận";
        private const string nameGioNhan = "Giờ Nhận";
        private const string nameTenBan = "Tên Bàn";
        DataTable tbleDatBan;
        public frm_TT_DatBanOnline()
        {
            InitializeComponent();
        }
        private void khoitaoDataTable()
        {
            tbleDatBan = new DataTable();
            tbleDatBan.Columns.Add(nameHoTen, typeof(string));
            tbleDatBan.Columns.Add(nameSDT, typeof(string));
            tbleDatBan.Columns.Add(nameNgayNhan, typeof(string));
            tbleDatBan.Columns.Add(nameGioNhan, typeof(string));
            tbleDatBan.Columns.Add(nameTenBan, typeof(string));
            DGVDatBan.DataSource = tbleDatBan;
        }
        private void ThemDuLieu()
        {
            listDatBanChinh = new List<DatBan>();
            listDatBanChinh = xuLyDatBan.getAll();
            khoitaoDataTable();
            if (listDatBanChinh != null)
            {
                ThemDuLieu(listDatBanChinh);
            }
        }
        private void ThemDuLieu(List<DatBan> listDat)
        {
            khoitaoDataTable();
            if (listDat != null)
            {
                foreach (DatBan item in listDat)
                {
                    DataRow row = tbleDatBan.NewRow();
                    row[nameHoTen] = item.HoTen;
                    row[nameSDT] = item.SoDienThoai;
                    row[nameNgayNhan] = item.NgayNhan.Value.ToString("dd/MM/yyyy");
                    row[nameGioNhan] = item.GioNhan;
                    row[nameTenBan] = xuLyBan.layTenBanByMaBan(item.MaBan);
                    tbleDatBan.Rows.Add(row);
                }
                DGVDatBan.DataSource = tbleDatBan;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSdtTimKiem.Text == "") { MessageBox.Show("Bạn quên nhập số điện thoại"); return; }
            string sdt = txtSdtTimKiem.Text;
            listDatBanChinh = new List<DatBan>();
            listDatBanChinh = xuLyDatBan.getBySDT(sdt);
            ThemDuLieu(listDatBanChinh);
        }
        private void rdo_tatca_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_tatca.Checked == true)
            {
                ThemDuLieu(listDatBanChinh);
            }
        }

        private void rdo_chuanhan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_chuanhan.Checked == true)
            {
                List<DatBan> lstTemp = listDatBanChinh.Where(
                    v => v.TrangThai.Trim().Equals(xuLyDatBan.trangThaiChuaNhan.Trim())
                    ).ToList();
                ThemDuLieu(lstTemp);
            }
        }

        private void rdo_dahuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_dahuy.Checked == true)
            {
                List<DatBan> lstTemp = listDatBanChinh.Where(
                   v => v.TrangThai.Trim().Equals(xuLyDatBan.trangThaiDaHuy.Trim())
                   ).ToList();
                ThemDuLieu(lstTemp);
            }
        }
        int indexClich = -1;
        private void DGVDatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVDatBan.CurrentCell != null)
            {
                if(e.RowIndex> listDatBanChinh.Count-1) { return; }
                indexClich = e.RowIndex;
                int index = e.RowIndex;
                txtHoTen.Text = listDatBanChinh[index].HoTen;
                txtSDT.Text = listDatBanChinh[index].SoDienThoai;
                txtNgayNhan.Value = listDatBanChinh[index].NgayNhan.Value;
                TimeSpan gioNhanTimeSpan = listDatBanChinh[index].GioNhan.Value;
                DateTime baseDate = DateTime.Now.Date; // You can use any date as a base, as only the time is relevant in this case
                DateTime gioNhanDateTime = baseDate + gioNhanTimeSpan;
                txtGioNhan.Text = gioNhanDateTime.ToString("HH:mm:ss");
                txtTenBan.Text = xuLyBan.layTenBanByMaBan(listDatBanChinh[index].MaBan);
                txtTrangThai.Text = listDatBanChinh[index].TrangThai;
            }
        }

        private void frm_TT_DatBanOnline_Load(object sender, EventArgs e)
        {
            txtTrangThai.DataSource = xuLyDatBan.listTrangThai;
            ThemDuLieu();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listDatBanChinh == null) { MessageBox.Show("Thông tin sai"); return; }
            if (indexClich == -1) { MessageBox.Show("Bạn chưa chọn"); return; }
            string trangthai = txtTrangThai.SelectedValue.ToString();
            string maDatban = listDatBanChinh[indexClich].maDatBan.ToString();
            string maBan = listDatBanChinh[indexClich].MaBan.ToString();
            if (trangthai == null || maDatban == null)
            {
                MessageBox.Show("Trạng thái bị sai");
            }
            int kq = xuLyDatBan.capNhatTrangThai(maDatban, trangthai, maBan);
            if (kq == 1)
            {
                MessageBox.Show("Thành công");
                ThemDuLieu();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                List<DatBan> lstTemp = listDatBanChinh.Where(
                   v => v.TrangThai.Trim().Equals(xuLyDatBan.trangThaiDaNhan.Trim())
                   ).ToList();
                ThemDuLieu(lstTemp);
            }
        }
    }
}
