using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserStories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7184fc63-aeeb-46e4-a9ad-960a3518d417");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed6808cf-be0e-4475-9f0b-1ee5f436c946", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bedf0b8-d61a-428a-bad1-42d7e4ef4a2c", new DateTime(2024, 7, 26, 16, 59, 36, 889, DateTimeKind.Utc).AddTicks(1711), "AQAAAAIAAYagAAAAEIH7LcRxK1hPfgCeslLjAIH2Wd8GAy85icsflACHljsc7lu/V1+95mlOu7Fl4pYrhA==", "d02636ea-f32b-4e42-bf43-dd61f7788a25" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed6808cf-be0e-4475-9f0b-1ee5f436c946");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7184fc63-aeeb-46e4-a9ad-960a3518d417", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c3fb406-42f3-4bdb-b9b5-01058c81b1a3", new DateTime(2024, 7, 26, 16, 14, 34, 318, DateTimeKind.Utc).AddTicks(8394), "AQAAAAIAAYagAAAAEFweimf0an/czZmeK4lZFXaPm7KJ8+yidqHp7F7mbnU9xzQpOKi1VApEUQAQ31zsPQ==", "5f5fb38a-73cd-4691-acc4-68eaba07d87b" });
        }
    }
}
