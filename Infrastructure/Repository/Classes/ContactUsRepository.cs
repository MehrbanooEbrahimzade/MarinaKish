using System;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Classes
{
    public class ContactUsRepository : GenericRepository<ContactUs>, IContactUsRepository
    {
        public ContactUsRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }

        ///// <summary>
        ///// اضافه کردن اطلاعات
        ///// </summary>
        public override async Task<bool> AddAsync(ContactUs contactUs)
        {
            try
            {
                await dbSet.AddAsync(contactUs);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e,"{ Repo } Add Method Error",typeof(CommentRepository));
                return false;
            }
        }
        
        ///// <summary>
        ///// برگرداندن اطلاعات با آیدی
        ///// </summary>
        public override async Task<ContactUs> GetByIdAsync(Guid id)
        {
            try
            {
                var contactUs =dbSet.Find(id);
                return contactUs ?? throw new NullReferenceException("یافت نشد");
            }
            catch (Exception e)
            {
                _logger.LogError(e,"{Repo} GetById method error",typeof(ContactUsRepository));
                return null;
            }
        }
        
        ///// <summary>
        ///// ویرایش درباره ماریانا
        ///// </summary>
        public async Task<bool> UpdateContactUsAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
       
    }
}
