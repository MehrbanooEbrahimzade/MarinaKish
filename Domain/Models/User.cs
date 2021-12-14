using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class User
    {

        public User(string cellPhone )
        {
            CellPhone = cellPhone;
            VerifyCode = GenerateVerifyCode();
            IsActive = true;
            SystemUserCode = GenerateUserCode();
            RoleType = RoleTypec.Buyer;
            Gender = EGender.Other;
            BirthDay = default;  
            DateJoin = DateTime.Now;
        }
        
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set ; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// رمزعبور
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// استان
        /// </summary>
        public string Provice { get; set; } //TODO:delete

        /// <summary>
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// کد شناساییه کاربر ، ساخته شده توسط ما
        /// </summary>
        public string SystemUserCode { get; set; } // generate 

        /// <summary>
        /// سطح دسترسی
        /// </summary>
        public enums.RoleTypec RoleType { get; set; }  //TODO:delete                                                         

        /// <summary>
        /// کد تایید
        /// </summary>
        public string VerifyCode { get; set; } //generate (adad)

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; set; }
         
        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; set; }   //TODO:delete

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }  //TODO:delete
         

        /// <summary>
        /// جنسیت
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// اطلاعات کانتکته کاربر
        /// </summary>
        public ContactInfo ContactInfo { get; set; }  //TODO:delete

        /// <summary>
        /// کیف پول
        /// </summary>
        public decimal Wallet { get; set; }  //TODO:delete

        /// <summary>
        /// زمان وارد شدن به مارینا
        /// </summary>
        public DateTime DateJoin { get; set; }  //TODO:delete


        public string GenerateUserCode()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var randomGenerate = new Random().Next(10000, 99999).ToString();
            return randomGenerate + "-" + milisecond;
        }

        public string GenerateVerifyCode()
        {
            var verifyCode = new Random().Next(1000, 9999).ToString();
            return verifyCode;
        }

        private User() { }
    }
}
