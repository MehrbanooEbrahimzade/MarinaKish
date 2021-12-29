using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.interfaces
{
    public interface IContactUsRepository
    {
        /// <summary>
        /// اضافه کردن اطلاعات  
        /// </summary>
        void AddContactUsAsync(ContactUs contactUs);

        /// <summary>
        /// برگرداندن اطلاعات با آیدی
        /// </summary>
        Task<ContactUs> GetContactUsByIdAsync(Guid id);
        
        /// <summary>
        ///  ویرایش اطلاعات
        /// </summary>
        Task<bool> UpdateContactUsAsync();
    }
}
