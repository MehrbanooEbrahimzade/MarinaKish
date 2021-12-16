using System;
using System.Collections.Generic;
using Domain.Models.enums;

namespace Domain.Models
{
    public class Fun
    {
        public Fun(EFunType funType, string about)
        {
            Id = Guid.NewGuid();
            SystemFunCode = GenerateFunCode();
            FunType = funType;
            About = about;

            Comments = new List<Comment>();
            Schedules = new List<Schedule>();
        }

        public Fun() { }

        public List<Comment> Comments { get; private set; }
        public List<Schedule> Schedules { get; private set; }
        
        public void Update(EFunType eFunType, string about)
        {
            SystemFunCode = GenerateFunCode();
            FunType = eFunType;
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
        public EFunType FunType { get; private set; }
        
        /// <summary>
        /// فضای باقی مانده انلاین :
        /// </summary>
        public int OnlineCapacity { get; private set; } = 0;


        /// <summary>
        /// فضای باقی مانده حقیقی :
        /// </summary>
        public int RealCapacity { get; private set; } = 0;

        /// <summary>
        /// فعال بودن
        /// </summary>
        public bool IsActive { get; private set; } = true;


        /// <summary>
        /// درباره تفریح
        /// </summary>
        public string About { get; private set; }


        /// <summary>
        /// فضای مانده فروشنده :
        /// </summary>
        public int SellerCapacity { get; private set; } = 0;

        /// <summary>
        /// عکس پس زمینه
        /// </summary>
        public string BackgroundPicture { get;private set; }

        /// <summary>
        /// آیکون
        /// </summary>
        public string Icon { get;private set; }


        private string GenerateFunCode()
        {
            var millisecond = DateTime.Now.Millisecond.ToString();
            var randomGenerate = new Random().Next(10000, 99999).ToString();
            return millisecond + "-" + randomGenerate;
        }

        #region + -

        public void PlusRealCapacity(int realTimeCapacity)
        {
            this.RealCapacity += realTimeCapacity;
        }
        public void MinusRealCapacity(int realTimeCapacity)
        {
            this.RealCapacity -= realTimeCapacity;
        }


        public void PlusOnlineCapacity(int onlineCapacity)
        {
            this.OnlineCapacity -= onlineCapacity;
        }
        public void MinusOnlineCapacity(int onlineCapacity)
        {
            this.OnlineCapacity += onlineCapacity;
        }



        public void PlusSellerCapacity(int sellerCapacity)
        {
            this.SellerCapacity += sellerCapacity;
        }
        public void MinusSellerCapacity(int sellerCapacity)
        {
            this.SellerCapacity -= sellerCapacity;
        }

        #endregion

    }
}
