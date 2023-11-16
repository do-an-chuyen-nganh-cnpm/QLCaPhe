using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Librari
    {
        public static string TaoMaKhuyenMai()
        {
            string result = "";
            DateTime date  = DateTime.Now;
            result = "KM"+date.Second.ToString() + date.Minute.ToString() + date.Hour.ToString() + date.Day.ToString()+date.Month.ToString();
            return result;
        }
    }
}
