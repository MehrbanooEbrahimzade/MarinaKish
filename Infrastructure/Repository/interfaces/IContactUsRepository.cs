using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.interfaces
{
    public interface IContactUsRepository
    {
        /// <summary>
        /// اضافه کردن اطلاعات  
        /// </summary>
        void AddInformationAsynch(ContactUs contactUs);

    }
}
