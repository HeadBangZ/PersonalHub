using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReturnOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5617c9f-7b55-4344-bb2d-8a5e06e0b416");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c5617c9f-7b55-4344-bb2d-8a5e06e0b416", null, "User", "USER" },
                    { "d7a0819a-90fb-4395-bd51-e6b64414b447", null, "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "a11429d5-dcd7-485f-a20e-3ad10848c6e3", 0, "48f826ca-73c7-4ced-bbdc-f1769bb5a55b", new DateTime(2024, 7, 20, 6, 20, 28, 905, DateTimeKind.Utc).AddTicks(9717), "nordvigprivat@gmail.com", true, "Thomas", "Hermansen", false, null, "NORDVIGPRIVAT@GMAIL.COM", "NORDVIGPRIVAT@GMAIL.COM", "AQAAAAIAAYagAAAAEHuo/aUIkbpXChw41qvfZ/M2yZcmvW+Uoq1QfI3sWD5FD9NkWvX3VoiJz1eDLtksfQ==", null, false, "6691b96c-67b6-4c52-a052-0d55a47ba457", false, null, "nordvigprivat@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7a0819a-90fb-4395-bd51-e6b64414b447", "a11429d5-dcd7-485f-a20e-3ad10848c6e3" });
        }
    }
}
