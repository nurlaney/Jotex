using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class RepairV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomDesc",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "BottomText",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BottomDesc",
                table: "Services",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BottomText",
                table: "Services",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
