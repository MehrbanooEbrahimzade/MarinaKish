using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marina_Club.Models
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
        public Guid Id { get; set; }

        /// <summary>
        /// کد شناسایی تفریح - ساخته شده توسط ما
        /// </summary>
        public string SystemFunCode { get; set; }

        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public enums.FunType FunType { get; set; }

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
        /// مدت زمان : 
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
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string icon { get; set; }

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
