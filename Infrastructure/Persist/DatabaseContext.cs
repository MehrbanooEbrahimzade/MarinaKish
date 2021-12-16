using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>(x => x.HasOne(e => e.UserCart))
                .Entity<User>(x=>x.HasOne(z=>z.Item))
                .Entity<CartItem>(x => x.HasMany(z => z.Items))
                .Entity<TicketItem>(x => x.HasOne(z => z.Ticket))
                .Entity<Fun>(x=>x.HasMany(z=>z.Schedules))
                .Entity<Fun>(x => x.HasMany(z => z.Comments))
                .Entity<Schedule>(x => x.HasMany(z => z.Items));


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Fun> Funs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
