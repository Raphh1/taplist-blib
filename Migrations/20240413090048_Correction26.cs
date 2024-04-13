using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taplistBLIBofficial.Migrations
{
    /// <inheritdoc />
    public partial class Correction26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stands_Authents_AuthentId",
                table: "Stands");

            migrationBuilder.DropIndex(
                name: "IX_Stands_AuthentId",
                table: "Stands");

            migrationBuilder.DropColumn(
                name: "AuthentId",
                table: "Stands");

            migrationBuilder.DropColumn(
                name: "StandId",
                table: "Authents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthentId",
                table: "Stands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandId",
                table: "Authents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stands_AuthentId",
                table: "Stands",
                column: "AuthentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stands_Authents_AuthentId",
                table: "Stands",
                column: "AuthentId",
                principalTable: "Authents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
