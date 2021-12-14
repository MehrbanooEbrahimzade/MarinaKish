using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Fun
    {
        public Fun(enums.FunType funType, decimal price, TimeSpan startTime, TimeSpan endTime, int sansDuration, int sansTotalCapacity, int sansGapTime, string about)
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
            About = about;
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
        ///  متد سازی اسامی تفریح  
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
        /// متد سازی قیمت 
        /// </summary>
        public void ForPrice(decimal price)
        {
            this.Price = price;
        }

        /// <summary>
        /// زمان شروع :
        /// </summary>
        public TimeSpan StartTime { get; private set; }


        /// <summary>
        /// متد سازی زمان شروع  
        /// </summary>
        public void ForStartTime(TimeSpan starttime)
        {
            this.StartTime = starttime;
        }
        /// <summary>
        /// زمان پایان :
        /// </summary>
        public TimeSpan EndTime { get; private set; }

        /// <summary>
        /// متد سازی زمان پایان  
        /// </summary>
        public void ForEndTime(TimeSpan endtime)
        {
            this.EndTime = endtime;
        }
        /// <summary>
        /// مدت زمان : 
        /// </summary>
        public int SansDuration { get; private set; }

        /// <summary>
        /// متد سازی مدت زمان  
        /// </summary>
        public void ForSansDuration(int sansduration)
        {
            this.SansDuration = sansduration;
        }

        /// <summary>
        /// کل فضای سانس
        /// </summary>
        public int SansTotalCapacity { get; private set; }

        /// <summary>
        /// متد سازی کل فضای سانس 
        /// </summary>
        public void ForSansTotalCapacity(int sanstotalcapacity)
        {
            this.SansTotalCapacity = sanstotalcapacity;
        }

        /// <summary>
        /// زمان استراحت بین 2 سانس :
        /// </summary>
        public int SansGapTime { get; private set; }

        /// <summary>
        /// متد سازی زمان استراحت بین 2 سانس     
        /// </summary>
        public void ForSansGapTime(int sansgaptime)
        {
            this.SansGapTime = sansgaptime;
        }

        /// <summary>
        /// فضای باقی مانده انلاین :
        /// </summary>
        public int OnlineCapacity { get; private set; }

        /// <summary>
        ///  ++متد سازی فضای باقی مانده انلاین   
        /// </summary>
        public void PlassOnlineCapacity(int onlinecapacity)
        {
            this.OnlineCapacity += onlinecapacity;
            this.OnlineCapacity -= onlinecapacity;

        }

        /// <summary>
        ///  --متد سازی فضای باقی مانده انلاین   
        /// </summary>
        public void MinusOnlineCapacity(int onlinecapacity)
        {
            this.OnlineCapacity -= onlinecapacity;
        }

        /// <summary>
        /// فضای باقی مانده حقیقی :
        /// </summary>
        public int RealTimeCapacity { get; private set; }

        /// <summary>
        ///  ++متد سازی فضای باقی مانده حقیقی   
        /// </summary>
        public void PlassRealTimeCapacity(int realtimecapacity)
        {
            this.RealTimeCapacity += realtimecapacity;
        }

        /// <summary>
        ///  --متد سازی فضای باقی مانده حقیقی  
        /// </summary>
        public void MinusRealTimeCapacity(int realtimecapacity)
        {
            this.RealTimeCapacity -= realtimecapacity;
        }

        /// <summary>
        /// فضای مانده فروشنده :
        /// </summary>
        public int SellerCapacity { get; private set; }

        /// <summary>
        ///  ++متد سازی فضای مانده فروشنده  
        /// </summary>
        public void PlassSellerCapacity(int sellercapacity)
        {
            this.SellerCapacity += sellercapacity;
        }

        /// <summary>
        ///  --متد سازی فضای مانده فروشنده   
        /// </summary>
        public void MinusSellerCapacity(int sellercapacity)
        {
            this.SellerCapacity -= sellercapacity;
        }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        ///  متد سازی فعال بودن   
        /// </summary>
        public void ForIsActive(bool isactive)
        {

            this.IsActive = isactive;
        }

        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get; private set; }

        /// <summary>
        ///  متد سازی درباره تفریح  
        /// </summary>
        public void ForAbout(string aboute)
        {

            this.About = aboute;
        }

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get; private set; }

        /// <summary>
        ///  متد سازی عکس پس زمینه   
        /// </summary>
        public void ForBackgroundPicture(string backgroundpicture)
        {

            this.BackgroundPicture = backgroundpicture;
        }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        ///  متد سازی آیکون   
        /// </summary>
        public void ForIcon(string icon)
        {
            this.Icon = icon;
        }
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
