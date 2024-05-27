using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiMeetingRoom.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "06ca0c35-13ba-48b7-afe1-0a9cb9523112");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7f0afc1d-08b3-4575-a250-86c90217b3fd");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "Room",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03b407fe-0564-4e99-8b74-bc95d4be0fbb", null, "Admin", "ADMIN" },
                    { "7ed35d56-c2e5-4bbd-827a-7322bf26e251", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "03b407fe-0564-4e99-8b74-bc95d4be0fbb");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7ed35d56-c2e5-4bbd-827a-7322bf26e251");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ca0c35-13ba-48b7-afe1-0a9cb9523112", null, "User", "USER" },
                    { "7f0afc1d-08b3-4575-a250-86c90217b3fd", null, "Admin", "ADMIN" }
                });
        }
    }
}
