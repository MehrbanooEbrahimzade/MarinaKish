using System;
using System.Globalization;

namespace Infrastructure.Extensions
{
    public static class DateTimeExtensionBase
    {
        public static readonly PersianCalendar persianCalendar = new PersianCalendar();
        public static DateTime ConvertToShamsi(this DateTime date)
        {
            try
            {
                
                var persianDate = string.Format("{0}/{1}/{2}",
                persianCalendar.GetYear(date), persianCalendar.GetMonth(date), persianCalendar.GetDayOfMonth(date));

                return Convert.ToDateTime(persianDate).Date;
            }
            catch (Exception)
            {
                throw new FormatException();
            }

        }
        public static DateTime ConvertToMiladiDate(this DateTime date)
        {
            try
            {
               

                DateTime miladiDate = new DateTime(date.Year, date.Month, date.Day, persianCalendar);
                return miladiDate;
            }
            catch (Exception)
            {
                throw new FormatException();
            }
        }
    }

}
