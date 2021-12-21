using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class forisdelet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Funs_FunId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Writ");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_FunId",
                table: "Writ",
                newName: "IX_Writ_FunId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tickets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Schedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ScheduleInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Funs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CreditCards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Writ",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Writ",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "FunId",
                table: "Writ",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "DisLike",
                table: "Writ",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Writ",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                table: "Writ",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Writ",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Writ",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writ",
                table: "Writ",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CashTransfer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransferNumber = table.Column<string>(nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    MarineCoin = table.Column<decimal>(nullable: false),
                    IsSuccessful = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastActivity = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Writ_Funs_FunId",
                table: "Writ",
                column: "FunId",
                principalTable: "Funs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writ_Funs_FunId",
                table: "Writ");

            migrationBuilder.DropTable(
                name: "CashTransfer");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writ",
                table: "Writ");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ScheduleInfos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Funs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Writ");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                table: "Writ");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Writ");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Writ");

            migrationBuilder.RenameTable(
                name: "Writ",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Writ_FunId",
                table: "Comments",
                newName: "IX_Comments_FunId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Like",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FunId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisLike",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Funs_FunId",
                table: "Comments",
                column: "FunId",
                principalTable: "Funs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
