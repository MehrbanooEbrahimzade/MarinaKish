using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.classes
{
    public class FunRepository : BaseRepository, IFunRepository
    {
        public FunRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// چک کننده وجود داشتن تفریح
        /// </summary>
        public async Task<bool> CheckFunTypeIsExist(FunType funType)
        {
            return await _context.Funs.AnyAsync(x => x.FunType == funType && x.IsActive == true);
        }

        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        public async Task<bool> AddFunAsync(Fun fun)
        {
            await _context.Funs.AddAsync(fun);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت تفریح با آیدی
        /// </summary>
        public async Task<Fun> GetFunById(Guid id)
        {
            return await _context.Funs
                .SingleOrDefaultAsync(x => x.Id == id);
                
        }

        /// <summary>
        /// ذخیره عملیات انجام شده
        /// </summary>
        public async Task<bool> UpdateFunAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// حذف تفریح 
        /// </summary>
        public async Task<bool> DeleteFunAsync(Fun fun)
        {
            _context.Funs.Remove(fun);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        public async Task<List<Fun>> GetAllFunAsync()
        {
            return await _context.Funs
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن تفریح با نوع تفریح
        /// </summary>
        public async Task<Fun> GetFunByFunType(FunType funType)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.FunType == funType);
        }

        /// <summary>
        /// دریافت فایل با آیدی
        /// </summary>
        public async Task<File> GetFileById(Guid id)
        {
            return await _context.Files
                .SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<Fun>> GetAllActivedFun()
        {
            return await _context.Funs
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<Fun>> GetAllDisActivedFun()
        {
            return await _context.Funs
                .Where(x => x.IsActive == false)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن تفریح ها با نوع تفریح
        /// </summary>
        public async Task<List<Fun>> GetFunsWithFunType(FunType funType)
        {
            return await _context.Funs
                .Where(x => x.FunType == funType && x.IsActive)
                .ToListAsync();
        }

        public async Task<Fun> GetActiveFunById(Guid id)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task<Fun> GetDisActiveFunById(Guid id)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
        }

        /// <summary>
        /// دریافت همه سانس های برگذار نشده فعال یک تفریح با آیدی
        /// </summary>
        public async Task<List<Schedule>> GetAllFunActiveSchedulesById(Guid id)
        {
            return await _context.Schedules
                .Where(x => x.FunId == id && x.IsExist == true && x.ExcuteMiladiDateTime >= DateTime.Now)
                .OrderByDescending(x => x.ExcuteMiladiDateTime)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        /// </summary>
        public async Task<List<Schedule>> GetAllFunDisActiveSchedulesById(Guid id)
        {
            return await _context.Schedules
                .Where(x => x.FunId == id && x.IsExist == false && x.ExcuteMiladiDateTime >= DateTime.Now)
                .OrderByDescending(x => x.ExcuteMiladiDateTime)
                .ToListAsync();
        }
    }
}
