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
        //public FunRepository(DatabaseContext context) : base(context)
        //{

        //}

        ///// <summary>
        ///// چک کننده وجود داشتن تفریح
        ///// </summary>
        //public async Task<bool> CheckFunTypeIsExist(string name)
        //{
        //    return await _context.Funs.AnyAsync(x => x.Name == name && x.IsActive == true);
        //}

        ///// <summary>
        ///// اضافه کردن تفریح
        ///// </summary>
        //public async Task<bool> AddFunAsync(Fun fun)
        //{
        //    await _context.Funs.AddAsync(fun);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت تفریح با آیدی
        ///// </summary>
        //public async Task<Fun> GetFunById(Guid id)
        //{
        //    return await _context.Funs
        //        .SingleOrDefaultAsync(x => x.Id == id);

        //}

        ///// <summary>
        ///// ذخیره عملیات انجام شده
        ///// </summary>
        //public async Task<bool> UpdateFunAsync()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// حذف تفریح 
        ///// </summary>
        //public async Task<bool> DeleteFunAsync(Guid id)
        //{
        //    var fun = _context.Funs.Where(x => x.Id == id);
        //    _context.Funs.Remove((Fun)fun);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        ///// <summary>
        ///// دریافت همه تفریح ها
        ///// </summary>
        //public async Task<List<Fun>> GetAllFunAsync()
        //{
        //    return await _context.Funs
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// گرفتن تفریح با نوع تفریح
        ///// </summary>
        //public async Task<Fun> GetFunByFunType(string name)
        //{
        //    return await _context.Funs
        //        .FirstOrDefaultAsync(x => x.Name == name);
        //}

        ///// <summary>
        ///// دریافت فایل با آیدی
        ///// </summary>
        //public async Task<File> GetFileById(Guid fileid)
        //{
        //    return await _context.Files
        //        .SingleOrDefaultAsync(x => x.Id == fileid && x.IsActive == true);
        //}

        ///// <summary>
        ///// دریافت همه تفریح های فعال
        ///// </summary>
        //public async Task<List<Fun>> GetAllActivedFun()
        //{
        //    return await _context.Funs
        //        .Where(x => x.IsActive == true)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه تفریح های غیر فعال
        ///// </summary>
        //public async Task<List<Fun>> GetAllDisActivedFun()
        //{
        //    return await _context.Funs
        //        .Where(x => x.IsActive == false)
        //        .ToListAsync();
        //}

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

        ///// <summary>
        ///// دریافت همه سانس های برگذار نشده فعال یک تفریح با آیدی
        ///// </summary>
        //public async Task<List<Schedule>> GetAllFunActiveSchedulesById(Guid funid)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.FunId == funid && x.IsExist == true && x.ExecuteDateTime >= DateTime.Now)
        //        .OrderByDescending(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// دریافت همه سانس های برگذار نشده غیرفعال یک تفریح با آیدی
        ///// </summary>
        //public async Task<List<Schedule>> GetAllFunDisActiveSchedulesById(Guid id)
        //{
        //    return await _context.Schedules
        //        .Where(x => x.FunId == id && x.IsExist == false && x.ExecuteDateTime >= DateTime.Now)
        //        .OrderByDescending(x => x.ExecuteDateTime)
        //        .ToListAsync();
        //}
    }
}
