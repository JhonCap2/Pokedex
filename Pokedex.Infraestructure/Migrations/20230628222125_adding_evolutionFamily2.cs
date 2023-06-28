using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class adding_evolutionFamily2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evolutions_Pokemon_PokemonId",
                table: "Evolutions");

            migrationBuilder.DropIndex(
                name: "IX_Evolutions_PokemonId",
                table: "Evolutions");

            migrationBuilder.AddColumn<int>(
                name: "EvolutionFamilyId",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderEvolution",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_EvolutionFamilyId",
                table: "Pokemon",
                column: "EvolutionFamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Evolutions_EvolutionFamilyId",
                table: "Pokemon",
                column: "EvolutionFamilyId",
                principalTable: "Evolutions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Evolutions_EvolutionFamilyId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_EvolutionFamilyId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "EvolutionFamilyId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "OrderEvolution",
                table: "Pokemon");

            migrationBuilder.CreateIndex(
                name: "IX_Evolutions_PokemonId",
                table: "Evolutions",
                column: "PokemonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evolutions_Pokemon_PokemonId",
                table: "Evolutions",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
