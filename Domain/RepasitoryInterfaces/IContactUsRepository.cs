using Domain.Models;
using Domain.RepasitoryInterfaces;
using System;
using System.Threading.Tasks;

namespace Domain.RepasitoryInterfaces
{
    public interface IContactUsRepository : IGenericRepository<ContactUs>
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
