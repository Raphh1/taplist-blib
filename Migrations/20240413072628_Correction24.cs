using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taplistBLIBofficial.Migrations
{
    /// <inheritdoc />
    public partial class Correction24 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Stands",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "StandId",
                table: "Authents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Stands_Authents_Id",
                table: "Stands",
                column: "Id",
                principalTable: "Authents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stands_Authents_Id",
                table: "Stands");

            migrationBuilder.DropColumn(
                name: "StandId",
                table: "Authents");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Stands",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AuthentId",
                table: "Stands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stands_AuthentId",
                table: "Stands",
                column: "AuthentId");

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
