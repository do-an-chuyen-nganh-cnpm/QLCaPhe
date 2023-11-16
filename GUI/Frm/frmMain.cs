using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using GUI.UControl;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UControl.UC_ThongKe u = new UControl.UC_ThongKe();
            panel1.Controls.Clear(); panel1.Controls.Add(u);

        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_KhuyenMai u = new UC_KhuyenMai();
            panel1.Controls.Clear();
            panel1.Controls.Add(u);
        }
    }
}
