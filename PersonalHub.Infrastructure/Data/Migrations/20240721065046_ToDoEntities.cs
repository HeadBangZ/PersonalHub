using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToDoEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_ToDoLists_ToDoListId",
                table: "ToDoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a59d5bc8-157c-47c4-a8ea-bee35e85b60e");

            migrationBuilder.RenameTable(
                name: "ToDoItem",
                newName: "ToDoItems");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItem_ToDoListId",
                table: "ToDoItems",
                newName: "IX_ToDoItems_ToDoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86b2a70d-46c0-496d-ae97-bceedf437a64", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a48123eb-9178-4a9b-bf88-bbf0a2ec521a", new DateTime(2024, 7, 21, 6, 50, 46, 286, DateTimeKind.Utc).AddTicks(9226), "AQAAAAIAAYagAAAAECMuej4l0NGIpEZJIrnt4fOmXZ8TXt5bY1WOKPdHdwgBzr35Jcf4kZgJb8cx50TTPQ==", "2e1dba79-d2cb-4e51-b8c3-3d98d38a0889" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDoLists_ToDoListId",
                table: "ToDoItems",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDoLists_ToDoListId",
                table: "ToDoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b2a70d-46c0-496d-ae97-bceedf437a64");

            migrationBuilder.RenameTable(
                name: "ToDoItems",
                newName: "ToDoItem");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItems_ToDoListId",
                table: "ToDoItem",
                newName: "IX_ToDoItem_ToDoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItem",
                table: "ToDoItem",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a59d5bc8-157c-47c4-a8ea-bee35e85b60e", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11429d5-dcd7-485f-a20e-3ad10848c6e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13a355a5-ce79-4c97-bd53-f7308f72d2bb", new DateTime(2024, 7, 21, 6, 47, 43, 2, DateTimeKind.Utc).AddTicks(4252), "AQAAAAIAAYagAAAAEK9965yuRXdOXz6ojEOfP2kQV2yQixElUokT1oc8fZpbdFTK/3v9lPKmHipCDiEv7A==", "b4913ce3-6df2-4c87-b312-b8d6ea7e7cdf" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_ToDoLists_ToDoListId",
                table: "ToDoItem",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
