using System;
using System.Configuration;
using System.Linq;

namespace Magsaysay.Commons.Helpers
{
    /// <summary>
    /// Description of MiscHelpers.
    /// </summary>
    public static class MiscHelpers
    {
        public static long Timestamp()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static string FormatDate(DateTime date, string format = "MMMM dd, yyyy")
        {
            return date.ToString(format);
        }

        public static double HeightToCM(decimal? feet = 0, decimal? inches = 0)
        {
            double feet_cm = (double) feet * 30.48;
            double inches_cm = (double) inches * 2.54;

            return feet_cm + inches_cm;
        }

        public static decimal[] ConvertHeightToFeetInches(decimal? cm = 0)
        {
            decimal[] cms = new decimal[2];

            double c = (double) cm * 0.0328084;

            cms[0] = Math.Truncate((decimal) c / 1);
            cms[1] = (decimal) Math.Round((c  % 1) * 12, 0);

            return cms;
        }

        public static string GenerateCode(int length = 50)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        public static decimal NullToZero(decimal? dec)
        {
            if (dec == null)
            {
                return 0;
            }
            else
            {
                return (decimal) dec;
            }
        }

        public static string NullToEmpty(string s)
        {
            if (s == null)
            {
                return string.Empty;
            }
            else
            {
                return s;
            }
        }
    }
}
