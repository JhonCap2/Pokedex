using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Species_SpeciesId",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_TypesPokemon_Types_TypesId",
                table: "TypesPokemon");

            migrationBuilder.DropIndex(
                name: "IX_TypesPokemon_TypesId",
                table: "TypesPokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "TypesId",
                table: "TypesPokemon");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Pokemon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon",
                column: "SpeciesId",
                unique: true,
                filter: "[SpeciesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Species_SpeciesId",
                table: "Pokemon",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Species_SpeciesId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "TypesId",
                table: "TypesPokemon",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypesPokemon_TypesId",
                table: "TypesPokemon",
                column: "TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon",
                column: "SpeciesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Species_SpeciesId",
                table: "Pokemon",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypesPokemon_Types_TypesId",
                table: "TypesPokemon",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
