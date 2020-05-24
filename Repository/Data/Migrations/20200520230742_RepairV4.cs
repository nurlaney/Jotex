using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class RepairV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutCompanyBanners");

            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AboutCompanyFunFacts");

            migrationBuilder.DropColumn(
                name: "ActionText",
                table: "AboutCompanyEncourages");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AboutCompanyEncourages");

            migrationBuilder.AddColumn<string>(
                name: "BottomDesc",
                table: "Services",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BottomText",
                table: "Services",
                maxLength: 550,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Services",
                maxLength: 550,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Services",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AboutCompanyId",
                table: "AboutCompanyFunFacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FFDescription",
                table: "AboutCompanyFunFacts",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AboutCompanyId",
                table: "AboutCompanyEncourages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EncActionText",
                table: "AboutCompanyEncourages",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "AboutCompanyEncourages",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AboutCompanyFunFacts_AboutCompanyId",
                table: "AboutCompanyFunFacts",
                column: "AboutCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutCompanyEncourages_AboutCompanyId",
                table: "AboutCompanyEncourages",
                column: "AboutCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutCompanyEncourages_AboutCompanies_AboutCompanyId",
                table: "AboutCompanyEncourages",
                column: "AboutCompanyId",
                principalTable: "AboutCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutCompanyFunFacts_AboutCompanies_AboutCompanyId",
                table: "AboutCompanyFunFacts",
                column: "AboutCompanyId",
                principalTable: "AboutCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutCompanyEncourages_AboutCompanies_AboutCompanyId",
                table: "AboutCompanyEncourages");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutCompanyFunFacts_AboutCompanies_AboutCompanyId",
                table: "AboutCompanyFunFacts");

            migrationBuilder.DropIndex(
                name: "IX_AboutCompanyFunFacts_AboutCompanyId",
                table: "AboutCompanyFunFacts");

            migrationBuilder.DropIndex(
                name: "IX_AboutCompanyEncourages_AboutCompanyId",
                table: "AboutCompanyEncourages");

            migrationBuilder.DropColumn(
                name: "BottomDesc",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "BottomText",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "AboutCompanyId",
                table: "AboutCompanyFunFacts");

            migrationBuilder.DropColumn(
                name: "FFDescription",
                table: "AboutCompanyFunFacts");

            migrationBuilder.DropColumn(
                name: "AboutCompanyId",
                table: "AboutCompanyEncourages");

            migrationBuilder.DropColumn(
                name: "EncActionText",
                table: "AboutCompanyEncourages");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "AboutCompanyEncourages");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AboutCompanyFunFacts",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActionText",
                table: "AboutCompanyEncourages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AboutCompanyEncourages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AboutCompanyBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutCompanyBanners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceId",
                table: "ServiceDetails",
                column: "ServiceId");
        }
    }
}
