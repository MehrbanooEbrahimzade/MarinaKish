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
            catch (Exception ex)
            {
                var errors = ex.Message;
                throw new FormatException();
            }

        }
        public static DateTime ConvertToMiladiDate(this string date)
        {
            try
            {

                DateTime Date = Convert.ToDateTime(date);
                DateTime miladiDate = new DateTime(Date.Year, Date.Month, Date.Day, persianCalendar);
                return miladiDate;
            }
            catch (Exception)
            {
                throw new FormatException();
            }
        }
    }

}
