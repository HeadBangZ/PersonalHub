using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1bb691e-8494-4aa1-b71f-6580d385ed42");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3afb3d01-2248-414c-bb56-520f5522ba94", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "a11429d5-dcd7-485f-a20e-3ad10848c6e3", 0, "27508946-c96a-44ac-82ac-cb7b84adb252", new DateTime(2024, 7, 20, 6, 23, 42, 923, DateTimeKind.Utc).AddTicks(7137), "nordvigprivat@gmail.com", true, "Thomas", "Hermansen", false, null, "NORDVIGPRIVAT@GMAIL.COM", "NORDVIGPRIVAT@GMAIL.COM", "AQAAAAIAAYagAAAAEDT63WlSyPwi1UoK9vqy+4GRQ3s+F+QDAcvV3IN39w5ylThet7lY9ZmfGe+bvgj9vw==", null, false, "c7e2478e-9b5d-4d61-8fd8-31c958a73edc", false, null, "nordvigprivat@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3afb3d01-2248-414c-bb56-520f5522ba94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1bb691e-8494-4aa1-b71f-6580d385ed42", null, "User", "USER" });
        }
    }
}
