using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marina_Club.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    DisLike = table.Column<int>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    FunType = table.Column<int>(nullable: false),
                    FunId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserCellPhone = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastActivity = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    PlaceDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    FunID = table.Column<string>(nullable: true),
                    ScheduleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SystemFunCode = table.Column<string>(nullable: true),
                    FunType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    SansDuration = table.Column<int>(nullable: false),
                    SansTotalCapacity = table.Column<int>(nullable: false),
                    SansGapTime = table.Column<int>(nullable: false),
                    OnlineCapacity = table.Column<int>(nullable: false),
                    RealTimeCapacity = table.Column<int>(nullable: false),
                    SellerCapacity = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    BackgroundPicture = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarineCoinTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransferNumber = table.Column<string>(nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    MarineCoin = table.Column<decimal>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarineCoinTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlaceDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    MessageStatus = table.Column<int>(nullable: false),
                    ConversationID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SystemFunCode = table.Column<string>(nullable: true),
                    FunType = table.Column<int>(nullable: false),
                    ExcuteMiladiDateTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AvailableCapacity = table.Column<decimal>(nullable: false),
                    IsExist = table.Column<bool>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    FunId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CellPhone = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    FunType = table.Column<int>(nullable: false),
                    ScheduleMiladiTime = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    TicketNumber = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    FunId = table.Column<Guid>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Condition = table.Column<int>(nullable: false),
                    NumberOfTicket = table.Column<int>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    WhereBuy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CellPhone = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Provice = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SystemUserCode = table.Column<string>(nullable: true),
                    RoleType = table.Column<int>(nullable: false),
                    VerifyCode = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ShabaNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    ContactInfoId = table.Column<Guid>(nullable: true),
                    Wallet = table.Column<decimal>(nullable: false),
                    DateJoin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ContactInfos_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "ContactInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactInfoId",
                table: "Users",
                column: "ContactInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Funs");

            migrationBuilder.DropTable(
                name: "MarineCoinTransfers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContactInfos");
        }
    }
}
