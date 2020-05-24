using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class PlaceSwap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTime",
                table: "Settings",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_ContactId",
                table: "Settings",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Contacts_ContactId",
                table: "Settings",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Contacts_ContactId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_ContactId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WorkTime",
                table: "Settings");
        }
    }
}
