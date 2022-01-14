using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastructure.Extensions
{
    public  class DateTimeExtensionBase
    {
        public  readonly PersianCalendar persianCalendar = new PersianCalendar();
        public  DateTime ConvertToShamsi(DateTime date)
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
        public DateTime ConvertToMiladiDate(DateTime date)
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
