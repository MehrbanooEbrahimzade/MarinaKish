using System;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Classes
{
    public class FileRepository : IFileRepository
    {
        private readonly DatabaseContext _context;
        public FileRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task UploadFileAsync(MyFile pic)
        {
              await _context.MyFiles.AddAsync(pic);
        }

        public async Task<MyFile> GetFileByIdAsync(Guid id)
        {
            return await _context.MyFiles.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteFileAsync(MyFile pic)
        {
            _context.MyFiles.Remove(pic);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
