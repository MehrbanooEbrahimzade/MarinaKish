using System;

namespace Application.Dtos
{
    public class FilesDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool isActive { get; set; }

        /// <summary>
        /// زمان اضافه شدن - شمسی
        /// </summary>
        public string ShamsiPlaceDate { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// آیدی تفریح
        /// </summary>
        public string FunID { get; set; }

        /// <summary>
        /// آیدی سانس
        /// </summary>
        public string ScheduleID { get; set; }

    }
}
