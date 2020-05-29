using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Services",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
