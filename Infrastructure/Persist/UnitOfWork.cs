using Domain.IConfiguration;
using Domain.RepasitoryInterfaces;
using Infrastructure.Repository.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository.classes;

namespace Infrastructure.Persist
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public ITicketRepository Tickets { get; private set; }

        public IScheduleInfoRepository ScheduleInfos { get; private set; }

        public IScheduleRepository Schedules { get; private set; }

        public IFunRepository Funs { get; private set; }
        public IFileRepository FileS { get; }

        public IFileRepository Files { get; private set; }

        public IContactUsRepository ContactUs { get; private set; }

        public UnitOfWork(DatabaseContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
            Tickets = new TicketRepository(_context, _logger);
            ScheduleInfos = new ScheduleInfoRepository(_context, _logger);
            Schedules = new ScheduleRepository(_context, _logger);
            Funs = new FunRepository(_context, _logger);
            Files = new FileRepository(_context, _logger);
            ContactUs = new ContactUsRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
