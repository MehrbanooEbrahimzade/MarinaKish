using Marina_Club.Models;
using Marina_Club.Models.enums;
using System;
using System.Collections.Generic;

namespace Marina_Club.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// ID 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// نام و نام خانوادگی
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string CellPhone { get; set; }


        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// استان
        /// </summary>
        public string Provice { get; set; }

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }

        /// <summary>
        /// فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// تاریخ تولد - میلادی
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// اطلاعات roleType کاربر
        /// </summary>
        public RoleTypec RoleType { get; set; }

        /// <summary>
        /// اطلاعات کانتکته کاربر
        /// </summary>
        public ContactInfoDto ContactInfo { get; set; }

        /// <summary>
        /// کیف پول
        /// </summary>
        public decimal Wallet { get; set; }

        /// <summary>
        /// آیا کاربر جدیدی است؟
        /// </summary>
        public bool IsNewMember { get; set; }

        /// <summary>
        /// زمان ثبت نام در مارینا - شمسی
        /// </summary>
        public string DateJoinInShamsi { get; set; }

    }
}
