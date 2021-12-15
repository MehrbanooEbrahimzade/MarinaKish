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
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        public ScheduleRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// دریافت تفریح با اسم تفریح
        /// </summary>
        public async Task<Fun> GetFunByFunType(FunType fun)
        {
            return await _context.Funs.FirstOrDefaultAsync(x => x.FunType == fun);
        }

        /// <summary>
        /// اضافه کردن سانس به تیبل
        /// </summary>
        public async Task<bool> AddScheduleAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// گرفتن همه سانس ها برای تفریح
        /// </summary>
        public async Task<List<Schedule>> GetAllSchedulesForFunWithFunType(FunType fun)
        {
            return await _context.Schedules
                .Where(x => x.FunType == fun && x.IsExist == true)
                .OrderBy(x => x.ExecuteDateTime)
                .ToListAsync();
        }

        public async Task<List<Schedule>> GetAllSchedulesForFunWithId(Guid id)
        {
            return await _context.Schedules
                .Where(x => x.FunId == id && x.IsExist == true)
                .OrderBy(x => x.ExecuteDateTime)
                .ToListAsync();
        }

        /// <summary>
        /// جستجوی سانس با تفریح و تاریخ
        /// </summary>
        public async Task<List<Schedule>> SearchSchedulesByTimeAndFun(DateTime excuteMiladiDate, Guid id)
        {
            return await _context.Schedules
                .Where(x => x.ExecuteDateTime.Year == excuteMiladiDate.Year && x.ExecuteDateTime.Month == excuteMiladiDate.Month &&
                x.ExecuteDateTime.Day == excuteMiladiDate.Day && x.FunId == id && x.IsExist == true)//
                .OrderByDescending(x => x.ExecuteDateTime)
                .ToListAsync();
        }

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        public async Task<bool> UpdateScheduleAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت سانس با آیدی
        /// </summary>
        public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// گرفتن تاریخ اخرین سانس
        /// </summary>
        public async Task<DateTime?> GetLastScheduleTimeByFunType(FunType funType) // momeni
        {
            var sans = await _context.Schedules.Where(s => s.FunType == funType)
                .OrderByDescending(x => x.ExecuteDateTime).ToListAsync();

            if (sans.Count > 0)
            {
                return sans.OrderByDescending(s => s.ExecuteDateTime).First().ExecuteDateTime;
            }

            return null;
        }

        /// <summary>
        /// جست و جوی سانس ها با یک تاریخ
        /// </summary>
        public async Task<List<Schedule>> SearchScheduleByOneDate(DateTime firstDate)
        {
            return await _context.Schedules
                .Where(x => x.ExecuteDateTime.Year == firstDate.Year && x.ExecuteDateTime.Month == firstDate.Month &&
                x.ExecuteDateTime.Day == firstDate.Day && x.IsExist == true)
                .ToListAsync();
        }

        /// <summary>
        /// جست و جوی سانس ها با دو تاریخ
        /// </summary>
        public async Task<List<Schedule>> SearchScheduleByTwoDate(DateTime firstDate, DateTime secondDate) //with problem
        {
            return await _context.Schedules
                .FromSql("Select * from dbo.Schedules as s where s.ExecuteDateTime between {0} and {1}", firstDate, secondDate)
                .Where(x => x.IsExist == true)
                .ToListAsync();
        }

        public async Task<Fun> GetFunByFunId(Guid id)
        {
            return await _context.Funs
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DateTime?> GetLastScheduleTimeByFunId(Guid id)
        {
            var sans = await _context.Schedules.Where(x => x.FunId == id).ToListAsync();
            if (sans.Count == 0)
                return null;
            return sans.OrderByDescending(x => x.ExecuteDateTime).First().ExecuteDateTime;

        }

        /// <summary>
        /// دریافت همه سانس های فعال تاریخ گذشته
        /// </summary>
        public async Task<List<Schedule>> GetAllExpiredActiveSchedules()
        {
            return await _context.Schedules
                .Where(x => x.ExecuteDateTime < DateTime.Now && x.IsExist == true)
                .ToListAsync();
        }

        /// <summary>
        /// دریافت سانس فعال با آیدی
        /// </summary>
        public async Task<Schedule> GetActiveScheduleByIdAsync(Guid id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(x => x.Id == id && x.IsExist == true);
        }
    }
}
