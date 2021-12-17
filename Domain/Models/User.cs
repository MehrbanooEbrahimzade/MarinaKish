using System;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public sealed class User : IdentityUser
    {

        public User(string phoneNumber) : base(phoneNumber)
        {
            PhoneNumber = phoneNumber;
            ERoleType =RoleType.None;
            EGender = Gender.None;
        }

        public void CompleteInformation(string firstName, string lastName, string nationalCode)
        {
            FullName = GenerateFullName(firstName, lastName);
            NationalCode = nationalCode;
        }

        private static string GenerateFullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public void UpdateProfile(string firstName, string lastName,
            string nationalCode, DateTime birthDay, CreditCard creditCard)
        {
            FullName = GenerateFullName(firstName, lastName);
            NationalCode = nationalCode;
            BirthDay = birthDay;
            CreditCard = creditCard;
        }

        public CreditCard CreditCard { get; private set; }

        public string FullName { get; private set; }

        /// <summary>
        /// سطح دسترسی
        /// </summary>
        public RoleType ERoleType { get; private set; }

        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; private set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public Gender EGender { get; private set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDay { get; private set; }

        private User() { }

    }
}
