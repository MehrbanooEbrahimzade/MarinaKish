using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Persist;
using Infrastructure.Repository.interfaces;
using Domain.Models;


namespace Infrastructure.Repository.classes
{
    public class ContactUsRepository : BaseRepository, IContactUsRepository
    {
        protected ContactUsRepository(DatabaseContext context) : base(context)
        {
        }

        public async void AddInformationAsynch(Domain.Models.ContactUs contactUs)
        {
            await _context.AddAsync(contactUs);
            _context.SaveChanges();
        }
    }
}
