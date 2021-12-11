using Microsoft.EntityFrameworkCore;
using Marina_Club.Models;

namespace Marina_Club.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Fun> Funs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<CashTransfer> MarineCoinTransfers { get; set; }
    }
}
