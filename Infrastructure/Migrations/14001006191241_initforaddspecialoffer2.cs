using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initforaddspecialoffer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Percent_DiscountId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "DiscountId",
                table: "Schedules",
                newName: "PercentId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_DiscountId",
                table: "Schedules",
                newName: "IX_Schedules_PercentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Percent_PercentId",
                table: "Schedules",
                column: "PercentId",
                principalTable: "Percent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Percent_PercentId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "PercentId",
                table: "Schedules",
                newName: "DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_PercentId",
                table: "Schedules",
                newName: "IX_Schedules_DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Percent_DiscountId",
                table: "Schedules",
                column: "DiscountId",
                principalTable: "Percent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
