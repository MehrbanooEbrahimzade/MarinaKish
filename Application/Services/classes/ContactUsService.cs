using Application.Commands.ContactUs;
using Application.Mappers;
using Application.Services.interfaces;
using Infrastructure.Repository.interfaces;
using System;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Models;

namespace Application.Services.classes
{
    public class ContactUsService : IContactUsService
    {

        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        /// <summary>
        /// اضافه کردن اطلاعات
        /// </summary>
        public async Task AddContactUsAsync(AddContactUsCommand command)
        {
            var contactUs = command.ToModel();
            _contactUsRepository.AddContactUsAsync(contactUs);
        }

        /// <summary>
        /// گرفتن اطلاعات با آیدی
        /// </summary>
        public async Task<ContactUsDto> GetContactUsByIdAsync(Guid id)
        {
            var contactUs = await _contactUsRepository.GetContactUsByIdAsync(id);
            return contactUs?.ToDto();
        }

        /// <summary>
        /// ویرایش درباره مارینا
        /// </summary>
        public async Task UpdateContactUsAboutMarianaAsync(UpdateContactUsAboutMarianaContactUsCommand command)
        {
            var contactUsTask = FindContactUsAndCheckForNulling(command.Id);
            var contactUs = contactUsTask.Result;
            contactUs.UpdateAboutMariana(command.AboutMariana);
            CheckForSaving();
        }

        /// <summary>
        /// ویرایش آدرس ایمیل
        /// </summary>
        public async Task UpdateContactUsEmailAsync(UpdateContactUsEmailCommand command)
        {
            var contactUsTask = FindContactUsAndCheckForNulling(command.Id);
            var contactUs = contactUsTask.Result;
            contactUs.UpdateEmail(command.Email);
            CheckForSaving();
        }

        /// <summary>
        /// ویرایش شماره تماس 
        /// </summary>
        public async Task UpdateContactUsPhoneNumberAsync(UpdateContactUsPhoneNumberCommand command)
        {
            var contactUsTask = FindContactUsAndCheckForNulling(command.Id);
            var contactUs = contactUsTask.Result;
            contactUs.UpdatePhoneNumber(command.PhoneNumber);
            CheckForSaving();
        }

        /// <summary>
        /// ویرایش قوانین
        /// </summary>
        public async Task UpdateContactUsRulesAsync(UpdateContactUsRulesCommand command)
        {
            var contactUsTask = FindContactUsAndCheckForNulling(command.Id);
            var contactUs = contactUsTask.Result;
            contactUs.UpdateRules(command.Rules);
            CheckForSaving();
        }

        /// <summary>
        /// ویرایش آدرس اینستاگرام
        /// </summary>
        public async Task UpdateContactUsUrlInstagramAsync(UpdateContactUsUrlInstagramCommand command)
        {
            var contactUsTask = FindContactUsAndCheckForNulling(command.Id);
            var contactUs = contactUsTask.Result;
            contactUs.UpdateUrlInstagram(command.UrlInstagram);
            CheckForSaving();
        }

        /// <summary>
        /// ویرایش آدرس لینکدین
        /// </summary>
        public async Task UpdateContactUsUrlLinkedinAsync(UpdateContactUsUrlLinkedinCommand command)
        {
            var contactUsTask = FindContactUsAndCheckForNulling(command.Id);
            var contactUs = contactUsTask.Result;
            contactUs.UpdateUrlLinkedin(command.UrlLinkedin);
            CheckForSaving();
        }



        private async Task<ContactUs> FindContactUsAndCheckForNulling(Guid id)
        {
            var contactUS =await _contactUsRepository.GetContactUsByIdAsync(id);
            if (contactUS is null)
            {
                throw new Exception("Null");
            }

            return contactUS;
        }
        private async void CheckForSaving()
        {
            var save = await _contactUsRepository.UpdateContactUsAsync();
            if (!save)
            {
                throw new Exception("Not Save");
            }
        }
    }
}
