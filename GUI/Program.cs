using GUI.Frm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        public static frmMain _frmMain= null;
        public static frm_DangNhap _frm_DangNhap= null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _frm_DangNhap = new frm_DangNhap();
            Application.Run(_frm_DangNhap);
        }
    }
}
