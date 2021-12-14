using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Fun
    {
        public Fun(enums.FunType funType, decimal price, TimeSpan startTime, TimeSpan endTime
            , int sansDuration, int sansTotalCapacity, int sansGapTime, string about)
        {
            SystemFunCode = GenerateFunCode();
            FunType = funType;
            Price = price;
            StartTime = startTime;
            EndTime = endTime;
            SansDuration = sansDuration;
            SansTotalCapacity = sansTotalCapacity;
            SansGapTime = sansGapTime;
            About = about;
            IsActive = true;
            OnlineCapacity = 0;
            RealTimeCapacity = 0;
            SellerCapacity = 0;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// کد شناسایی تفریح - ساخته شده توسط ما
        /// </summary>
        public string SystemFunCode { get; private set; }

        /// <summary>
        /// اسامی تفریح
        /// </summary>
        public enums.FunType FunType { get; private set; }

        /// <summary>
        ///  متد سازی اسامی تفریح  //mbrk
        /// </summary>
        public void ForFunType(FunType funtype)
        {
            this.FunType = funtype;
        }
        /// <summary>
        /// قیمت :
        /// </summary>
        public decimal Price { get; private set; }



        /// <summary>
        /// زمان شروع :
        /// </summary>
        public TimeSpan StartTime { get; private set; }



        /// <summary>
        /// زمان پایان :
        /// </summary>
        public TimeSpan EndTime { get; private set; }


        /// <summary>
        /// مدت زمان : 
        /// </summary>
        public int SansDuration { get; private set; }


        /// <summary>
        /// کل فضای سانس
        /// </summary>
        public int SansTotalCapacity { get; private set; }


        /// <summary>
        /// زمان استراحت بین 2 سانس :
        /// </summary>
        public int SansGapTime { get; private set; }

        /// <summary>
        /// فضای باقی مانده انلاین :
        /// </summary>
        public int OnlineCapacity { get; private set; }


        /// <summary>
        /// فضای باقی مانده حقیقی :
        /// </summary>
        public int RealTimeCapacity { get; private set; }


        /// <summary>
        /// فضای مانده فروشنده :
        /// </summary>
        public int SellerCapacity { get; private set; }


        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get; private set; }

        /// <summary>
        ///  متد سازی درباره تفریح  //mbrk
        /// </summary>

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; private set; }

        public void MinusOnlineCapacity(int numberOfTicket)
        {
            this.OnlineCapacity -= numberOfTicket;
        }

        public void AddSellerCapacity(int numberOfTicket)
        {
            this.OnlineCapacity += numberOfTicket;
        }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get; private set; }
        /// <summary>
        /// متد برای آپدیت سرویس تفریح
        /// </summary>
        public Fun()
        {

        }
        public void UpdateFun(decimal price, string starttime
            , string endtime, int sansduration
            , int sanstotalcapacity, int sansgaptime
            , string about)
        {
            this.Price = price;
            this.StartTime = TimeSpan.Parse(starttime);
            this.EndTime = TimeSpan.Parse(endtime);
            this.SansTotalCapacity = sanstotalcapacity;
            this.SansGapTime = sansgaptime;
            this.About = about;

        }
        public void UpdateSchedule(int availablecapacity, int realtimecapacity)
        {
            this.OnlineCapacity += availablecapacity;
            this.RealTimeCapacity += realtimecapacity;
        }
        public void UpdateBackGround(string fileId)
        {
            this.BackgroundPicture = fileId;
        }
        public void UpdateIcon(string iconid)
        {
            this.Icon = iconid;
        }
        public void UpdateFunStatus(bool state)
        {
            this.IsActive = state;
        }
        public string GenerateFunCode()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var randomGenerate = new Random().Next(10000, 99999).ToString();
            return milisecond + "-" + randomGenerate;
        }

        public void AddRealTimeCapacity(int realtimecapacity)
        {
            this.RealTimeCapacity += realtimecapacity;
        }

        public void MinusSellerCapacity(int sellercapacity)
        {
            this.SellerCapacity -= sellercapacity;

        }

        public void MinusRealTimeCapacity(int realtimecapacity)
        {
            this.RealTimeCapacity -= realtimecapacity;

        }
    }
}
