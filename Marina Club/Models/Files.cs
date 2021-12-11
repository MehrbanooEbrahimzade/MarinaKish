using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Models
{
    public class Files
    {
        public Files(string fileName, string filePath)
        {
            Name = fileName;
            FilePath = filePath;
            isActive = true;
            PlaceDate = DateTime.Now;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// مسیر
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// اندازه
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool isActive { get; set; }

        /// <summary>
        /// زمان اضافه شدن
        /// </summary>
        public DateTime PlaceDate { get; set; }

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
