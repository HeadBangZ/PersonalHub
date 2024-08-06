using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c0ded413-68e3-49b5-84b7-6da83fc6f114", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b10ece-d0ff-4920-807e-56bd83dbcc4c", new DateTime(2024, 8, 6, 17, 30, 21, 475, DateTimeKind.Utc).AddTicks(6815), "AQAAAAIAAYagAAAAEP00ExVtMYzhdvCcsywSD3bRIr9MR3vyMU8s9oqB7AhUfauTTF/c1mzg1JC7GS0fZw==", "38159ea5-106b-4144-ba23-3a62cde8f981" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ded413-68e3-49b5-84b7-6da83fc6f114");

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
    }
}
