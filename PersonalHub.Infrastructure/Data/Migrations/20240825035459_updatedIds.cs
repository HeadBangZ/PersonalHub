using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cd3b616-3df8-4a2d-9fd1-df484cbf024e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e8bd418-7081-4255-ada7-a99c3a08f76a", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e8bd418-7081-4255-ada7-a99c3a08f76a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cd3b616-3df8-4a2d-9fd1-df484cbf024e", null, "User", "USER" });
        }
    }
}
