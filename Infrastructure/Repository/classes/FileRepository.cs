using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Infrastructure.Repository.classes
{
    public class FileRepository : BaseRepository, IFileRepository
    {

        //        /// <summary>
        //        /// گرفتن عکس غیرفعال با آیدی
        //        /// </summary>
        //        public async Task<File> getNotActiveFileById(Guid id)
        //        {
        //            return await _context.Files
        //                .FirstOrDefaultAsync(x => x.Id == id);
        //        }

        //        /// <summary>
        //        /// ذخیره اعمال انجام شده
        //        /// </summary>
        //        public async Task<bool> UpdateFileAsync()
        //        {
        //            return await _context.SaveChangesAsync() > 0;
        //        }
    }
}
