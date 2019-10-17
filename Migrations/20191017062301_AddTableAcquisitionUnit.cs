using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAgilityPackSMS.Migrations
{
    public partial class AddTableAcquisitionUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Communitys",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcquisitionUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    CreateTime = table.Column<long>(nullable: false),
                    ModifiedTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcquisitionUnit", x => x.Id);
                });

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communitys_AcquisitionUnit_UnitId",
                table: "Communitys");

            migrationBuilder.DropTable(
                name: "AcquisitionUnit");

            migrationBuilder.DropIndex(
                name: "IX_Communitys_UnitId",
                table: "Communitys");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Communitys");
        }
    }
}
