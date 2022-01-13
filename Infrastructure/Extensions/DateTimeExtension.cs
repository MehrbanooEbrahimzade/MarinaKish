using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class DateTimeExtension
    {
        public static readonly PersianCalendar persianCalendar = new PersianCalendar();
        public static DateTime ConvertToShamsi(DateTime date)
        {
            PersianCalendar persianParse = new PersianCalendar();

            var persianDate = string.Format("{0}/{1}/{2}",
            persianParse.GetYear(date), persianParse.GetMonth(date), persianParse.GetDayOfMonth(date));

            return Convert.ToDateTime(persianDate).Date;

        }
    }
}
