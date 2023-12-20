using BLL.Core;
using BLL.DB;
using GUI.UControl;
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
    public partial class frmChuyenBan : Form
    {
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        XuLyBan xuLyBan = new XuLyBan();
        private string hostMaBan, hostMaHD, maBanCanChuyen;
        Color maudangchon = Color.LightBlue;
        Color mauCoKhach, MauTrong, MauDaDat;
        XuLyHoaDon xuLyHoaDon = new XuLyHoaDon();
        UC_GoiMon uc;
        public frmChuyenBan()
        {
            InitializeComponent();
        }
        public frmChuyenBan(string maban, string maHD)
        {
            hostMaHD = maHD;
            hostMaBan = maban;
            InitializeComponent();
        }
        public frmChuyenBan(string maban, string maHD, UC_GoiMon uc)
        {
            hostMaHD = maHD;
            hostMaBan = maban;
            this.uc = uc;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(hostMaHD) || String.IsNullOrEmpty(hostMaBan) || String.IsNullOrEmpty(maBanCanChuyen))
            {
                MessageBox.Show("Thông tin không đúng");
                return;
            }
            int kq = xuLyHoaDon.chuyenban(hostMaHD, hostMaBan, maBanCanChuyen);
            if (kq == 0)
            {
                MessageBox.Show("Thất bại");
            }
            if(kq == 1)
            {
                MessageBox.Show("Thành công");
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            //có 3 trạng thái : đã có khách, bàn trống, và đã đặt
            //đã có khách thì hiển thị hóa đơn bàn đó lên
            //bàn trống khỏi hiển thị
            //đặt bàn thì hiên thị nhận bàn
            Panel p = (Panel)sender;
            string tenBan = p.Name;
            string maBan = xuLyBan.LayMaBan(tenBan);
            switch (p.Tag)
            {
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaCoKhach)://trangThaiBanCoKhach
                    {
                        //đã cso khách không được chuyển
                        MessageBox.Show("Bàn đã có khách không được chuyển");
                        break; ;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiBanTrong)://trang thái bàn trống
                    {
                        if (p.BackColor == maudangchon)
                        {
                            p.BackColor = MauTrong;
                        }
                        else
                        {
                            p.BackColor = maudangchon;
                        }
                        maBanCanChuyen = maBan;
                        break;
                    }
                default:
                    {
                        
                    }
                    break;
            }
        }
        public void TaoDSban()
        {
            try
            {
                groupBox1.Controls.Clear();
                List<BAN> listBan = xuLyBan.getAllBan();
                int x = 10, y = 10;
                int indexBan = 0;
                for (int row = 0; row < listBan.Count; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        string tenTT = xuLyTrangThaiBan.layTenTrangThai(listBan[indexBan].MaTrangThai);
                        Panel p = taoBan(listBan[indexBan].MaBan, listBan[indexBan].TenBan, tenTT);
                        p.Location = new Point(x, y);
                        groupBox1.Controls.Add(p);
                        x += p.Width + 10;
                        indexBan++;
                    }
                    x = 10;
                    y += 90;
                }
            }
            catch { }
        }

        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            TaoDSban();
        }

        public Panel taoBan(string maBan, string TenBan, string trangthai)
        {
            Panel panel = new Panel
            {
                Width = 65,
                Height = 65,
                // Set the border style
                BorderStyle = BorderStyle.FixedSingle,
                Name = TenBan,
                BackgroundImage = Properties.Resources.chair,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            //màu theo trạng thái và TAG
            switch (trangthai)
            {
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaCoKhach)://trangThaiBanCoKhach
                    {
                        panel.BackColor = xuLyBan.mauCoKhach;
                        mauCoKhach = xuLyBan.mauCoKhach;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiDaCoKhach;
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiDaDat)://trangThaiBanDaDat
                    {
                        panel.BackColor = xuLyBan.mauBanDaDat;
                        MauDaDat = xuLyBan.mauBanDaDat;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiDaDat;
                        break;
                    }
                case var x when x.Equals(xuLyTrangThaiBan.tenTrangThaiBanTrong): //trangThaiBanTrong
                    {
                        panel.BackColor = xuLyBan.mauBanTrong;
                        MauTrong = xuLyBan.mauBanTrong;
                        panel.Tag = xuLyTrangThaiBan.tenTrangThaiBanTrong;
                        break;
                    }
                default:
                    break;
            }
            panel.Click += Panel_Click;
            //Label label = new Label
            //{
            //    Text = TenBan,
            //    Location = new Point(0, 0),
            //    Name = maBan,
            //    Font = new Font("Arial", 12), // Set the font with size 12
            //};
            //panel.Controls.Add(label);
            return panel;
        }
    }
}
