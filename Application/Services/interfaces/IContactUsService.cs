using Application.Commands.ContactUs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.interfaces
{
    public interface IContactUsService
    {
        /// <summary>
        /// اضافه کردن اطلاعات
        /// </summary>
        Task AddInformationAsynch(AddContactUsCommand command);
    }
}
