using System;
using System.Collections.Generic;
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
            RoleType = enums.RoleType.Buyer;
            Gender = EGender.Other;
            BirthDay = default;  
            DateJoin = DateTime.Now;
        }
        
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set ; }
        public UserCart UserCart { get; set; }
        public List<Ticket> Tickets { get; set; }

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
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// کد شناساییه کاربر ، ساخته شده توسط ما
        /// </summary>
        public string SystemUserCode { get; set; } // Identity 

        /// <summary>
        /// سطح دسترسی
        /// </summary>
        public enums.RoleType RoleType { get; set; }   // Identity                                                         

        /// <summary>
        /// کد تایید
        /// </summary>
        public string VerifyCode { get; set; }  // Identity 

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; set; }
        
        /// <summary>
        /// زمان وارد شدن به مارینا
        /// </summary>
        public DateTime DateJoin { get; set; }   // Identity 


        public string GenerateUserCode()
        {
            var millisecond = DateTime.Now.Millisecond.ToString();
            var randomGenerate = new Random().Next(10000, 99999).ToString();
            return randomGenerate + "-" + millisecond;
        }

        public string GenerateVerifyCode()
        {
            var verifyCode = new Random().Next(1000, 9999).ToString();
            return verifyCode;
        }

        public User() { }
    }
}
