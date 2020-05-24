using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class RepairsV42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "CaseStudies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CaseStudies_ServiceId",
                table: "CaseStudies",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStudies_Services_ServiceId",
                table: "CaseStudies",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseStudies_Services_ServiceId",
                table: "CaseStudies");

            migrationBuilder.DropIndex(
                name: "IX_CaseStudies_ServiceId",
                table: "CaseStudies");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "CaseStudies");
        }
    }
}
