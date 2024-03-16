using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kochbuch_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addedUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61bebe23-ab29-4358-869d-036844a62f4d", null, "Administrator", "ADMINISTRATOR" },
                    { "8bde0749-8713-48b4-87b5-1937c7e0bbb6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61bebe23-ab29-4358-869d-036844a62f4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bde0749-8713-48b4-87b5-1937c7e0bbb6");
        }
    }
}
