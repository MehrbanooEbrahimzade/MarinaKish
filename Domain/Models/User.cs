using System;
using System.Collections.Generic;
using Domain.Models.enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public User(string phoneNumber, string fullname, string username, string password, string nationalcode
            ,UserCart userCart)

        {
            PhoneNumber = phoneNumber;
            FullName = fullname;
            UserName = username;
            Password = password;
            NationalCode = nationalcode;
            UserCart = userCart;
            VerifyCode = GenerateVerifyCode();
            IsActive = true;
            RoleType = enums.RoleType.Buyer;
            Gender = EGender.Other;
            BirthDay = default;  
            DateJoin = DateTime.Now;
        }
        public User() { }

        /// <summary>
        /// ID
        /// </summary>

        public UserCart UserCart { get; private set; }
        public CartItem Item { get; private set; }

        public string FullName { get; private set; }

        /// <summary>
        ///  رمز عبور کاربر
        /// </summary>
       
        public string Password { get; private set; }
        

        /// <summary>
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; private set; }


        /// <summary>
        /// سطح دسترسی
        /// </summary>
        public enums.RoleType RoleType { get; private set; }                                                     

        /// <summary>
        /// کد تایید
        /// </summary>
        public string VerifyCode { get; private set; }  

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; private set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public EGender Gender { get; private set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; private set; }

        /// <summary>
        /// زمان وارد شدن به مارینا
        /// </summary>
        public DateTime DateJoin { get; private set; }  

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


        //public string GenerateUserCode()
        //{
        //    var millisecond = DateTime.Now.Millisecond.ToString();
        //    var randomGenerate = new Random().Next(10000, 99999).ToString();
        //    return randomGenerate + "-" + millisecond;
        //}

        public string GenerateVerifyCode()
        {
            var verifyCode = new Random().Next(1000, 9999).ToString();
            return verifyCode;
        }

    }
}
