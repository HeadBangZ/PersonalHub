using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class newchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ded413-68e3-49b5-84b7-6da83fc6f114");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79c02be9-a0c3-4290-94f0-888a31bb8a61", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6897a1a7-15b4-4598-8661-17ff9f15116c", new DateTime(2024, 8, 6, 17, 44, 8, 671, DateTimeKind.Utc).AddTicks(3681), "AQAAAAIAAYagAAAAEGdv5/F0rEfec7You36J3/1C+HaLHPt7p9YY6j2hL8ciqMNFuN//vclSJCoD4O6ZtA==", "e3a6b228-a11a-4df9-9192-3fe50fa2d99c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79c02be9-a0c3-4290-94f0-888a31bb8a61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0ded413-68e3-49b5-84b7-6da83fc6f114", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b10ece-d0ff-4920-807e-56bd83dbcc4c", new DateTime(2024, 8, 6, 17, 30, 21, 475, DateTimeKind.Utc).AddTicks(6815), "AQAAAAIAAYagAAAAEP00ExVtMYzhdvCcsywSD3bRIr9MR3vyMU8s9oqB7AhUfauTTF/c1mzg1JC7GS0fZw==", "38159ea5-106b-4144-ba23-3a62cde8f981" });
        }
    }
}
