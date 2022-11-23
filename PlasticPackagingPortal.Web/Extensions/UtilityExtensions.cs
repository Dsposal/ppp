using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticPackagingPortal.Web.Extensions
{
    public static class UtilityExtensions
    {
        public static string? ParseAndFormatExcelDate(this string str, string format = "dd/MM/yyyy")
        {
            //Include the time in the format by default as excel stores dates as such
            string[] validFormats = {format, $"{format} HH:mm:ss"};
            
            return DateTime.TryParseExact(str, validFormats, null, System.Globalization.DateTimeStyles.None,
                out DateTime result) ? result.ToString(format) : null;
        }


        
        public static string? ToNullIfWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? null : str;
        }

        public static bool ToBooleanFromBinaryStr(this string str)
        {
            return str == "1";
        }
    }
}
