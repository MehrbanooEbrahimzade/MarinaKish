using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Infrastructure.Repository.interfaces;

namespace Infrastructure.Repository.classes
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// اپلود کردن عکس
        /// </summary>
        public async Task<bool> UploadFileAsync(Files pic)
        {
            await _context.Files.AddAsync(pic);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// دریافت عکس با آی دی
        /// </summary>
        public async Task<Files> GetFileById(Guid id)
        {
            return await _context.Files
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// دانلود عکس
        /// </summary>
        public async Task DownloadFile(FileStream stream, MemoryStream memory)
        {
            await stream.CopyToAsync(memory);
        }

        /// <summary>
        /// گرفتن عکس با اسم عکس
        /// </summary>
        public async Task<Files> GetImageByName(string fileName)
        {
            return await _context.Files
                .FirstOrDefaultAsync(x => x.Name == fileName);
        }

        /// <summary>
        /// پاک کردن فایل
        /// </summary>
        public async Task<bool> DeleteFileAsync(Files pic)
        {
            _context.Files.Remove(pic);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// وجود داشتن کاربر
        /// </summary>
        public async Task<bool> AnyUser(Guid id)
        {
            return await _context.Users
                .AnyAsync(x => x.Id == id && x.IsActive == true);
        }

        /// <summary>
        /// وجود داشتن تفریح
        /// </summary>
        public async Task<bool> AnyFun(Guid id)
        {
            return await _context.Funs
                .AnyAsync(x => x.Id == id);
        }

        /// <summary>
        /// وجود داشتن سانس
        /// </summary>
        public async Task<bool> AnySchedule(Guid id)
        {
            return await _context.Schedules
                .AnyAsync(x => x.Id == id && x.IsExist == true);
        }

        /// <summary>
        /// دریافت کاربر
        /// </summary>
        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// دریافت تفریح
        /// </summary>
        public async Task<Fun> GetFunById(Guid id)
        {
            return await _context.Funs
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// دریافت سانس
        /// </summary>
        public async Task<Schedule> GetScheduleById(Guid id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(x => x.Id == id && x.IsExist == true);
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک تفریح 
        /// </summary>
        public async Task<List<Files>> GetAllPicForFun(string funid)
        {
            return await _context.Files
                .Where(x => x.FunID.Contains(funid) && x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک کاربر
        /// </summary>
        public async Task<List<Files>> GetAllPicForUser(string userid)
        {
            return await _context.Files
                .Where(x => x.UserID.Contains(userid) && x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن همه عکس ها برای یک سانس
        /// </summary>
        public async Task<List<Files>> GetAllPicForSchedule(string scheduleid)
        {
            return await _context.Files
                .Where(x => x.ScheduleID.Contains(scheduleid) && x.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// گرفتن عکس غیرفعال با آیدی
        /// </summary>
        public async Task<Files> getNotActiveFileById(Guid id)
        {
            return await _context.Files
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        public async Task<bool> UpdateFileAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
