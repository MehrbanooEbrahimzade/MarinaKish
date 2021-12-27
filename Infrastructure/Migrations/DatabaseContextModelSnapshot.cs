﻿// <auto-generated />
using System;
using Infrastructure.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisLike");

                    b.Property<Guid>("FunId");

                    b.Property<int>("Like");

                    b.Property<int>("Status");

                    b.Property<DateTime>("SubmitDate");

                    b.Property<string>("Text");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("FunId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Models.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardNumber");

                    b.Property<string>("ShabaNumber");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Domain.Models.Fun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("BackgroundPicture");

                    b.Property<string>("Icon");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("Video");

                    b.HasKey("Id");

                    b.ToTable("Funs");
                });

            modelBuilder.Entity("Domain.Models.FunSliderPicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attachment");

                    b.Property<Guid?>("FunId");

                    b.Property<Guid?>("FunId1");

                    b.HasKey("Id");

                    b.HasIndex("FunId");

                    b.HasIndex("FunId1");

                    b.ToTable("FunSliderPictures");
                });

            modelBuilder.Entity("Domain.Models.MyFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilePath");

                    b.Property<string>("Name");

                    b.Property<long>("Size");

                    b.HasKey("Id");

                    b.ToTable("MyFiles");
                });

            modelBuilder.Entity("Domain.Models.Percent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Percent");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("DiscountId");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<Guid>("FunId");

                    b.Property<bool>("IsExist");

                    b.Property<decimal>("Price");

                    b.Property<TimeSpan>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Models.ScheduleInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("Duration");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<Guid>("FunId");

                    b.Property<int>("GapTime");

                    b.Property<int>("OnlineCapacity");

                    b.Property<int>("PresenceCapacity");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<int>("TotalCapacity");

                    b.HasKey("Id");

                    b.HasIndex("FunId")
                        .IsUnique();

                    b.ToTable("ScheduleInfos");
                });

            modelBuilder.Entity("Domain.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Condition");

                    b.Property<string>("FunType");

                    b.Property<int>("Gender");

                    b.Property<Guid?>("ScheduleId");

                    b.Property<Guid?>("ScheduleId1");

                    b.Property<DateTime>("SubmitDate");

                    b.Property<string>("UserId");

                    b.Property<string>("UserId1");

                    b.Property<int>("WhereBuy");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ScheduleId1");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<Guid?>("CreditCardId");

                    b.Property<Guid?>("CreditCardId1");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NationalCode");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("RoleType");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("CreditCardId1");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.HasOne("Domain.Models.Fun")
                        .WithMany()
                        .HasForeignKey("FunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.FunSliderPicture", b =>
                {
                    b.HasOne("Domain.Models.Fun")
                        .WithMany("SliderPictures")
                        .HasForeignKey("FunId");

                    b.HasOne("Domain.Models.Fun")
                        .WithMany()
                        .HasForeignKey("FunId1");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.HasOne("Domain.Models.Percent", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId");
                });

            modelBuilder.Entity("Domain.Models.ScheduleInfo", b =>
                {
                    b.HasOne("Domain.Models.Fun")
                        .WithOne("ScheduleInfo")
                        .HasForeignKey("Domain.Models.ScheduleInfo", "FunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Models.Ticket", b =>
                {
                    b.HasOne("Domain.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");

                    b.HasOne("Domain.Models.Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId1");

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId");

                    b.HasOne("Domain.Models.CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
