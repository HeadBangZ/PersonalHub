using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPersonalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d40b0d97-eb54-4ea6-8b3e-f1bfcf912feb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d7a0819a-90fb-4395-bd51-e6b64414b447", "a11429d5-dcd7-485f-a20e-3ad10848c6e3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7a0819a-90fb-4395-bd51-e6b64414b447");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Information_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Information_FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Information_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "Information_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "Information_DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information_Nationality",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information_DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Information_Nationality",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Information_LastName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Information_FirstName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d40b0d97-eb54-4ea6-8b3e-f1bfcf912feb", null, "User", "USER" },
                    { "d7a0819a-90fb-4395-bd51-e6b64414b447", null, "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "a11429d5-dcd7-485f-a20e-3ad10848c6e3", 0, "103eed8c-a95c-4d2e-b4ff-62945a7984c2", new DateTime(2024, 8, 7, 16, 12, 54, 426, DateTimeKind.Utc).AddTicks(4663), "nordvigprivat@gmail.com", true, "Thomas", "Hermansen", false, null, "NORDVIGPRIVAT@GMAIL.COM", "NORDVIGPRIVAT@GMAIL.COM", "AQAAAAIAAYagAAAAEAMi/lmXvp8jN/IuTj3QRUnodjR0h80Vvm13ZSX8RWK52FGVv6CkDdj/zV3MJm+fLg==", null, false, "98f68376-f42d-4645-96c9-362c75c4054f", false, null, "nordvigprivat@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7a0819a-90fb-4395-bd51-e6b64414b447", "a11429d5-dcd7-485f-a20e-3ad10848c6e3" });
        }
    }
}
