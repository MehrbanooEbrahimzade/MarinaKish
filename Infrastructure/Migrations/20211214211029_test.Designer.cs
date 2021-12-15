﻿// <auto-generated />
using System;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211214211029_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.CashTransfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSuccessful");

                    b.Property<decimal>("MarineCoin");

                    b.Property<DateTime>("TransferDate");

                    b.Property<string>("TransferNumber");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("MarineCoinTransfers");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisLike");

                    b.Property<Guid>("FunId");

                    b.Property<int>("FunType");

                    b.Property<int>("Like");

                    b.Property<int>("Status");

                    b.Property<DateTime>("SubmitDate");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Models.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<DateTime>("LastActivity");

                    b.Property<int>("Priority");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("Domain.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilePath");

                    b.Property<string>("FunID");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PlaceDate");

                    b.Property<string>("ScheduleID");

                    b.Property<string>("Size");

                    b.Property<string>("UserID");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Domain.Models.Fun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("BackgroundPicture");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<int>("FunType");

                    b.Property<string>("Icon");

                    b.Property<bool>("IsActive");

                    b.Property<int>("OnlineCapacity");

                    b.Property<decimal>("Price");

                    b.Property<int>("RealTimeCapacity");

                    b.Property<int>("SansDuration");

                    b.Property<int>("SansGapTime");

                    b.Property<int>("SansTotalCapacity");

                    b.Property<int>("SellerCapacity");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<string>("SystemFunCode");

                    b.HasKey("Id");

                    b.ToTable("Funs");
                });

            modelBuilder.Entity("Domain.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConversationId");

                    b.Property<int>("MessageStatus");

                    b.Property<DateTime>("SubmitDate");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AvailableCapacity");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<DateTime>("ExecuteDateTime");

                    b.Property<Guid>("FunId");

                    b.Property<int>("FunType");

                    b.Property<bool>("IsExist");

                    b.Property<decimal>("Price");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<string>("SystemFunCode");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhone");

                    b.Property<int>("Condition");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<string>("FullName");

                    b.Property<Guid>("FunId");

                    b.Property<int>("FunType");

                    b.Property<int>("NumberOfTicket");

                    b.Property<decimal>("Price");

                    b.Property<Guid>("ScheduleId");

                    b.Property<DateTime>("ScheduleMiladiTime");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<DateTime>("SubmitDate");

                    b.Property<string>("TicketNumber");

                    b.Property<Guid>("UserId");

                    b.Property<int>("WhereBuy");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<DateTime>("DateJoin");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<string>("NationalCode");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("RoleType");

                    b.Property<string>("SystemUserCode");

                    b.Property<string>("UserName");

                    b.Property<string>("VerifyCode");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Ticket", b =>
                {
                    b.HasOne("Domain.Models.User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.OwnsOne("Domain.Models.UserCart", "UserCart", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("CardNumber");

                            b1.Property<Guid>("Id");

                            b1.Property<string>("ShabaNumber");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Domain.Models.User", "User")
                                .WithOne("UserCart")
                                .HasForeignKey("Domain.Models.UserCart", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}