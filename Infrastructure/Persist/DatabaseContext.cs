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


        public DbSet<Fun> Funs { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<ScheduleInfo> ScheduleInfos { get; set; }
        public DbSet<FunSliderPicture> FunSliderPictures { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
       
        public DbSet<MyFile> MyFiles { get; set; }

 
    }
}
