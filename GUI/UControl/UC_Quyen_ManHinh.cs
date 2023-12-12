using BLL;
using BLL.Core;
using BLL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace GUI.UControl
{
    public partial class UC_Quyen_ManHinh : UserControl
    {
        XuLyQuyen xuLyQuyen = new XuLyQuyen();
        XuLyDMManHinh xuLyDMManHinh = new XuLyDMManHinh();
        public UC_Quyen_ManHinh()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenQuyen.Clear();
            txtTenQuyen.ReadOnly = false;
            txtMaQuyen.Text = Librari.createMaQuyen();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r =MessageBox.Show("thông báo","Xác nhân xóa",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if( r == DialogResult.Yes)
            {
                if(txtMaQuyen.Text==null || txtMaQuyen.Text == "") { MessageBox.Show("Bạn quên nhập mã"); }
                string maquyen = txtMaQuyen.Text;
               int k= xuLyQuyen.Xoa(maquyen);
                if (k == 1) { MessageBox.Show("Thành công"); }
                else { MessageBox.Show("Thất bại"); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaQuyen.ReadOnly = true;
            txtTenQuyen.ReadOnly = false;
        }

        private void UC_Quyen_ManHinh_Load(object sender, EventArgs e)
        {
            txtMaQuyen.ReadOnly = true;
            txtTenQuyen.ReadOnly = true;
            List<QUYEN> listQuyen = xuLyQuyen.LayTatCa();
            if(listQuyen != null)
            {
                LoadDGVQuyen(listQuyen);
            }
        }
        private void LoadDGVQuyen(List<QUYEN> result) {
            if(result == null) { return; }
            DGVQuyen.DataSource = null;
            DGVQuyen.Rows.Clear();
            DGVQuyen.DataSource = result;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaQuyen.Text==null || txtTenQuyen.Text == null) { return; }
            string maquyen = txtMaQuyen.Text;
            string tenquyen = txtTenQuyen.Text;
            bool kq = xuLyQuyen.KT_TonMa(maquyen);
            QUYEN q = new QUYEN();
            q.TenQuyen = tenquyen;
            q.MaQuyen = maquyen;
            if (kq == true)
            {
                //mã tồn tại sửa
                int k = xuLyQuyen.Sua(q);
                if (k == 1) { 
                    MessageBox.Show("Thành công"); 
                    ReLoad_DGV();
                    txtMaQuyen.ReadOnly = true;
                    txtTenQuyen.ReadOnly = true;
                }
                else { MessageBox.Show("Thất bại"); }
            }
            else
            {
                //thêm mới
                int k = xuLyQuyen.Them(q);
                if (k == 1)
                {
                    MessageBox.Show("Thành công"); ReLoad_DGV(); 
                    txtMaQuyen.ReadOnly = true;
                    txtTenQuyen.ReadOnly = true;
                }
                else { MessageBox.Show("Thất bại"); }
            }
        }
        private void ReLoad_DGV()
        {
            List<QUYEN> quyens = xuLyQuyen.LayTatCa();
            if(quyens != null)
            {
                LoadDGVQuyen(quyens);
            }
        }

        private void DGVQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(DGVQuyen.CurrentCell!= null)
            {
                txtTenQuyen.Text = DGVQuyen.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMaQuyen.Text = DGVQuyen.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
