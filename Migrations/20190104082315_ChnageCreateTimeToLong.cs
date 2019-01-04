using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAgilityPackSMS.Migrations
{
    public partial class ChnageCreateTimeToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendTime",
                table: "SMSRawDatas");

            migrationBuilder.AddColumn<long>(
                name: "CreateTime",
                table: "SMSRawDatas",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedTime",
                table: "SMSRawDatas",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "CreateTime",
                table: "SendHandListStatuss",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<long>(
                name: "ModifiedTime",
                table: "SendHandListStatuss",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "SMSRawDatas");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "SMSRawDatas");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "SendHandListStatuss");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendTime",
                table: "SMSRawDatas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SendHandListStatuss",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
