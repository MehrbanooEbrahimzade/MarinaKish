using System;
using System.Threading.Tasks;
using Infrastructure.Persist;
using Infrastructure.Repository.interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.classes
{
    public class ContactUsRepository : BaseRepository, IContactUsRepository
    {

        public ContactUsRepository(DatabaseContext context) : base(context)
        {
        }


        /// <summary>
        /// اضافه کردن اطلاعات
        /// </summary>
        public async void AddContactUsAsync(ContactUs contactUs)
        {
            await _context.AddAsync(contactUs);
            _context.SaveChanges();
        }

        /// <summary>
        /// برگرداندن اطلاعات با آیدی
        /// </summary>
        public async Task<ContactUs> GetContactUsByIdAsync(Guid id)
        {
            var contactUs = await _context.ContactUs.FirstOrDefaultAsync(c => c.Id == id);
            return contactUs ?? throw new Exception("Null");
        }

        /// <summary>
        /// ویرایش درباره ماریانا
        /// </summary>
        public async Task<bool> UpdateContactUsAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
