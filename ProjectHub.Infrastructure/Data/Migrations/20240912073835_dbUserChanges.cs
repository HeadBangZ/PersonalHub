using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbUserChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApiUserId",
                table: "UserProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f2aab25-146b-488a-aac4-62391ac06ff9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6b3beb4-7206-49d1-ba11-74831681498f", null, "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApiUserId",
                table: "UserProfile",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApiUserId",
                table: "UserProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6b3beb4-7206-49d1-ba11-74831681498f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f2aab25-146b-488a-aac4-62391ac06ff9", null, "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApiUserId",
                table: "UserProfile",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
