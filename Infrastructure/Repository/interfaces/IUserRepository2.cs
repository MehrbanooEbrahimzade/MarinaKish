using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.interfaces
{
    public interface IUserRepository2
    {

        /// <summary>
        /// گرفتن کاربر با شماره تلفن :
        /// </summary>
        Task<User> GetUserByPhone(string phone);
    }
}
