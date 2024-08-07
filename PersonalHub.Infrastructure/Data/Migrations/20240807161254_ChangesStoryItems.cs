using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesStoryItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79c02be9-a0c3-4290-94f0-888a31bb8a61");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "StoryItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StoryItems");

            migrationBuilder.AddColumn<string>(
                name: "StoryItemPriority",
                table: "StoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StoryItemType",
                table: "StoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d40b0d97-eb54-4ea6-8b3e-f1bfcf912feb", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "103eed8c-a95c-4d2e-b4ff-62945a7984c2", new DateTime(2024, 8, 7, 16, 12, 54, 426, DateTimeKind.Utc).AddTicks(4663), "AQAAAAIAAYagAAAAEAMi/lmXvp8jN/IuTj3QRUnodjR0h80Vvm13ZSX8RWK52FGVv6CkDdj/zV3MJm+fLg==", "98f68376-f42d-4645-96c9-362c75c4054f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d40b0d97-eb54-4ea6-8b3e-f1bfcf912feb");

            migrationBuilder.DropColumn(
                name: "StoryItemPriority",
                table: "StoryItems");

            migrationBuilder.DropColumn(
                name: "StoryItemType",
                table: "StoryItems");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "StoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
