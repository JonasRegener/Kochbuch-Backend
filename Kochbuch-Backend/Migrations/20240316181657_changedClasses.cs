using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kochbuch_Backend.Migrations
{
    /// <inheritdoc />
    public partial class changedClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Ingredients",
                newName: "Measurement");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Reciepes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Reciepes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Measurement",
                table: "Ingredients",
                newName: "ShortName");
        }
    }
}
