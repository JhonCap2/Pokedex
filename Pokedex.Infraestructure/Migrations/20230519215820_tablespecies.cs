using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class tablespecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Species",
                table: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Species_SpeciesId",
                table: "Pokemon");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpeciesId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Pokemon");

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
