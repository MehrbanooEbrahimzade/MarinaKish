using System.Threading.Tasks;
using System;
using System.IO;
using Domain.Models;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.interfaces;

namespace Infrastructure.Repository.classes
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(DatabaseContext context) : base(context)
        {
            
        }

        /// <summary>
        /// گرفتن عکس غیرفعال با آیدی
        /// </summary>
        public async Task<MyFile> getNotActiveFileById(Guid id)
        {
            return await _context.Files
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UploadFileAsync(MyFile pic)
        {
              await _context.Files.AddAsync(pic);
        }

        public async Task<MyFile> GetFileById(Guid id)
        {
            return await _context.Files.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task DownloadFile(FileStream stream, MemoryStream memory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFileAsync(MyFile pic)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
