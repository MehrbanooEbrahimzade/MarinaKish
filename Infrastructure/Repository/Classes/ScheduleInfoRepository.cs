using System;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Classes
{
    public class ScheduleInfoRepository : GenericRepository<ScheduleInfo>, IScheduleInfoRepository
    {

        public ScheduleInfoRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<bool> AddAsync(ScheduleInfo scheduleInfo)
        {
            try
            {

                await dbSet.AddAsync(scheduleInfo);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", typeof(ScheduleInfoRepository));
                return false;
            }

        }

        public override async Task<ScheduleInfo> GetByIdAsync(Guid id)
        {
            try
            {
                var scheduleInfo = await dbSet.SingleOrDefaultAsync(x => x.Id == id);
                if (scheduleInfo == null)
                    throw new NullReferenceException("چنین سانسی شناسایی نشد!");
                return scheduleInfo;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", typeof(ScheduleInfoRepository));
                return null;
            }
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var scheduleInfo = await dbSet.SingleOrDefaultAsync(x => x.Id == id);

                if (scheduleInfo != null)
                {
                    dbSet.Remove(scheduleInfo);
                    return true;
                }
                 
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error",typeof(ScheduleInfoRepository));
                return false;
            }

        }
        ///// <summary>
        ///// چک کننده وجود داشتن تفریح
        ///// </summary>
        //public async Task<bool> CheckScheduleInfoTypeIsExistAsynch(Guid id)
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo().AnyAsync(x => x.Id == id && x.IsActive == true);
        //}

        ///// <summary>
        ///// اضافه کردن تفریح
        ///// </summary>
        //public async Task<bool> AddScheduleInfoAsync(ScheduleInfo ScheduleInfo)
        //{
        //    await _context.ScheduleInfos.AddAsync(ScheduleInfo);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت تفریح با آیدی
        ///// </summary>
        //public async Task<ScheduleInfo> GetScheduleInfoByIdAsynch(Guid id)
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo().FirstOrDefaultAsync(x => x.Id == id);
        //}

        ///// <summary>
        ///// ذخیره عملیات انجام شده
        ///// </summary>
        //public async Task<bool> UpdateScheduleInfoAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// حذف تفریح 
        ///// </summary>
        //public async Task<bool> DeleteScheduleInfoAsync(Guid id)
        //{
        //    var ScheduleInfo = IncludeScheduleInfoWithScheduleInfo().Where(f => f.Id == id);
        //    _context.ScheduleInfos.Remove((ScheduleInfo) ScheduleInfo);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت همه تفریح ها
        ///// </summary>
        //public async Task<List<ScheduleInfo>> GetAllScheduleInfoAsync()
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo()
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// گرفتن تفریح بااسم تفریح
        ///// </summary>
        //public async Task<ScheduleInfo> GetScheduleInfoByScheduleInfoNameAsynch(string name)
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo()
        //        .FirstOrDefaultAsync(f => f.Name == name);
        //}


        ///// <summary>
        ///// دریافت همه تفریح های فعال
        ///// </summary>
        //public async Task<List<ScheduleInfo>> GetAllActivedScheduleInfoAsynh()
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo()
        //        .Where(x => x.IsActive == true)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه تفریح های غیر فعال
        ///// </summary>
        //public async Task<List<ScheduleInfo>> GetAllDisActivedScheduleInfoAsynch()
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo()
        //        .Where(x => x.IsActive == false)
        //        .ToListAsync();
        //}


        ///// <summary>
        ///// گرفتن تفریح فعال باایدی 
        ///// </summary>
        //public async Task<ScheduleInfo> GetActiveScheduleInfoByIdAsynch(Guid id)
        //{
        //    return await _context.ScheduleInfos
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        //}
        /////// <summary>
        /////// دریافت فایل با آیدی
        /////// </summary>
        ////public async Task<MyFile> GetFileById(Guid fileid)
        ////{
        ////    return await _context.Files
        ////        .SingleOrDefaultAsync(x => x.Id == fileid && x.IsActive == true);
        ////}

        ///// <summary>
        ///// گرفتن تفریح غیر فعال باایدی 
        ///// </summary>
        //public async Task<ScheduleInfo> GetDisActiveScheduleInfoByIdAsynch(Guid id)
        //{
        //    return await IncludeScheduleInfoWithScheduleInfo()
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
        //}

        ///// <summary>
        /////  دریافت تفریح فعال با اسم
        ///// <summary>
        //public async Task<ScheduleInfo> GetActiveScheduleInfoWithScheduleInfoNameAsynch(string name)
        //{
        //    var ScheduleInfo = IncludeScheduleInfoWithScheduleInfo().Where(x => x.Name == name && x.IsActive);
        //    return (ScheduleInfo) ScheduleInfo;
        //}

        //public async Task<List<ScheduleInfo>> GetAllScheduleInfoActiveSchedulesById(Guid ScheduleInfoId)
        //{
        //    return await _context.ScheduleInfos.Where(x =>
        //            x.Id == ScheduleInfoId && x.IsActive == true && x.ScheduleInfo.StartTime >= DateTime.Now.TimeOfDay)
        //        .OrderByDescending(x => x.ScheduleInfo.StartTime.Days)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        ///// </summary>
        //public async Task<List<ScheduleInfo>> GetAllScheduleInfoDisActiveSchedulesById(Guid ScheduleInfoId)
        //{
        //    return await _context.ScheduleInfos
        //        .Where(x => x.Id == ScheduleInfoId && x.IsActive == false &&
        //                    x.ScheduleInfo.StartTime >= DateTime.Now.TimeOfDay)
        //        .OrderByDescending(x => x.ScheduleInfo.StartTime)
        //        .ToListAsync();
        //}
        /////// <summary>
        /////// گرفتن تفریح ها با نوع تفریح
        /////// </summary>
        ////public async Task<List<ScheduleInfo>> GetScheduleInfosWithScheduleInfoType(string name)
        ////{
        ////    return await _context.ScheduleInfos
        ////        .Where(x => x.Name == name && x.IsActive)
        ////        .ToListAsync();
        ////}
        /////// <summary>
        /////// گرفتن تفریح فعال باایدی 
        /////// </summary>
        ////public async Task<ScheduleInfo> GetActiveScheduleInfoById(Guid id)
        ////{
        ////    return await _context.ScheduleInfos
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        //}
        ///// <summary>
        ///// گرفتن تفریح غیر فعال باایدی 
        ///// </summary>

        //public async Task<ScheduleInfo> GetDisActiveScheduleInfoById(Guid id)
        //{
        //    return await _context.ScheduleInfos
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
        //}


        //public IQueryable<ScheduleInfo> IncludeScheduleInfoWithScheduleInfo()
        //{
        //    var ScheduleInfoWithScheduleInfo = _context.ScheduleInfos.Include(f => f.ScheduleInfo);
        //    return ScheduleInfoWithScheduleInfo;
        //}
    }

}