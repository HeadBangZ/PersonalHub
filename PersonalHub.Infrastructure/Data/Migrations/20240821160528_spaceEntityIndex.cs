using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class spaceEntityIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8985bb4e-6e33-4061-bf8a-07206b408d7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5b9c78e-28ab-4054-9e68-a24c9807f0a5", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5b9c78e-28ab-4054-9e68-a24c9807f0a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8985bb4e-6e33-4061-bf8a-07206b408d7f", null, "User", "USER" });
        }
    }
}
