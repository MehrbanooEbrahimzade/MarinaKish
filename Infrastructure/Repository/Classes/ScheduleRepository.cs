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
                var Schedule = dbSet.SingleOrDefaultAsync(x => x.Id == id);
                if (Schedule.Result == null)
                    throw new Exception("سانسی با این ایدی یافت نشد");

                return Schedule.Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Reop} GetById method error", typeof(ScheduleRepository));
                return null;
            }
        }

        public async override Task<List<Schedule>> AllAsync()
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
                var Schedule = await dbSet.SingleOrDefaultAsync(x => x.Id == id);
                dbSet.Remove(Schedule);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete method error", typeof(ScheduleRepository));
                return false;
            }
        }


        /// <summary>
        /// دریافت تمام سانس های یک تفریح
        /// </summary>
        public  async Task<List<Schedule>> GetSchedulesForFunAsync(Guid id)
        {
            try
            {
                var getall = await dbSet.Where(w => w.FunId == id).ToListAsync();
                if (getall.Count == 0)
                    throw new Exception("چنین سانس هایی یافت نشد");

                return getall;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} GetAll method error", typeof(ScheduleRepository));
                return null;
            }
        }



        #endregion

        /// <summary> 
        /// اضافه کردن سانس ها به تیبل
        /// </summary>
        public async Task AddScheduleAsync(List<Schedule> schedules)
        {
            try
            {
                await dbSet.AddRangeAsync(schedules);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} add schedules error ", typeof(ScheduleRepository));
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
                _logger.LogError(e, "{Repo} find schedule error ", typeof(ScheduleRepository));
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
                _logger.LogError(e, "{Repo} add schedules error ", typeof(ScheduleRepository));
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
                _logger.LogError(e, "{Repo} get active schedule error ", typeof(ScheduleRepository));
                return null;
            }
        }


        /// <summary>
        /// غیر فعال کردن سانس های یک فان
        /// </summary>
        public async Task<bool> InactivateSchedulesAsync(Guid funId)
        {
            try
            {

                var result = dbSet.Where(x => x.FunId == funId);

                foreach (var item in result)
                {
                    item.SetIsExit(false);
                }

                return true;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Inactivate schedules for a fun error ", typeof(ScheduleRepository));
                return false;
            }
        }


        /// <summary>
        /// دریافت تمام سانس های تفریح با تاریخ 
        /// </summary>
        public async Task<List<Schedule>> GetAllByDateAsync(Guid id, DateTime dateTime)
        {
            try
            {

                var dateTime1 = dateTime.AddDays(7);

                //var getall = dbSet.FromSql($"select * from Schedules where FunId={id} and Date between {dateTime} and {dateTime1}").ToListAsync();
                var getall =await dbSet.Where(w => w.FunId == id && w.Date >= dateTime && w.Date<=dateTime1).ToListAsync();

                if (getall.Count == 0)
                    throw new Exception("چنین سانس هایی وجود ندارد");

                return getall;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Get All schedule error  ", typeof(ScheduleRepository));
                return null;
            }

        }
    }
}