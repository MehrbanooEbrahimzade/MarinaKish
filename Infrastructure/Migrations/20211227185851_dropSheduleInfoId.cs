using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class dropSheduleInfoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funs_ScheduleInfos_ScheduleInfoId",
                table: "Funs");

            migrationBuilder.DropIndex(
                name: "IX_Funs_ScheduleInfoId",
                table: "Funs");

            migrationBuilder.DropColumn(
                name: "ScheduleInfoId",
                table: "Funs");

            migrationBuilder.AddColumn<Guid>(
                name: "FunId",
                table: "ScheduleInfos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInfos_FunId",
                table: "ScheduleInfos",
                column: "FunId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleInfos_Funs_FunId",
                table: "ScheduleInfos",
                column: "FunId",
                principalTable: "Funs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleInfos_Funs_FunId",
                table: "ScheduleInfos");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleInfos_FunId",
                table: "ScheduleInfos");

            migrationBuilder.DropColumn(
                name: "FunId",
                table: "ScheduleInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleInfoId",
                table: "Funs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funs_ScheduleInfoId",
                table: "Funs",
                column: "ScheduleInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funs_ScheduleInfos_ScheduleInfoId",
                table: "Funs",
                column: "ScheduleInfoId",
                principalTable: "ScheduleInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
