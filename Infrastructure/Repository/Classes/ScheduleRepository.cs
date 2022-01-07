using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Classes
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {

        }
        #region

        /// <summary>
        /// اضافه کردن سانس به تیبل
        /// </summary>
        public override async Task<bool> AddAsync(Schedule schedule)
        {
            try
            {
                await dbSet.AddAsync(schedule);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Add method eror", typeof(ScheduleRepository));
                return false;
            }

        }

        /// <summary>
        /// دریافت سانس با آی دیه  سانس
        /// </summary>
        public override async Task<Schedule> GetByIdAsync(Guid id)
        {
            try
            {
                var Schedule = await dbSet.SingleOrDefaultAsync(x => x.Id == id);
                if (Schedule == null)
                    throw new Exception("سانسی با این ایدی یافت نشد");

                return Schedule;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Reop} GetById method error", typeof(ScheduleRepository));
                return null;
            }
        }

        public async override Task<IEnumerable<Schedule>> AllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All method error", typeof(ScheduleRepository));
                return null;
            }
        }

        public async override Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var Schedule = await GetByIdAsync(id);
                dbSet.Remove(Schedule);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete method error", typeof(ScheduleRepository));
                return false;
            }
        }

        #endregion
        /// <summary>
        /// اضافه کردن سانس ها به تیبل
        /// </summary>
        public void AddScheduleAsync(List<Schedule> schedules)
        {
            try
            {
                dbSet.AddRangeAsync(schedules);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} add schedules eror ", typeof(ScheduleRepository));
            }

        }

        public async Task<List<Schedule>> GetFunSchedulesByFunId(Guid FunId)
        {
            try
            {
                return await dbSet.Where(x => x.FunId == FunId).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} find schedule eror ", typeof(ScheduleRepository));
                return null;
            }
        }

        /// <summary>
        /// پاک کردن همه سانس های یک تفریح
        /// </summary>
        public async Task<bool> DeleteAllSchedulesOfaFun(Guid funId)
        {
            try
            {
                var FunSchedules = await GetFunSchedulesByFunId(funId);
                dbSet.RemoveRange(FunSchedules);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} add schedules eror ", typeof(ScheduleRepository));
                return false;
            }
        }



        /// <summary>
        /// دریافت سانس فعال با آیدی
        /// </summary>
        public async Task<Schedule> GetActiveScheduleByIdAsync(Guid id)
        {
            try
            {
                return await dbSet.SingleOrDefaultAsync(x => x.Id == id);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} get active schedule eror ", typeof(ScheduleRepository));
                return null;
            }
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