namespace Application.Commands
{
    public class TwoDateSearchCommand
    {
        /// <summary>
        /// تاریخ اول - به شمسی
        /// </summary>
        public PersianDateCommand FirstPersianDate { get; set; }

        /// <summary>
        /// تاریخ دوم - به شمسی
        /// </summary>
        public PersianDateCommand SecondPersianDate { get; set; }
    }
}
