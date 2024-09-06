using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedStatusToState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d8348de-de5d-4763-8da9-7b1d5377c334");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Spaces",
                newName: "State");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bafcd4a-61ec-48ca-9221-0942461ea463", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bafcd4a-61ec-48ca-9221-0942461ea463");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Spaces",
                newName: "Status");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d8348de-de5d-4763-8da9-7b1d5377c334", null, "User", "USER" });
        }
    }
}
