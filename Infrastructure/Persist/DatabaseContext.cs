using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persist
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>(x => x.HasOne<User>())
                .Entity<User>(x => x.HasMany<TicketItem>())
                .Entity<TicketItem>(x => x.HasOne(z => z.Ticket))
                .Entity<Fun>(x=>x.HasMany<Schedule>())
                .Entity<Fun>(x => x.HasMany<Comment>())
                .Entity<Schedule>(x => x.HasOne<ScheduleInformation>())
                .Entity<ScheduleInformation>(x => x.HasMany<Schedule>());


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Fun> Funs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
