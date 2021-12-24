using System;
﻿using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
                .Entity<User>(x => x.HasOne<CreditCard>())
                .Entity<User>(x => x.HasMany<Ticket>())
                .Entity<Fun>(x => x.HasOne<ScheduleInfo>())
                .Entity<Fun>(x => x.HasMany<Comment>())
                .Entity<Schedule>(x => x.HasMany<Ticket>());

            modelBuilder.Entity<User>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<MyFile>().Property<bool>("IsDeleted");
            modelBuilder.Entity<CashTransfer>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Comment>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Conversation>().Property<bool>("IsDeleted");
            modelBuilder.Entity<CreditCard>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Fun>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Message>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Schedule>().Property<bool>("IsDeleted");
            modelBuilder.Entity<ScheduleInfo>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Ticket>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Writ>().Property<bool>("IsDeleted");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Fun> Funs { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<ScheduleInfo> ScheduleInfos { get; set; }
        public DbSet<FunSliderPicture> FunSliderPictures { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
       
        public DbSet<MyFile> MyFiles { get; set; }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }


    }
}
