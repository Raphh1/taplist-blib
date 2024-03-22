using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taplistBLIBofficial.Migrations
{
    /// <inheritdoc />
    public partial class Standtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Authents",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authents",
                newName: "UserId");
        }
    }
}
