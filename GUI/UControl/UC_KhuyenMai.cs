using BLL;
using BLL.Core;
using BLL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UControl
{
    public partial class UC_KhuyenMai : UserControl
    {
        DataGridView dataGrid;
        XuLyKhuyenMai xuLyKM = new XuLyKhuyenMai();
        public UC_KhuyenMai()
        {
            InitializeComponent();
            Init();

        }
        private void Init()
        {
            TaoDataGridView();
            //vô hiệu hóa
            VoHieuHoa(txtMaKM);
            VoHieuHoa(txtTenKM);
            VoHieuHoa(txtMoTa);
            VoHieuHoa(txtNgayBD);
            VoHieuHoa(txtNgayKT);
            VoHieuHoa(txtTriGia);
            List<KHUYEN_MAI> list = xuLyKM.getAllKhuyenMai();
            if (list != null)
            {
                ThemDDuLieuVafoDataaGridView(list);
            }
        }
        private void reloadDataGridView()
        {
            TaoDataGridView();
            List<KHUYEN_MAI> list = xuLyKM.getAllKhuyenMai();
            if(list != null)
            {
                ThemDDuLieuVafoDataaGridView(list);
            }
        }
        private void ThemDDuLieuVafoDataaGridView(List<KHUYEN_MAI> listKM)
        {
            foreach(KHUYEN_MAI item in listKM)
            {
                //int indexRow = dataGrid.Rows.Add();
                //dataGrid.Rows[indexRow].Cells["MAKHUYENMAI"].Value = item.MAKHUYENMAI;
                //dataGrid.Rows[indexRow].Cells["TENKHUYENMAI"].Value = item.TENKHUYENMAI;
                //dataGrid.Rows[indexRow].Cells["NGAYBD"].Value = item.NGAYBD.Value.Day+"/"+item.NGAYBD.Value.Month+"/"+item.NGAYBD.Value.Year;
                //dataGrid.Rows[indexRow].Cells["NGAYKT"].Value = item.NGAYKT.Value.Day + "/" + item.NGAYKT.Value.Month + "/" + item.NGAYKT.Value.Year;
                //dataGrid.Rows[indexRow].Cells["TRIGIA"].Value = item.TRIGIA;
                //dataGrid.Rows[indexRow].Cells["MOTA"].Value = item.MOTA;
            }

        }
         private void TaoDataGridView()
        {
            dataGrid = new DataGridView();
            int widthPanel = panelDateGridView.Width;
            int heightPanel = panelDateGridView.Height;
            int phantram;

            DataGridViewTextBoxColumn MAKHUYENMAI = new DataGridViewTextBoxColumn();
            MAKHUYENMAI.HeaderText = "Mã khuyến mãi";
            MAKHUYENMAI.Name = "MAKHUYENMAI";
            phantram = 10;
            MAKHUYENMAI.Width = phantram * widthPanel / 100;
            dataGrid.Columns.Add(MAKHUYENMAI);

            DataGridViewTextBoxColumn TENKHUYENMAI = new DataGridViewTextBoxColumn();
            TENKHUYENMAI.HeaderText = "Tên Khuyến mãi ";
            TENKHUYENMAI.Name = "TENKHUYENMAI";
            phantram = 20;
            TENKHUYENMAI.Width = phantram * widthPanel / 100;
            dataGrid.Columns.Add(TENKHUYENMAI);

            DataGridViewTextBoxColumn NGAYBD = new DataGridViewTextBoxColumn();
            NGAYBD.HeaderText = "Ngày bắt đầu";
            NGAYBD.Name = "NGAYBD";
            phantram = 10;
            NGAYBD.Width = phantram * widthPanel / 100;
            dataGrid.Columns.Add(NGAYBD);

            DataGridViewTextBoxColumn NGAYKT = new DataGridViewTextBoxColumn();
            NGAYKT.HeaderText = "Ngày kết thúc";
            NGAYKT.Name = "NGAYKT";
            phantram = 10;
            NGAYKT.Width = phantram * widthPanel / 100;
            dataGrid.Columns.Add(NGAYKT);

            DataGridViewTextBoxColumn TRIGIA = new DataGridViewTextBoxColumn();
            TRIGIA.HeaderText = "Trị giá";
            TRIGIA.Name = "TRIGIA";
            phantram = 10;
            TRIGIA.Width = phantram * widthPanel / 100;
            dataGrid.Columns.Add(TRIGIA);

            DataGridViewTextBoxColumn MOTA = new DataGridViewTextBoxColumn();
            MOTA.HeaderText = "Mô tả";
            MOTA.Name = "MOTA";
            phantram = 40;
            MOTA.Width = phantram * widthPanel / 100;
            dataGrid.Columns.Add(MOTA);

            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Width = widthPanel;
            dataGrid.Height = heightPanel;
            dataGrid.CellClick += DataGrid_CellClick;
            panelDateGridView.Controls.Clear();
            panelDateGridView.Controls.Add(dataGrid);
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if(dataGrid.CurrentCell.Value != null)
                {
                    txtMaKM.Text = dataGrid.Rows[index].Cells["MAKHUYENMAI"].Value.ToString();
                    txtTenKM.Text = dataGrid.Rows[index].Cells["TENKHUYENMAI"].Value.ToString();
                    txtMoTa.Text = dataGrid.Rows[index].Cells["MOTA"].Value.ToString();
                    txtNgayBD.Value = ConvertToDateTime(dataGrid.Rows[index].Cells["NGAYBD"].Value.ToString());
                    txtNgayKT.Value = ConvertToDateTime(dataGrid.Rows[index].Cells["NGAYKT"].Value.ToString());
                    txtTriGia.Text = dataGrid.Rows[index].Cells["TRIGIA"].Value.ToString();
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
        private KHUYEN_MAI layDataControls()
        {
            try
            {
                KHUYEN_MAI khuyenMai = new KHUYEN_MAI();
                //khuyenMai.MAKHUYENMAI = txtMaKM.Text;
                //khuyenMai.TENKHUYENMAI = txtTenKM.Text;
                //khuyenMai.MOTA = txtMoTa.Text;
                //khuyenMai.NGAYBD = txtNgayBD.Value;
                //khuyenMai.NGAYKT = txtNgayKT.Value;
                //khuyenMai.TRIGIA = double.Parse(txtTriGia.Text);
                //khuyenMai.MOTA = txtMoTa.Text;
                return khuyenMai;
            }
            catch { return null; }
        }
        private void LoadDataControls(KHUYEN_MAI k)
        {
            try
            {
                if(k != null)
                {
                    //txtMaKM.Text = k.MAKHUYENMAI;
                    //txtTenKM.Text = k.TENKHUYENMAI;
                    //txtMoTa.Text = k.MOTA;
                    //txtNgayBD.Value = k.NGAYBD.Value;
                    //txtNgayKT.Value = k.NGAYKT.Value;
                    //txtTriGia.Text = k.TRIGIA.ToString();
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMaKM.Text = Librari.TaoMaKhuyenMai();
            txtTenKM.Clear();
            txtMoTa.Clear();
            txtTriGia.Clear();
            //có hiệu lực
            CoHieuLuc(txtTenKM);
            CoHieuLuc(txtMoTa);
            CoHieuLuc(txtNgayBD);
            CoHieuLuc(txtNgayKT);
            CoHieuLuc(txtTriGia);
            //KHUYEN_MAI k =  layDataControls();
            //if (k == null) { MessageBox.Show("Thông tin không hợp lệ !"); }
            //bool KTTrungMa = xuLyKM.KT_TonTai(k.MAKHUYENMAI);
            //if (KTTrungMa == true)
            //{
            //    MessageBox.Show("Không thể thêm vì trùng mã khuyến mãi");
            //}
            //xuLyKM.ThemKhuyenMai(k);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //kiểm tra trùng
            bool kqKT = xuLyKM.KT_TonTai(txtMaKM.Text.ToString());
            KHUYEN_MAI k = layDataControls();
            //khồng trùng thêm mới 
            if (kqKT == false)
            {
                int kq = xuLyKM.ThemKhuyenMai(k);
                if (kq == 1) {
                    MessageBox.Show("Thêm thành công ");
                    reloadDataGridView();
                    VoHieuHoa(txtTenKM);
                    VoHieuHoa(txtMoTa);
                    VoHieuHoa(txtNgayBD);
                    VoHieuHoa(txtNgayKT);
                    VoHieuHoa(txtTriGia);
                    return; }
                MessageBox.Show("Thêm thất bại ");
            }
            //trùng thì cập nhật
            if (kqKT == true)
            {
                int kq = xuLyKM.SuaKhuyeMai(k);
                if (kq == 1) { 
                    MessageBox.Show("Thêm thành công ");
                    reloadDataGridView();
                    VoHieuHoa(txtTenKM);
                    VoHieuHoa(txtMoTa);
                    VoHieuHoa(txtNgayBD);
                    VoHieuHoa(txtNgayKT);
                    VoHieuHoa(txtTriGia);
                    return; }
                MessageBox.Show("Thêm thất bại ");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CoHieuLuc(txtTenKM);
            CoHieuLuc(txtMoTa);
            CoHieuLuc(txtNgayBD);
            CoHieuLuc(txtNgayKT);
            CoHieuLuc(txtTriGia);
        }
        private void VoHieuHoa (Control ctr)
        {
            if(ctr is TextBox)
            {
                TextBox t = (TextBox)ctr;
                t.ReadOnly = true;
            }
            if(ctr is DateTimePicker)
            {
                DateTimePicker t = (DateTimePicker)ctr;
                t.Enabled = false;
            }
            if(ctr is Button)
            {
                Button t = (Button)ctr;
                t.Enabled = false;
            }
        }
        private void CoHieuLuc(Control ctr)
        {
            if (ctr is TextBox)
            {
                TextBox t = (TextBox)ctr;
                t.ReadOnly = false;
            }
            if (ctr is DateTimePicker)
            {
                DateTimePicker t = (DateTimePicker)ctr;
                t.Enabled = true;
            }
            if (ctr is Button)
            {
                Button t = (Button)ctr;
                t.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Thông báo", "Xác nhân xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                int kq = xuLyKM.XoaKhuyenMai(txtMaKM.Text);
                if(kq == 1) { MessageBox.Show("Thành Công"); reloadDataGridView(); return; }
                MessageBox.Show("Thất bại");
            }
        }

        private void txtTriGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                //không phải số
                e.Handled = true;
                return;
            }
        }
    }
}
