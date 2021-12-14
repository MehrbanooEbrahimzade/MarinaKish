using System;
using Domain.Models.enums;

namespace Domain.Models
{
    public class User
    {
        public User(string cellPhone, string fullname, string username, string password, string nationalcode)
        {
            this.NationalCode = nationalcode;
            this.Password = password;
            this.UserName = username;
            this.Id = new Guid();
            this.FullName = fullname;
            this.PhoneNumber = cellPhone;
            this.VerifyCode = GenerateVerifyCode();
            this.IsActive = true;
            this.SystemUserCode = GenerateUserCode();
            this.RoleType = RoleTypec.Buyer;
            this.Gender = EGender.Other;
            this.BirthDay = default;
            this.DateJoin = DateTime.Now;
        }

        /// <summary>
        /// ID
        /// </summary>
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
        /// استان
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// کد شناساییه کاربر ، ساخته شده توسط ما
        /// </summary>
        public string SystemUserCode { get; private set; }
        /// <summary>
        /// سطح دسترسی
        /// </summary>
        public RoleTypec RoleType { get; set; }   //TODO: delete                                                           

        /// <summary>
        /// کد تایید
        /// </summary>
        public string VerifyCode { get; private set; }

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; set; }      //TODO: new class

        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; set; }       //TODO: new class

        /// <summary>
        /// شماره شبا
        /// </summary>

        public string ShabaNumber { get; set; }

        /// <summary>
        /// کیف پول
        /// </summary>
        public decimal Wallet { get; set; }       //TODO: delete  

        /// <summary>
        /// اطلاعات کانتکته کاربر
        /// </summary>
        public ContactInfo ContactInfo { get; set; }    //TODO: delete   

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

        public void SetProvince(string province)
        {
            this.Province = province;
        }

        public void SetVerifycode(string verifycode)
        {
            this.VerifyCode = verifycode;
        }

        public void SetBirthdate(DateTime dateTime)
        {
            this.BirthDay = dateTime;
        }

        public void SetIsActive(bool isactive)
        {
            this.IsActive = isactive;
        }
        private string GenerateUserCode()
        {
            var milisecond = DateTime.Now.Millisecond.ToString();
            var randomGenerate = new Random().Next(10000, 99999).ToString();
            return randomGenerate + "-" + milisecond;
        }
        private string GenerateVerifyCode()
        {
            var verifyCode = new Random().Next(1000, 9999).ToString();
            return verifyCode;
        }

    }
}
