using Application.Commands.ContactUs;
using System;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services.interfaces
{
    public interface IContactUsService
    {
        /// <summary>
        /// اضافه کردن اطلاعات
        /// </summary>
        Task AddContactUsAsync(AddContactUsCommand command);

        /// <summary>
        /// گرفتن اطلاعات با آیدی
        /// </summary>
        Task<ContactUsDto> GetContactUsByIdAsync(Guid id);

        /// <summary>
        /// ویرایش درباره ماریانا
        /// </summary>
        Task UpdateContactUsAboutMarianaAsync(UpdateContactUsAboutMarianaContactUsCommand command);

        /// <summary>
        /// ویرایش قوانین
        /// </summary>
        Task UpdateContactUsRulesAsync(UpdateContactUsRulesCommand command);

        /// <summary>
        /// ویرایش شماره تماس
        /// </summary>
        Task UpdateContactUsPhoneNumberAsync(UpdateContactUsPhoneNumberCommand command);

        /// <summary>
        /// ویرایش  ایمیل
        /// </summary>
        Task UpdateContactUsEmailAsync(UpdateContactUsEmailCommand command);

        /// <summary>
        /// ویرایش آدرس لینکدین
        /// </summary>
        Task UpdateContactUsUrlLinkedinAsync(UpdateContactUsUrlLinkedinCommand command);

        /// <summary>
        /// ویرایش آدرس اینستاگرام
        /// </summary>
        Task UpdateContactUsUrlInstagramAsync(UpdateContactUsUrlInstagramCommand command);
    }
}
