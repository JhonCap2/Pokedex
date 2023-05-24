using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class adjusting_speciesClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon",
                column: "SpeciesId",
                unique: true,
                filter: "[SpeciesId] IS NOT NULL");
        }
    }
}
