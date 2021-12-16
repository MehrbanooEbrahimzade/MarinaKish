using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository;

namespace Infrastructure.Repository.interfaces
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
    }
}
