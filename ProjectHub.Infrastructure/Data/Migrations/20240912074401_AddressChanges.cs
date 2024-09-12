using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6b3beb4-7206-49d1-ba11-74831681498f");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_Zipcode",
                table: "UserProfile",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_StreeName",
                table: "UserProfile",
                newName: "StreeName");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_Region",
                table: "UserProfile",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_Number",
                table: "UserProfile",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_Municipality",
                table: "UserProfile",
                newName: "Municipality");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_CountryCode",
                table: "UserProfile",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_Country",
                table: "UserProfile",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "AddressInfo_City",
                table: "UserProfile",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1fdc150-9e18-4df2-90ce-55dd5b3803b5", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1fdc150-9e18-4df2-90ce-55dd5b3803b5");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "UserProfile",
                newName: "AddressInfo_Zipcode");

            migrationBuilder.RenameColumn(
                name: "StreeName",
                table: "UserProfile",
                newName: "AddressInfo_StreeName");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "UserProfile",
                newName: "AddressInfo_Region");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "UserProfile",
                newName: "AddressInfo_Number");

            migrationBuilder.RenameColumn(
                name: "Municipality",
                table: "UserProfile",
                newName: "AddressInfo_Municipality");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "UserProfile",
                newName: "AddressInfo_CountryCode");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "UserProfile",
                newName: "AddressInfo_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "UserProfile",
                newName: "AddressInfo_City");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6b3beb4-7206-49d1-ba11-74831681498f", null, "User", "USER" });
        }
    }
}
