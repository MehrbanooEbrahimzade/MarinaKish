using System;
using Domain.Enums;

namespace Application.Dtos
{
    public class FunDto
    {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public FunType EFunType { get; set; }

        /// <summary>
        /// قیمت :
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// زمان شروع :
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// زمان پایان :
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SansDuration { get; set; }

        /// <summary>
        /// کل فضای سانس
        /// </summary>
        public int SansTotalCapacity { get; set; }

        /// <summary>
        /// زمان استراحت بین 2 سانس :
        /// </summary>
        public int SansGapTime { get; set; }

        /// <summary>
        /// فضای باقی مانده انلاین :
        /// </summary>
        public int OnlineCapacity { get; set; }

        /// <summary>
        /// فضای باقی مانده حقیقی :
        /// </summary>
        public int RealTimeCapacity { get; set; }

        /// <summary>
        /// فضای مانده فروشنده :
        /// </summary>
        public int SellerCapacity { get; set; }

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get; set; }
    }
}
