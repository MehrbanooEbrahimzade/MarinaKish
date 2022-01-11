using System.Threading.Tasks;
using Domain.Models;

namespace Domain.RepasitoryInterfaces
{
    public interface IContactUsRepository : IGenericRepository<ContactUs>
    {

        /// <summary>
        ///  ویرایش اطلاعات
        /// </summary>
        Task<bool> UpdateContactUsAsync();
    }
}
