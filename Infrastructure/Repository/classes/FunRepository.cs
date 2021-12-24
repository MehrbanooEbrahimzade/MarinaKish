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
        public async Task<bool> CheckFunTypeIsExistAsynch(Guid id)
        {
            return await IncludeFunWithScheduleInfo().AnyAsync(x => x.Id == id && x.IsActive == true);
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
        public async Task<Fun> GetFunByIdAsynch(Guid id)
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
        public async Task<Fun> GetFunByFunNameAsynch(string name)
        {
            return await IncludeFunWithScheduleInfo()
                .FirstOrDefaultAsync(f => f.Name == name);
        }


        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<Fun>> GetAllActivedFunAsynh()
        {
            return await IncludeFunWithScheduleInfo()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<Fun>> GetAllDisActivedFunAsynch()
        {
            return await IncludeFunWithScheduleInfo()
                .Where(x => x.IsActive == false)
                .ToListAsync();
        }


        /// <summary>
        /// گرفتن تفریح فعال باایدی 
        /// </summary>
        public async Task<Fun> GetActiveFunByIdAsynch(Guid id)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// گرفتن تفریح غیر فعال باایدی 
        /// </summary>
        public async Task<Fun> GetDisActiveFunByIdAsynch(Guid id)
        {
            return await IncludeFunWithScheduleInfo()
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
        }

        /// <summary>
        ///  دریافت تفریح فعال با اسم
        /// <summary>
        public async Task<Fun> GetActiveFunWithFunNameAsynch(string name) 
        {
            var fun = IncludeFunWithScheduleInfo().Where(x => x.Name == name && x.IsActive);
            return (Fun)fun;
        }

        public async Task<List<Fun>> GetAllFunActiveSchedulesById(Guid funId)
        {
            return  await  _context.Funs.Where(x => x.Id == funId && x.IsActive == true && x.ScheduleInfo.StartTime >= DateTime.Now.TimeOfDay)
            .OrderByDescending(x => x.ScheduleInfo.StartTime.Days)
            .ToListAsync();
        }

        /// <summary>
        /// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        /// </summary>
        public async Task<List<Fun>> GetAllFunDisActiveSchedulesById(Guid funId)
        {
           return await _context.Funs
               .Where(x => x.Id == funId && x.IsActive == false && x.ScheduleInfo.StartTime >= DateTime.Now.TimeOfDay)
               .OrderByDescending(x => x.ScheduleInfo.StartTime)
              .ToListAsync();
        }


        public IQueryable<Fun> IncludeFunWithScheduleInfo()
        {
            var funWithScheduleInfo = _context.Funs.Include(f => f.ScheduleInfo);
            return funWithScheduleInfo;
        }
    }
}
