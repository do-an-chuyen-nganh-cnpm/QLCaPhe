using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Librari
    {
        private static Random random = new Random();
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string TaoMaKhuyenMai()
        {
            string result = "";
            DateTime date = DateTime.Now;
            result = "KM" + date.Second.ToString() + date.Minute.ToString() + date.Hour.ToString() + date.Day.ToString() + date.Month.ToString();
            return result;
        }
        private static string GenerateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(Characters.Length);
                sb.Append(Characters[index]);
            }

            return sb.ToString();
        }
        public static string ConvertFormatTien(double amount)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Vietnamese culture
            return amount.ToString("N0", cultureInfo) + " VND"; // "N0" format specifier for number with no decimal places

        }
        public static string CreateMaKhachHang()
        {
            return GenerateRandomString(10);
        }

        public static string CreateMaHoaDon()
        {
            return GenerateRandomString(10);
        }
        public static string ConvertToCurrencyFormat(double value)
        {
            // Tạo một đối tượng CultureInfo để sử dụng định dạng tiền Việt Nam
            CultureInfo culture = new CultureInfo("vi-VN");

            // Sử dụng phương thức ToString với đối tượng CultureInfo
            string formattedValue = value.ToString("C", culture);

            return formattedValue;
        }
        static double TryConvertToDouble(string formattedValue)
        {
            // Loại bỏ các ký tự không phải là số từ chuỗi
            string numericString = new string(formattedValue.Where(char.IsDigit).ToArray());

            // Thử chuyển đổi chuỗi thành double
            if (double.TryParse(numericString, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            // Trả về giá trị double.MinValue để biểu thị rằng chuyển đổi thất bại
            return double.MinValue;
        }
        public static string createMaQuyen()
        {
            return GenerateRandomString(4);
        }
        public static string createMaManHinh()
        {
            return GenerateRandomString(3);
        } 
        public static string createMaCalamViec()
        {
            return GenerateRandomString(3);
        }
    }
}
