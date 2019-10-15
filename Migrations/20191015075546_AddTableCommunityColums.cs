using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAgilityPackSMS.Migrations
{
    public partial class AddTableCommunityColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellCount",
                table: "Communitys",
                newName: "SellingCount");

            migrationBuilder.RenameColumn(
                name: "RentCount",
                table: "Communitys",
                newName: "SelledOutLastMonth");

            migrationBuilder.AddColumn<int>(
                name: "RentingCount",
                table: "Communitys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentingCount",
                table: "Communitys");

            migrationBuilder.RenameColumn(
                name: "SellingCount",
                table: "Communitys",
                newName: "SellCount");

            migrationBuilder.RenameColumn(
                name: "SelledOutLastMonth",
                table: "Communitys",
                newName: "RentCount");
        }
    }
}
