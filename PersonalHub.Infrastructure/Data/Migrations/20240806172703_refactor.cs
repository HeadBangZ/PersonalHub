using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6cafe38-226c-4602-91bc-1e97c76f4648");

            migrationBuilder.AddColumn<Guid>(
                name: "UserStoryId1",
                table: "StoryItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62ee272f-4635-41b2-a430-d253b972f44d", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ffaf02c-0b87-4937-aebe-497a2bbffed5", new DateTime(2024, 8, 6, 17, 27, 2, 798, DateTimeKind.Utc).AddTicks(2951), "AQAAAAIAAYagAAAAENdlLvGfiImLXp8QgzMxeG2QUbOd2pOzIqyCKtYE/dAjzSm+lIgXzD6M3glH+Eq98Q==", "5e2cbb75-a0d8-42bd-aa06-205bf9875257" });

            migrationBuilder.CreateIndex(
                name: "IX_StoryItems_UserStoryId1",
                table: "StoryItems",
                column: "UserStoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryItems_UserStories_UserStoryId1",
                table: "StoryItems",
                column: "UserStoryId1",
                principalTable: "UserStories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryItems_UserStories_UserStoryId1",
                table: "StoryItems");

            migrationBuilder.DropIndex(
                name: "IX_StoryItems_UserStoryId1",
                table: "StoryItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62ee272f-4635-41b2-a430-d253b972f44d");

            migrationBuilder.DropColumn(
                name: "UserStoryId1",
                table: "StoryItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6cafe38-226c-4602-91bc-1e97c76f4648", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89dd6f2f-3b0d-4f28-83a8-43381f778e34", new DateTime(2024, 7, 27, 6, 8, 12, 275, DateTimeKind.Utc).AddTicks(3312), "AQAAAAIAAYagAAAAED3O6CwEzlqhLKLa2BMPPse0pUAJeIIX4rIgtJ9ysEp3S9UHt6/lznrEh9O/zGyYaw==", "32d32817-a279-458f-9e60-dd87018ed08a" });
        }
    }
}
