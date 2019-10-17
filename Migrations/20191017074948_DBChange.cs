using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAgilityPackSMS.Migrations
{
    public partial class DBChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys");

            migrationBuilder.DropIndex(
                name: "IX_Communitys_UnitId",
                table: "Communitys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Communitys_UnitId",
                table: "Communitys",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys",
                column: "UnitId",
                principalTable: "AcquisitionUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
