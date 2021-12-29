using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Classes
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        public ScheduleRepository(DatabaseContext context) : base(context)
        {

        }

     
        /// <summary>
        /// اضافه کردن سانس به تیبل
        /// </summary>
        public async Task<bool> AddScheduleAsync(List<Schedule> schedules)
        {
            foreach (var x in schedules)
            {
                await _context.Schedules.AddAsync(x);
            }
            return await _context.SaveChangesAsync() > 0;
        }
        ///// <summary>
        ///// دریافت تفریح با اسم تفریح
        ///// </summary>
        public async Task<Fun> SeachNameRecreationAsync(Guid id, string name)
        {
            return await _context.Funs.Include(f => f.ScheduleInfo)
                .FirstOrDefaultAsync(f => f.Name == name && f.Id == id);
        }

        /// <summary>
        /// اضافه کردن سانس به تیبل
        /// </summary>
        public async Task AddScheduleAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// پاک کردن همه سانس های یک تفریح
        /// </summary>
        public async Task DeleteAllSchedulesOfaFun(Guid funId)
        {
             _context.RemoveRange(_context.Schedules.Where(sc => sc.FunId == funId));
             await _context.SaveChangesAsync();

        }

        ///// <summary>
        ///// گرفتن همه سانس ها برای تفریح
        ///// </summary>
        //public async Task<List<Schedule>> GetAllSchedulesForFunWithFunType(Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.Id == id && x.IsExist == true)
        //        .OrderBy(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        //public async Task<List<Schedule>> GetAllSchedulesForFunWithId(Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.FunId == id && x.IsExist == true)
        //        .OrderBy(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// جستجوی سانس با تفریح و تاریخ
        ///// </summary>
        //public async Task<List<Schedule>> SearchSchedulesByTimeAndFun(DateTime excuteMiladiDate, Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.ExecuteDateTime.Year == excuteMiladiDate.Year && x.ExecuteDateTime.Month == excuteMiladiDate.Month &&
        //        x.ExecuteDateTime.Day == excuteMiladiDate.Day && x.FunId == id && x.IsExist == true)//
        //        .OrderByDescending(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// ذخیره اعمال انجام شده
        ///// </summary>
        //public async Task<bool> UpdateScheduleAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت سانس با آیدی
        ///// </summary>
        //public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        //{
        //    return await _context.Schedules
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        ///// <summary>
        ///// گرفتن تاریخ اخرین سانس
        ///// </summary>
        //public async Task<DateTime?> GetLastScheduleTimeByFunType(FunType funType) // momeni
        //{
        //    var sans = await _context.Schedules.Where(s => s.FunType == funType)
        //        .OrderByDescending(x => x.ExecuteDateTime).ToListAsync();

        //    if (sans.Count > 0)
        //    {
        //        return sans.OrderByDescending(s => s.ExecuteDateTime).First().ExecuteDateTime;
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// جست و جوی سانس ها با یک تاریخ
        ///// </summary>
        //public async Task<List<Schedule>> SearchScheduleByOneDate(DateTime firstDate)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.ExecuteDateTime.Year == firstDate.Year && x.ExecuteDateTime.Month == firstDate.Month &&
        //        x.ExecuteDateTime.Day == firstDate.Day && x.IsExist == true)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// جست و جوی سانس ها با دو تاریخ
        ///// </summary>
        //public async Task<List<Schedule>> SearchScheduleByTwoDate(DateTime firstDate, DateTime secondDate) //with problem
        //{
        //    return await _context.Schedules
        //        .FromSql("Select * from dbo.Schedules as s where s.ExecuteDateTime between {0} and {1}", firstDate, secondDate)
        //        .Where(x => x.IsExist == true)
        //        .ToListAsync();
        //}

        //public async Task<Fun> GetFunByFunId(Guid id)
        //{
        //    return await _context.Funs
        //        .SingleOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<DateTime?> GetLastScheduleTimeByFunId(Guid id)
        //{
        //    var sans = await _context.Schedules.Where(x => x.FunId == id).ToListAsync();
        //    if (sans.Count == 0)
        //        return null;
        //    return sans.OrderByDescending(x => x.ExecuteDateTime).First().ExecuteDateTime;

        //}

        ///// <summary>
        ///// دریافت همه سانس های فعال تاریخ گذشته
        ///// </summary>
        //public async Task<List<Schedule>> GetAllExpiredActiveSchedules()
        //{
        //    return await _context.Schedules
        //        .Where(x => x.ExecuteDateTime < DateTime.Now && x.IsExist == true)
        //        .ToListAsync();
        //}

        /// <summary>
        /// دریافت سانس فعال با آیدی
        /// </summary>
        public async Task<Schedule> GetActiveScheduleByIdAsync(Guid id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(x => x.Id == id && x.IsExist == true);
        }

        ///// <summary>
        ///// گرفتن همه سانس ها برای تفریح
        ///// </summary>
        //public async Task<List<Schedule>> GetAllSchedulesForFunWithFunType(Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.Id == id && x.IsExist == true)
        //        .OrderBy(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        //public async Task<List<Schedule>> GetAllSchedulesForFunWithId(Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.FunId == id && x.IsExist == true)
        //        .OrderBy(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// جستجوی سانس با تفریح و تاریخ
        ///// </summary>
        //public async Task<List<Schedule>> SearchSchedulesByTimeAndFun(DateTime excuteMiladiDate, Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.ExecuteDateTime.Year == excuteMiladiDate.Year && x.ExecuteDateTime.Month == excuteMiladiDate.Month &&
        //        x.ExecuteDateTime.Day == excuteMiladiDate.Day && x.FunId == id && x.IsExist == true)//
        //        .OrderByDescending(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// ذخیره اعمال انجام شده
        ///// </summary>
        //public async Task<bool> UpdateScheduleAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت سانس با آیدی
        ///// </summary>
        //public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        //{
        //    return await _context.Schedules
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        ///// <summary>
        ///// گرفتن تاریخ اخرین سانس
        ///// </summary>
        //public async Task<DateTime?> GetLastScheduleTimeByFunType(FunType funType) // momeni
        //{
        //    var sans = await _context.Schedules.Where(s => s.FunType == funType)
        //        .OrderByDescending(x => x.ExecuteDateTime).ToListAsync();

        //    if (sans.Count > 0)
        //    {
        //        return sans.OrderByDescending(s => s.ExecuteDateTime).First().ExecuteDateTime;
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// جست و جوی سانس ها با یک تاریخ
        ///// </summary>
        //public async Task<List<Schedule>> SearchScheduleByOneDate(DateTime firstDate)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.ExecuteDateTime.Year == firstDate.Year && x.ExecuteDateTime.Month == firstDate.Month &&
        //        x.ExecuteDateTime.Day == firstDate.Day && x.IsExist == true)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// جست و جوی سانس ها با دو تاریخ
        ///// </summary>
        //public async Task<List<Schedule>> SearchScheduleByTwoDate(DateTime firstDate, DateTime secondDate) //with problem
        //{
        //    return await _context.Schedules
        //        .FromSql("Select * from dbo.Schedules as s where s.ExecuteDateTime between {0} and {1}", firstDate, secondDate)
        //        .Where(x => x.IsExist == true)
        //        .ToListAsync();
        //}

        //public async Task<Fun> GetFunByFunId(Guid id)
        //{
        //    return await _context.Funs
        //        .SingleOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<DateTime?> GetLastScheduleTimeByFunId(Guid id)
        //{
        //    var sans = await _context.Schedules.Where(x => x.FunId == id).ToListAsync();
        //    if (sans.Count == 0)
        //        return null;
        //    return sans.OrderByDescending(x => x.ExecuteDateTime).First().ExecuteDateTime;

        //}

        ///// <summary>
        ///// دریافت همه سانس های فعال تاریخ گذشته
        ///// </summary>
        //public async Task<List<Schedule>> GetAllExpiredActiveSchedules()
        //{
        //    return await _context.Schedules
        //        .Where(x => x.ExecuteDateTime < DateTime.Now && x.IsExist == true)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت سانس فعال با آیدی
        ///// </summary>
        //public async Task<Schedule> GetActiveScheduleByIdAsync(Guid id)
        //{
        //    return await _context.Schedules
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsExist == true);
        //}


    }
}
