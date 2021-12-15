using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>(s =>
            {
                s.HasOne<User>()
                    .WithMany(x => x.Tickets).HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<User>(x => x.HasOne(e => e.UserCart));


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Fun> Funs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
