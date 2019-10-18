using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAgilityPackSMS.Migrations
{
    public partial class AddTableAcquisitionUnitId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Communitys",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys",
                column: "UnitId",
                principalTable: "AcquisitionUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Communitys",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys",
                column: "UnitId",
                principalTable: "AcquisitionUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
