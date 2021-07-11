using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common.Utilities
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                       pc.GetDayOfMonth(value).ToString("00");
            }
            catch
            {
                return null;
            }


        }

        public static DateTime ToGregorian(this string value)
        {
            if (value != null && value != "")
            {
                string[] date = value.Split('/');

                PersianCalendar pc = new PersianCalendar();
                int year = Convert.ToInt32(date[0].Fa2En());
                int month = Convert.ToInt32(date[1].Fa2En());
                int day = Convert.ToInt32(date[2].Fa2En());
                DateTime dt = new DateTime(year, month, day, pc);
                return DateTime.Parse(dt.ToString(CultureInfo.InvariantCulture));
            }
            else
                return DateTime.Now;
        }
    }
}
