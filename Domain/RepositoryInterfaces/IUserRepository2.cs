using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository2
    {

        /// <summary>
        /// گرفتن کاربر با شماره تلفن :
        /// </summary>
        Task<User> GetUserByPhone(string phone);


        /// <summary>
        ///  حذف کاربر با آی دی:
        /// </summary>
        void DeleteUser(User user);


    }
}
