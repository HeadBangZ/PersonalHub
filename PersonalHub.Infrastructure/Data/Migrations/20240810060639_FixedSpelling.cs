using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39a301e0-4d9f-4eac-b82d-7e3b943d7292");

            migrationBuilder.RenameColumn(
                name: "Severeity",
                table: "Bugs",
                newName: "Severity");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97879cfe-e63c-454a-bf21-f77b492f08a7", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97879cfe-e63c-454a-bf21-f77b492f08a7");

            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "Bugs",
                newName: "Severeity");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39a301e0-4d9f-4eac-b82d-7e3b943d7292", null, "User", "USER" });
        }
    }
}
