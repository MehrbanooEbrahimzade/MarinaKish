using System;
using System.Globalization;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public sealed class User : IdentityUser
    {

        public User(string phoneNumber) : base(phoneNumber)
        {
            PhoneNumber = phoneNumber;
          
            RoleType =RoleType.None;
            
            Gender = Gender.None;
        }

        public void CompleteInformation(string firstName, string lastName, string nationalCode)
        {
            FullName = GenerateFullName(firstName, lastName);
            NationalCode = nationalCode;
        }

        public static string GenerateFullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public void UpdateProfile(string firstName, string lastName,
            string nationalCode, DateTime birthDay, CreditCard creditCard)
        {
            FullName = GenerateFullName(firstName, lastName);
            NationalCode = nationalCode;
            BirthDay = ConvertMiladiToShamsi(birthDay);
            CreditCard = creditCard;
        }
        public static  DateTime ConvertMiladiToShamsi(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            
            DateTime birthdate = new DateTime(date.Year,date.Month,date.Day, pc);
            return birthdate;

        }

        public CreditCard CreditCard { get; private set; }

        public string FullName { get; private set; }

        /// <summary>
        /// سطح دسترسی
        /// </summary>
        public RoleType RoleType { get; private set; }

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; private set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public Gender Gender { get; private set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; private set; }

        /// <summary>
        /// پشتیبانی
        /// </summary>

        private User() { }

    }
}
