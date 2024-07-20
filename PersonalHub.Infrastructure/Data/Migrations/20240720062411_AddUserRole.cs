using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3afb3d01-2248-414c-bb56-520f5522ba94");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "397f19e8-4956-4aee-a94a-d8fe131348b4", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7a0819a-90fb-4395-bd51-e6b64414b447", "a11429d5-dcd7-485f-a20e-3ad10848c6e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ff36cdc-9678-4d95-b707-4584aafe4708", new DateTime(2024, 7, 20, 6, 24, 11, 64, DateTimeKind.Utc).AddTicks(6228), "AQAAAAIAAYagAAAAEPalPnE0jfc1KWvczOAtqcYsz7/cX4XtwIStx/SPoSBl+7cbpqMwr5K5LJs5IB3UYQ==", "63344902-2cc5-47d5-8e86-055314dc26f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "397f19e8-4956-4aee-a94a-d8fe131348b4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d7a0819a-90fb-4395-bd51-e6b64414b447", "a11429d5-dcd7-485f-a20e-3ad10848c6e3" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3afb3d01-2248-414c-bb56-520f5522ba94", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27508946-c96a-44ac-82ac-cb7b84adb252", new DateTime(2024, 7, 20, 6, 23, 42, 923, DateTimeKind.Utc).AddTicks(7137), "AQAAAAIAAYagAAAAEDT63WlSyPwi1UoK9vqy+4GRQ3s+F+QDAcvV3IN39w5ylThet7lY9ZmfGe+bvgj9vw==", "c7e2478e-9b5d-4d61-8fd8-31c958a73edc" });
        }
    }
}
