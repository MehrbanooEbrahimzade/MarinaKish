using Domain.Enums;
using Domain.Models;
using Infrastructure.Persist;
using Infrastructure.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<bool> CheckFunTypeIsExist(string name)
        {
            return await IncludeFunWithScheduleInfo().AnyAsync(x => x.Name == name && x.IsActive == true);
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
            return await IncludeFunWithScheduleInfo().
                FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<bool> DeleteFunAsync(Guid id)
        {
            var fun = IncludeFunWithScheduleInfo().Where(f => f.Id == id);
            _context.Funs.Remove((Fun)fun);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        public async Task<List<Fun>> GetAllFunAsync()
        {
            return await IncludeFunWithScheduleInfo()
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن تفریح بااسم تفریح
        /// </summary>
        public async Task<Fun> GetFunByFunType(string name)
        {
            return await IncludeFunWithScheduleInfo()
                .FirstOrDefaultAsync(f => f.Name == name);
        }

        ///// <summary>
        ///// دریافت فایل با آیدی
        ///// </summary>
        //public async Task<File> GetFileById(Guid fileid)
        //{
        //    return await _context.Files
        //        .SingleOrDefaultAsync(x => x.Id == fileid && x.IsActive == true);
        //}

        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<Fun>> GetAllActivedFun()
        {
            return await IncludeFunWithScheduleInfo()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<Fun>> GetAllDisActivedFun()
        {
            return await IncludeFunWithScheduleInfo()
                .Where(x => x.IsActive == false)
                .ToListAsync();
        }


        /// <summary>
        /// گرفتن تفریح فعال باایدی 
        /// </summary>
        public async Task<Fun> GetActiveFunById(Guid id)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// گرفتن تفریح غیر فعال باایدی 
        /// </summary>
        public async Task<Fun> GetDisActiveFunById(Guid id)
        {
            return await IncludeFunWithScheduleInfo()
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
        }

        // ???????????????????????
        /// </summary>
        /// <returns></returns>
        ///// <summary>
        ///// گرفتن تفریح فعال با اسم تفریح
        ///// </summary>
        //public async Task<Fun> GetActiveFunWithFunName(string name) 
        //{
        //    var fun = IncludeFunWithScheduleInfo().Where(x => x.Name == name && x.IsActive);
        //    return (Fun)fun;
        //}

        ///// <summary>
        ///// دریافت همه سانس های برگذار نشده فعال یک تفریح با آیدی
        ///// </summary>
        //public async Task<List<Schedule>> GetAllFunActiveSchedulesById(Guid funid)
        //{
        //  return await _context.Schedules
        //      .Where(x => x.FunId == funid && x.IsExist == true && x.ExecuteDateTime >= DateTime.Now)
        //     .OrderByDescending(x => x.ExecuteDateTime)
        //      .ToListAsync();
        //}

        /// <summary>
        /// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        /// </summary>
        //public async Task<List<Schedule>> GetAllFunDisActiveSchedulesById(Guid id)
        //{
        //   return await _context.Schedules
        //       .Where(x => x.FunId == id && x.IsExist == false && x.ExecuteDateTime >= DateTime.Now)
        //       .OrderByDescending(x => x.ExecuteDateTime)
        //      .ToListAsync();
        //}
        public IQueryable<Fun> IncludeFunWithScheduleInfo()
        {
            var funWithScheduleInfo = _context.Funs.Include(f => f.ScheduleInfo);
            return funWithScheduleInfo;
        }
    }
}
