using System.Threading.Tasks;
using Domain.Models;
using Domain.RepasitoryInterfaces;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Classes
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

    }
}
