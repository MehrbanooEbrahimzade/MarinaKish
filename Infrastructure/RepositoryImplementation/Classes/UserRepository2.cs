using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryImplementation.Classes
{
    public class UserRepository2: IUserRepository2
    {
        private readonly DatabaseContext _context;
        public UserRepository2(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.PhoneNumber == phone);
        }

        /// <summary>
        ///  حذف کاربر با آی دی:
        /// </summary>
        public void DeleteUser(User user)

        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
