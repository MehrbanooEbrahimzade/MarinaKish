using Application.Commands.ContactUs;
using Application.Mappers;
using Application.Services.interfaces;
using Infrastructure.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.classes
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        /// <summary>
        /// اضافه کردن اطلاعات
        /// </summary>
        public async Task AddInformationAsynch(AddContactUsCommand command)
        {
            var contactUs = command.ToModel();
            _contactUsRepository.AddInformationAsynch(contactUs);
        }
    }
}
