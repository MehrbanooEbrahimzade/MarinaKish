using System;

namespace Application.Dtos
{
    public class FilesDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// فعال بودن
        ///// </summary>
        //public bool isActive { get; set; }

        ///// <summary>
        ///// زمان اضافه شدن - شمسی
        ///// </summary>
        //public string ShamsiPlaceDate { get; set; }

    }
}
