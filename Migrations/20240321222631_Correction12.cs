using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taplistBLIBofficial.Migrations
{
    /// <inheritdoc />
    public partial class Correction12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Beers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Beers");
        }
    }
}
