using System;
using System.Collections.Generic;
using Domain.Models.enums;

namespace Domain.Models
{
    public class User
    {
        public User(string phoneNumber, string fullname, string username, string password, string nationalcode)
        {
            PhoneNumber = phoneNumber;
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
      
        public UserCart UserCart { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Guid Id { get; private set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// رمزعبور
        /// </summary>
        public string Password { get; private set; }
        

        /// <summary>
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; private set; }

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
        public DateTime DateJoin { get; set; }   // Identity 
        

        public void SetUserName(string username)
        {
            this.UserName = username;
        }

        public void SetFullName(string fullname)
        {
            this.FullName = fullname;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public void SetGender(EGender gender)
        {
            this.Gender = gender;
        }
        public void SetBirthdate(DateTime BirthDay)
        {
            this.BirthDay = BirthDay;
        }
        
        public void SetVerifycode(string verifycode)
        {
            this.VerifyCode = verifycode;
        }


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
