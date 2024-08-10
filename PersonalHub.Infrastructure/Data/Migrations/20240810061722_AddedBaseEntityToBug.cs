using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseEntityToBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97879cfe-e63c-454a-bf21-f77b492f08a7");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bugs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Bugs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48c34fc7-9c5c-41d6-a580-df7094979e67", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48c34fc7-9c5c-41d6-a580-df7094979e67");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Bugs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97879cfe-e63c-454a-bf21-f77b492f08a7", null, "User", "USER" });
        }
    }
}
