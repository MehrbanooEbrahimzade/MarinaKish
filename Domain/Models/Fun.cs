using System;

namespace Domain.Models
{
    public class Fun
    {
        public Fun(enums.FunType funType, decimal price, TimeSpan startTime, TimeSpan endTime, int sansDuration, int sansTotalCapacity, int sansGapTime)
        {
            SystemFunCode = GenerateFunCode();
            FunType = funType;
            Price = price;
            StartTime = startTime;
            EndTime = endTime;
            SansDuration = sansDuration;
            SansTotalCapacity = sansTotalCapacity;
            SansGapTime = sansGapTime;
            IsActive = true;
            OnlineCapacity = 0;
            RealTimeCapacity = 0;
            SellerCapacity = 0;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get;private set; }

        /// <summary>
        /// کد شناسایی تفریح - ساخته شده توسط ما
        /// </summary>
        public string SystemFunCode { get;private set; }

        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public enums.FunType FunType { get;/*private*/ set; }

        /// <summary>
        /// قیمت :
        /// </summary>
        public decimal Price { get;/*private*/ set; }

        /// <summary>
        /// زمان شروع :
        /// </summary>
        public TimeSpan StartTime { get;/*private*/ set; }

        /// <summary>
        /// زمان پایان :
        /// </summary>
        public TimeSpan EndTime { get;/*private*/ set; }

        /// <summary>
        /// مدت زمان : 
        /// </summary>
        public int SansDuration { get;/*private*/ set; }

        /// <summary>
        /// کل فضای سانس
        /// </summary>
        public int SansTotalCapacity { get;/*private*/ set; }

        /// <summary>
        /// زمان استراحت بین 2 سانس :
        /// </summary>
        public int SansGapTime { get;/*private*/ set; }

        /// <summary>
        /// فضای باقی مانده انلاین :
        /// </summary>
        public int OnlineCapacity { get; set; } //فقط خواندینه

        /// <summary>
        /// فضای باقی مانده حقیقی :
        /// </summary>
        public int RealTimeCapacity { get;/*private*/ set; }

        /// <summary>
        /// فضای مانده فروشنده :
        /// </summary>
        public int SellerCapacity { get;/*private*/ set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get;/*private*/ set; }

        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get;/*private*/ set; } //?

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get; set; }

        public string GenerateFunCode()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var randomGenerate = new Random().Next(10000, 99999).ToString();
            return milisecond + "-" + randomGenerate;
        }

        private Fun()
        {

        }
    }
}
