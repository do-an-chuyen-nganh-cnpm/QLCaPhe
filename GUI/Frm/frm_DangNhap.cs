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

namespace GUI.Frm
{
    public partial class frm_DangNhap : Form
    {
        XuLyNhanVien xulyNV = new XuLyNhanVien();
    public static   NHANVIEN nvDangSuDung;
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        private bool KT_TT()
        {
            if (txtTaiKhoan.Text == "" || String.IsNullOrEmpty(txtTaiKhoan.Text)) { return false; }
            if (txtMatKhau.Text == "" || String.IsNullOrEmpty(txtMatKhau.Text)) { return false; }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "") { MessageBox.Show("thông tin không đúng"); return; }
            string taikhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            // if (KT_TT() == false) { return; MessageBox.Show("Thông tin bị sai"); }
            NHANVIEN nv = xulyNV.DangNhap(taikhoan, matKhau);
            if (nv == null) { return; MessageBox.Show("Đăng nhập không thành công"); }
            this.Visible = false;
            nvDangSuDung = nv;
            Program._frmMain = new frmMain(nv.MaQuyen);
            Program._frmMain.Show(); 
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
