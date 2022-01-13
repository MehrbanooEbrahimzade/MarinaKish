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
    public class FunRepository : GenericRepository<Fun>, IFunRepository
    {

        public FunRepository(DatabaseContext context, ILogger logger) : base(context, logger)
        {
        }

        /// <summary>
        /// چک کننده وجود داشتن تفریح
        /// </summary>
        public async Task<bool> CheckFunTypeIsExistAsync(Guid id)
        {
            try
            {
                var fun = await FunIncludes().AnyAsync(x => x.Id == id && x.IsActive);
                return fun == false ? throw new NullReferenceException(" تفریح یافت نشد") : true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Check Fun TypeIs Exist Error", typeof(FunRepository));
                return false;
            }
        }

        /// <summary>
        /// اضافه کردن تفریح
        /// </summary>
        public override async Task<bool> AddAsync(Fun fun)
        {
            try
            {
                await dbSet.AddAsync(fun);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Add Method Error", typeof(FunRepository));
                return false;
            }
        }

        /// <summary>
        /// دریافت تفریح با آیدی
        /// </summary>
        public override async Task<Fun> GetByIdAsync(Guid id)
        {
            try
            {
                var fun = await FunIncludes().FirstOrDefaultAsync(x => x.Id == id);
                if (fun is null)
                {
                    throw new NullReferenceException("تفریح یافت نشد");
                }
                return fun;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} GetById Method Error", typeof(FunRepository));
                return null;
            }
        }

        /// <summary>
        /// خذف اسلایدر های فان
        /// </summary>
        public async Task DeleteSliderPicturesByFunAsync(Fun fun)
        {
            try
            {
                _context.FunSliderPictures.RemoveRange(fun.SliderPictures);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Delete Slider Picture By Fun Method Error", typeof(FunRepository));
            }
        }


        /// <summary>
        /// حذف تفریح 
        /// </summary>
        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var fun = await FunIncludes().SingleOrDefaultAsync(x => x.Id == id);
                if (fun is null)
                {
                    throw new NullReferenceException("تفریح یافت نشد");
                }

                dbSet.Remove(fun);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete Method Error", typeof(FunRepository));
                return false;
            }
        }

        /// <summary>
        /// دریافت همه تفریح ها
        /// </summary>
        public override async Task<List<Fun>> AllAsync()
        {
            try
            {
                return await FunIncludes().ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All Method Error", typeof(FunRepository));
                return new List<Fun>();
            }
        }

        /// <summary>
        /// گرفتن تفریح بااسم تفریح
        /// </summary>
        public async Task<Fun> GetFunsByFunNameAsync(string name)
        {
            try
            {
                var fun = await FunIncludes().SingleOrDefaultAsync(f => f.Name == name);
                return fun ?? throw new NullReferenceException("تفریح یافت نشد");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Get Fun By Name Method Error", typeof(FunRepository));
                return null;
            }
        }


        /// <summary>
        /// دریافت همه تفریح های فعال
        /// </summary>
        public async Task<List<Fun>> GetAllActiveFunAsync()
        {
            try
            {
                return await FunIncludes()
                    .Where(x => x.IsActive == true)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Get All Active Fun Method Error", typeof(FunRepository));
                return new List<Fun>();
            }
        }

        /// <summary>
        /// دریافت همه تفریح های غیر فعال
        /// </summary>
        public async Task<List<Fun>> GetAllDisActiveFunAsync()
        {
            try
            {
                return await FunIncludes()
                    .Where(x => x.IsActive == false)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Get All DisActive Fun Method Error", typeof(FunRepository));
                return new List<Fun>();
            }
        }


        /// <summary>
        /// گرفتن تفریح فعال باایدی 
        /// </summary>
        public async Task<Fun> GetActiveFunByIdAsynch(Guid id)
        {
            try
            {
                var fun = await dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
                return fun ?? throw new NullReferenceException("تفریح یافت نشد");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Get Active Fun By Id Method Error", typeof(FunRepository));
                return null;
            }
        }

        /// <summary>
        /// غیرفعال کردن یک فان
        /// </summary>
        public async Task<bool> InactivateFun(Guid fileId)
        {
            var fun = await _context.Funs
                .SingleOrDefaultAsync(x => x.Id == fileId && x.IsActive == true);

            if (fun == null)
                 throw new NullReferenceException("تفریح مورد نظر یافت نشد!");

            fun.SetIsActive(false);
            return true;
        }


        ///// <summary>
        ///// دریافت فایل با آیدی
        ///// </summary>
        //public async Task<MyFile> GetFileById(Guid fileid)
        //{
        //    return await _context.Files
        //        .SingleOrDefaultAsync(x => x.Id == fileid && x.IsActive == true);
        //}

        /// <summary>
        /// گرفتن تفریح غیر فعال باایدی 
        /// </summary>
        public async Task<Fun> GetDisActiveFunByIdAsynch(Guid id)
        {
            try
            {
                var fun = await FunIncludes().FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
                return fun ?? throw new NullReferenceException("تفریح یافت نشد");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Get DisActive Fun By Id Method Error", typeof(FunRepository));
                return null;
            }
        }

        /// <summary>
        ///  دریافت تفریح فعال با اسم
        /// <summary>
        public async Task<Fun> GetActiveFunWithFunNameAsync(string name)
        {
            try
            {
                var fun = FunIncludes().Where(x => x.Name == name && x.IsActive);
                return (Fun)fun;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{ Repo} Get Active Fun By Name Method Error", typeof(FunRepository));
                return null;
            }
        }

        public async Task<List<Fun>> GetAllFunActiveSchedulesById(Guid funId)
        {
            try
            {
                return await dbSet.Where
                        (x => x.Id == funId && x.IsActive == true && x.ScheduleInfo.StartTime >= DateTime.Now.TimeOfDay)
                    .OrderByDescending(x => x.ScheduleInfo.StartTime.Days)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError
                    (e, "{ Repo} Get All Active Fun Schedule By Id Method Error", typeof(FunRepository));
                return new List<Fun>();
            }
        }

        /// <summary>
        /// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        /// </summary>
        public async Task<List<Fun>> GetAllFunDisActiveSchedulesById(Guid funId)
        {
            try
            {
                return await dbSet
                    .Where(x => x.Id == funId && x.IsActive == false && x.ScheduleInfo.StartTime >= DateTime.Now.TimeOfDay)
                    .OrderByDescending(x => x.ScheduleInfo.StartTime)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError
                    (e, "{ Repo} Get All DisActive Fun Schedule By Id Method Error", typeof(FunRepository));
                throw;
            }

        }
        ///// <summary>
        ///// گرفتن تفریح ها با نوع تفریح
        ///// </summary>
        //public async Task<List<Fun>> GetFunsWithFunType(string name)
        //{
        //    return await _context.Funs
        //        .Where(x => x.Name == name && x.IsActive)
        //        .ToListAsync();
        //}
        ///// <summary>
        ///// گرفتن تفریح فعال باایدی 
        ///// </summary>
        //public async Task<Fun> GetActiveFunById(Guid id)
        //{
        //    return await _context.Funs
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        //}
        ///// <summary>
        ///// گرفتن تفریح غیر فعال باایدی 
        ///// </summary>

        //public async Task<Fun> GetDisActiveFunById(Guid id)
        //{
        //    return await _context.Funs
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == false);
        //}


        public IQueryable<Fun> FunIncludes()
        {
            return dbSet
                .Include(f => f.ScheduleInfo)
                .Include(s => s.SliderPictures);
        }
    }
}
