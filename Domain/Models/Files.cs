using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Files
    {
        public Files(string fileName, string filePath)
        {

            Name = fileName;
            FilePath = filePath;
            IsActive = true;
            PlaceDate = DateTime.Now;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// مسیر
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// اندازه
        /// </summary>
        public string Size { set { } } //فقظ خواندنی

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get;  set; }

        /// <summary>
        /// زمان اضافه شدن
        /// </summary>
        public DateTime PlaceDate { get; private set; }

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

        private Files()
        {

        }
    }
}
