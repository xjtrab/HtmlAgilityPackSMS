using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAgilityPackSMS.Migrations
{
    public partial class AddTableGlobalStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThridPartyId",
                table: "Communitys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThridPraty",
                table: "Communitys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GlobalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusFrom = table.Column<string>(nullable: true),
                    TotalCommunityCount = table.Column<int>(nullable: false),
                    CreateTime = table.Column<long>(nullable: false),
                    ModifiedTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalStatuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalStatuses");

            migrationBuilder.DropColumn(
                name: "ThridPartyId",
                table: "Communitys");

            migrationBuilder.DropColumn(
                name: "ThridPraty",
                table: "Communitys");
        }
    }
}
